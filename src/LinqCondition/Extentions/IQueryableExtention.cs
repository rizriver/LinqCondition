using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RizRiver.Linq.LinqCondition.Utils;

namespace RizRiver.Linq.LinqCondition
{
    /// <summary>
    /// System.Linq.IQueryableの拡張メソッド実装クラス
    /// </summary>
    public static class IQueryableExtention
    {
        /// <summary>
        /// 条件に基づいて値のシーケンスをフィルター処理します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">フィルター処理する System.Linq.IQueryable&lt;T&gt;。</param>
        /// <param name="conditions">条件</param>
        /// <returns>条件を満たす、入力シーケンスの要素を含む System.Linq.IQueryable&lt;T&gt;。</returns>
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, params Condition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return source;
            }

            // 条件を元に式ツリーを組み立て、Whereメソッドを呼び出す
            return source.Where(ExpressionUtil.CreateConditionPredicate<TSource>(conditions));
        }

        /// <summary>
        /// 条件に基づいて値のシーケンスをフィルター処理します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">フィルター処理する System.Linq.IQueryable&lt;T&gt;。</param>
        /// <param name="conditionChain">条件</param>
        /// <returns>条件を満たす、入力シーケンスの要素を含む System.Linq.IQueryable&lt;T&gt;。</returns>
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, ConditionChain conditionChain)
        {
            if (conditionChain.IsEmpty || conditionChain.Groups == null || conditionChain.Groups.Length == 0)
            {
                return source;
            }

            // 条件を元に式ツリーを組み立て、Whereメソッドを呼び出す
            return source.Where(ExpressionUtil.CreateConditionPredicate<TSource>(conditionChain));
        }


        /// <summary>
        /// シーケンスの任意の要素が条件を満たしているかどうかを判断します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">条件を満たしているかどうかをテストする要素を含むシーケンス。</param>
        /// <param name="conditions">条件</param>
        /// <returns>指定された条件でソース シーケンスの要素がテストに合格する場合は true。それ以外の場合は false。</returns>
        public static bool Any<TSource>(this IQueryable<TSource> source, params Condition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return System.Linq.Queryable.Any(source);
            }

            return source.Any(ExpressionUtil.CreateConditionPredicate<TSource>(conditions));
        }

        /// <summary>
        /// シーケンスの任意の要素が条件を満たしているかどうかを判断します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">条件を満たしているかどうかをテストする要素を含むシーケンス。</param>
        /// <param name="conditionChain">条件</param>
        /// <returns>指定された条件でソース シーケンスの要素がテストに合格する場合は true。それ以外の場合は false。</returns>
        public static bool Any<TSource>(this IQueryable<TSource> source, ConditionChain conditionChain)
        {
            if (conditionChain.IsEmpty || conditionChain.Groups == null || conditionChain.Groups.Length == 0)
            {
                return System.Linq.Queryable.Any(source);
            }

            return source.Any(ExpressionUtil.CreateConditionPredicate<TSource>(conditionChain));
        }

        /// <summary>
        /// 条件を満たす、指定されたシーケンス内の要素の数を表す数値を返します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">テストおよびカウントする要素が格納されているシーケンス。</param>
        /// <param name="conditions">条件</param>
        /// <returns>条件を満たす、シーケンス内の要素数を表す数値。</returns>
        public static int Count<TSource>(this IQueryable<TSource> source, params Condition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return System.Linq.Queryable.Count(source);
            }

            return source.Count(ExpressionUtil.CreateConditionPredicate<TSource>(conditions));
        }

        /// <summary>
        /// 条件を満たす、指定されたシーケンス内の要素の数を表す数値を返します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">テストおよびカウントする要素が格納されているシーケンス。</param>
        /// <param name="conditionChain">条件</param>
        /// <returns>条件を満たす、シーケンス内の要素数を表す数値。</returns>
        public static int Count<TSource>(this IQueryable<TSource> source, ConditionChain conditionChain)
        {
            if (conditionChain.IsEmpty || conditionChain.Groups == null || conditionChain.Groups.Length == 0)
            {
                return System.Linq.Queryable.Count(source);
            }

            return source.Count(ExpressionUtil.CreateConditionPredicate<TSource>(conditionChain));
        }
    }
}
