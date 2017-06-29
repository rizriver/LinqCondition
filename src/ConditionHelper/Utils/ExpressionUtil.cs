using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace RizRiver.ConditionHelper.Utils
{
    /// <summary>
    /// 式ツリーを操作するユーティリティクラス
    /// </summary>
    internal static class ExpressionUtil
    {
        /// <summary>
        /// string.StartsWithメソッド
        /// </summary>
        private static readonly MethodInfo _startsWith = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

        /// <summary>
        /// string.EndsWithメソッド
        /// </summary>
        private static readonly MethodInfo _endsWith = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        /// <summary>
        /// string.IndexOfメソッド
        /// </summary>
        private static readonly MethodInfo _indexOf = typeof(string).GetMethod("IndexOf", new[] { typeof(string) });

        /// <summary>
        /// 条件一致判定を行うための式を構築する
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="conditions">条件群</param>
        /// <returns>構築された式ツリー</returns>
        public static Expression<Func<TSource, bool>> CreateConditionPredicate<TSource>(params Condition[] conditions)
        {
            ParameterExpression param = Expression.Parameter(typeof(TSource), "e");

            List<Expression> bodies = new List<Expression>();
            Array.ForEach(conditions, c => bodies.Add(CreateBodyExpression(param, c)));

            // AndAlso演算
            Expression body = null;
            Array.ForEach(bodies.ToArray(), b => body = body == null ? body = b : Expression.AndAlso(body, b));

            // debug info
            System.Diagnostics.Debug.WriteLine("Expression Created. -- " + Expression.Lambda<Func<TSource, bool>>(body, param));

            return Expression.Lambda<Func<TSource, bool>>(body, param);
        }

        /// <summary>
        /// 条件一致判定を行うための式を構築する
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="conditionChain">連鎖された条件</param>
        /// <returns>構築された式ツリー</returns>
        public static Expression<Func<TSource, bool>> CreateConditionPredicate<TSource>(ConditionGroup conditionGroup)
        {
            ParameterExpression param = Expression.Parameter(typeof(TSource), "e");

            // 条件のグループ単位で条件式を構築し、bodyListで保持しておく
            List<Expression> bodyList = new List<Expression>();
            Expression body = CreateInner<TSource>(conditionGroup, param);
            // debug info
            System.Diagnostics.Debug.WriteLine("Expression Created. -- " + Expression.Lambda<Func<TSource, bool>>(body, param));

            return Expression.Lambda<Func<TSource, bool>>(body, param);
        }

        private static Expression CreateInner<TSource>(ConditionGroup group, ParameterExpression param)
        {
            List<Tuple<Expression, ChainType>> bodyList = new List<Tuple<Expression, ChainType>>();
            
            foreach (var condGroup in group.GroupList)
            {
                
                var childGroup = condGroup.Item1 as ConditionGroup;
                if (childGroup != null)
                {
                    bodyList.Add(Tuple.Create(CreateInner<TSource>(childGroup, param), condGroup.Item2));
                }
                else
                {
                    bodyList.Add(Tuple.Create(CreateBodyExpression(param,(Condition)condGroup.Item1), condGroup.Item2));
                }
                
            }
            // bodyListで保持された条件式同士を、適切な演算子で連結し、最終的な式を構築する
            Expression body = bodyList[0].Item1;
            for (int i = 1; i < bodyList.Count; i++)
            {
                //body = JoinExpression(body, bodyList[i].Item1, bodyList[i].Item2);
                body = Expression.MakeBinary(bodyList[i].Item2 == ChainType.AndAlso ? ExpressionType.AndAlso : ExpressionType.OrElse, body, bodyList[i].Item1);
            }
            return body;
        }

        ///// <summary>
        ///// 式同士の条件付き演算を行う式を構築する
        ///// </summary>
        ///// <param name="left">左辺</param>
        ///// <param name="right">右辺</param>
        ///// <param name="chainType">連鎖タイプ</param>
        ///// <returns>構築された演算式</returns>
        //private static BinaryExpression JoinExpression(Expression left, Expression right, ChainType chainType)
        //{
        //    BinaryExpression result;
        //    switch (chainType)
        //    {
        //        case ChainType.AndAlso:
        //            result = Expression.AndAlso(left, right);
        //            break;

        //        case ChainType.OrElse:
        //            result = Expression.OrElse(left, right);
        //            break;

        //        default:
        //            result = null;
        //            System.Diagnostics.Debug.Assert(false); // ここに到達したら実装バグ
        //            break;
        //    }
        //    return result;
        //}

        /// <summary>
        /// 式の本体部 [param.name==conditionValue] を構築する
        /// </summary>
        /// <param name="param">パラメータ式</param>
        /// <param name="condition">条件</param>
        /// <returns>式の本体部</returns>
        private static Expression CreateBodyExpression(ParameterExpression param, Condition condition)
        {
            // パラメータ condition.Valuesは非nullかつ1件以上であることは保障されている
            System.Diagnostics.Debug.Assert(!(condition.Values == null || condition.Values.Length < 1));

            // 左辺[param.xxxx]を作成
            MemberExpression leftExp = Expression.Property(param, condition.Name);
            List<Expression> resultExpList = new List<Expression>();
            foreach (object conditionValue in condition.Values)
            {
                // 値に対し、必要に応じて型変換を行う
                object value = conditionValue;
                Type convertType = leftExp.Type;
                if (convertType.IsGenericType && convertType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Nullableの場合は元の型に変換
                    convertType = Nullable.GetUnderlyingType(convertType);
                }

                if (value.GetType() != convertType)
                {
                    try
                    {
                        value = Convert.ChangeType(conditionValue, convertType);
                    }
                    catch(Exception ex)
                    {
                        ArgumentException argumentException = new ArgumentException("Condition value type is invalid.", nameof(condition), ex);
                        argumentException.Data.Add("InvalidCondition", condition);
                        throw argumentException;
                    }
                }

                // 右辺[値]を作成
                ConstantExpression rightExp = Expression.Constant(value, leftExp.Type);

                // 左辺と右辺を比較する式を作成
                Expression expression = null;

                if (condition.Like == LikeTypes.None)
                {
                    // Like検索指定がなければ単純比較式を構築
                    switch (condition.CompareType)
                    {
                        case CompareType.Equal:
                            expression = Expression.Equal(leftExp, rightExp);
                            break;

                        case CompareType.NotEqual:
                            expression = Expression.NotEqual(leftExp, rightExp);
                            break;

                        case CompareType.LessThan:
                            expression = Expression.LessThan(leftExp, rightExp);
                            break;

                        case CompareType.LessThanOrEqual:
                            expression = Expression.LessThanOrEqual(leftExp, rightExp);
                            break;

                        case CompareType.GreaterThan:
                            expression = Expression.GreaterThan(leftExp, rightExp);
                            break;

                        case CompareType.GreaterThanOrEqual:
                            expression = Expression.GreaterThanOrEqual(leftExp, rightExp);
                            break;

                        default:
                            System.Diagnostics.Debug.Assert(false); // ここに到達したら実装バグ
                            break;
                    }
                }
                else
                {
                    // Like検索指定されている場合は、その指定により比較式を構築
                    switch ((condition.Like | LikeTypes.Not) ^ LikeTypes.Not) // Not指定は排除
                    {
                        case LikeTypes.Forward:
                            // 前方一致比較: string.StartsWithメソッドを使用
                            expression = Expression.AndAlso(Expression.NotEqual(leftExp, Expression.Constant(null)),
                                                            Expression.Call(leftExp, _startsWith, rightExp));
                            break;

                        case LikeTypes.Backward:
                            // 後方一致比較: string.EndsWithメソッドを使用
                            expression = Expression.AndAlso(Expression.NotEqual(leftExp, Expression.Constant(null)),
                                                            Expression.Call(leftExp, _endsWith, rightExp));
                            break;

                        case LikeTypes.Part:
                            // 部分(前後方)一致比較: string.IndexOfメソッドを使用(Containsを使わないのは、将来的なStringComparison指定を見据えて)
                            expression = Expression.AndAlso(Expression.NotEqual(leftExp, Expression.Constant(null)),
                                                            Expression.NotEqual(Expression.Call(leftExp, _indexOf, rightExp), Expression.Constant(-1, typeof(int))));
                            break;

                        case LikeTypes.None:
                            // もしNotだけ指定されていた場合はここに到達。実質単純比較となる。
                            expression = Expression.Equal(leftExp, rightExp);
                            break;

                        default:
                            System.Diagnostics.Debug.Assert(false); // ここに到達したら実装バグ
                            break;
                    }

                    // Not指定がされていたら '==False' で比較判定させる
                    if (condition.Like.HasFlag(LikeTypes.Not))
                    {
                        expression = Expression.Equal(expression, Expression.Constant(false));
                    }
                }

                resultExpList.Add(expression);
            }

            Expression resultExp = resultExpList[0];

            // 比較値が複数ある場合はOrElseで繋げる
            foreach (Expression exp in resultExpList.Skip(1))
            {
                resultExp = Expression.OrElse(resultExp, exp);
            }
            return resultExp;
        }
    }
}
