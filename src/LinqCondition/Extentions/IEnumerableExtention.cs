using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RizRiver.Linq.LinqCondition.Utils;

namespace RizRiver.Linq.LinqCondition
{
    /// <summary>
    /// System.Collections.Generic.IEnumerableの拡張メソッド実装クラス
    /// </summary>
    public static class IEnumerableExtention
    {
        /// <summary>
        /// 条件に基づいて値のシーケンスをフィルター処理します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">フィルター処理する System.Collections.Generic.IEnumerable&lt;T&gt;。</param>
        /// <param name="conditions">条件</param>
        /// <returns>条件を満たす、入力シーケンスの要素を含む System.Collections.Generic.IEnumerable&lt;T&gt;。</returns>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, params Condition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return source;
            }

            return source.Where(ExpressionUtil.CreateConditionPredicate<TSource>(conditions).Compile());
        }

        /// <summary>
        /// 条件に基づいて値のシーケンスをフィルター処理します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">フィルター処理する System.Collections.Generic.IEnumerable&lt;T&gt;。</param>
        /// <param name="conditionChain">条件</param>
        /// <returns>条件を満たす、入力シーケンスの要素を含む System.Collections.Generic.IEnumerable&lt;T&gt;。</returns>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, ConditionChain conditionChain)
        {
            //if (conditionChain.IsEmpty || conditionChain.Groups == null || conditionChain.Groups.Length == 0)
            //{
            //    return source;
            //}

            return source.Where(ExpressionUtil.CreateConditionPredicate<TSource>(conditionChain).Compile());
        }

        /// <summary>
        /// シーケンスの任意の要素が条件を満たしているかどうかを判断します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">述語を適用する要素を含む System.Collections.Generic.IEnumerable&lt;T&gt;。</param>
        /// <param name="conditions">条件</param>
        /// <returns>指定された条件でソース シーケンスの要素がテストに合格する場合は true。それ以外の場合は false。</returns>
        public static bool Any<TSource>(this IEnumerable<TSource> source, params Condition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return System.Linq.Enumerable.Any(source);
            }

            return source.Any(ExpressionUtil.CreateConditionPredicate<TSource>(conditions).Compile());
        }

        /// <summary>
        /// シーケンスの任意の要素が条件を満たしているかどうかを判断します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">述語を適用する要素を含む System.Collections.Generic.IEnumerable&lt;T&gt;。</param>
        /// <param name="conditionChain">条件</param>
        /// <returns>指定された条件でソース シーケンスの要素がテストに合格する場合は true。それ以外の場合は false。</returns>
        public static bool Any<TSource>(this IEnumerable<TSource> source, ConditionChain conditionChain)
        {
            //if (conditionChain.IsEmpty || conditionChain.Groups == null || conditionChain.Groups.Length == 0)
            //{
            //    return System.Linq.Enumerable.Any(source);
            //}

            return source.Any(ExpressionUtil.CreateConditionPredicate<TSource>(conditionChain).Compile());
        }

        /// <summary>
        /// 条件を満たす、指定されたシーケンス内の要素の数を表す数値を返します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">テストおよびカウントする要素が格納されているシーケンス。</param>
        /// <param name="conditions">条件</param>
        /// <returns>条件を満たす、シーケンス内の要素数を表す数値。</returns>
        public static int Count<TSource>(this IEnumerable<TSource> source, params Condition[] conditions)
        {
            if (conditions == null || conditions.Length == 0)
            {
                return System.Linq.Enumerable.Count(source);
            }

            return source.Count(ExpressionUtil.CreateConditionPredicate<TSource>(conditions).Compile());
        }

        /// <summary>
        /// 条件を満たす、指定されたシーケンス内の要素の数を表す数値を返します。
        /// </summary>
        /// <typeparam name="TSource">source の要素の型</typeparam>
        /// <param name="source">テストおよびカウントする要素が格納されているシーケンス。</param>
        /// <param name="conditionChain">条件</param>
        /// <returns>条件を満たす、シーケンス内の要素数を表す数値。</returns>
        public static int Count<TSource>(this IEnumerable<TSource> source, ConditionChain conditionChain)
        {
            //if (conditionChain.IsEmpty || conditionChain.Groups == null || conditionChain.Groups.Length == 0)
            //{
            //    return System.Linq.Enumerable.Count(source);
            //}

            return source.Count(ExpressionUtil.CreateConditionPredicate<TSource>(conditionChain).Compile());
        }
    }
}
