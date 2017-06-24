using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using RizRiver.Linq.LinqCondition.Utils;
using RizRiver.Linq.LinqCondition.Supports;

namespace RizRiver.Linq.LinqCondition
{
    /// <summary>
    /// 条件の連鎖を表すクラス
    /// </summary>
    [Serializable]
    public class ConditionChain
    {
        //private List<ConditionWithChainInfoGroup> _conditionGroupList;

        ///// <summary>
        ///// このインスタンスが管理する条件グループ群を取得する
        ///// </summary>
        //internal ConditionWithChainInfoGroup[] Groups { get { return _conditionGroupList.ToArray(); } }

        public ConditionGroup ConditionGroup { get; private set; }

        /// <summary>
        /// プライベート コンストラクタ
        /// </summary>
        private ConditionChain()
        {
            //_conditionGroupList = new List<ConditionWithChainInfoGroup>();
        }

        /// <summary>
        /// プライベート コンストラクタ
        /// </summary>
        /// <param name="condition">条件</param>
        private ConditionChain(Condition condition)
        {
            this.ConditionGroup = new ConditionGroup(condition);
            //_conditionGroupList = new List<ConditionWithChainInfoGroup>();
            //_conditionGroupList.Add(new ConditionWithChainInfoGroup());
            //_conditionGroupList.Last().AddAndAlso(condition);
        }

        /// <summary>
        /// 空のConditionChain取得する。
        /// </summary>
        public static ConditionChain Empty { get { return new ConditionChain(); } }

        /// <summary>
        /// 空の条件が保持されているかどうかを取得する
        /// </summary>
        public bool IsEmpty { get { return this.ConditionGroup == null;/*return _conditionGroupList.Count == 0;*/ } }

        /// <summary>
        /// ConditionChainインスタンスを生成する
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns>生成されたConditionChainインスタンス</returns>
        public static ConditionChain Create(Condition condition)
        {
            ConditionChain result = new ConditionChain(condition);
            return result;
        }

        /// <summary>
        /// 条件をAndAlso演算として結合する
        /// </summary>
        /// <param name="condition">結合するConditionインスタンス</param>
        /// <returns>結合した結果のConditionChainインスタンス</returns>
        public ConditionChain AndAlso(Condition condition)
        {
            if (this.IsEmpty)
            {
                this.ConditionGroup = new ConditionGroup(condition);
            }
            else
            {
                this.ConditionGroup.AddChild(condition, ChainType.AndAlso);
            }
            return this;
        }

        /// <summary>
        /// 条件をOrElse演算として結合する
        /// </summary>
        /// <param name="condition">結合するConditionインスタンス</param>
        /// <returns>結合した結果のConditionChainインスタンス</returns>
        public ConditionChain OrElse(Condition condition)
        {
            if (this.IsEmpty)
            {
                this.ConditionGroup = new ConditionGroup(condition);
            }
            else
            {
                this.ConditionGroup.AddChild(condition, ChainType.OrElse);
            }
            return this;
        }

        /// <summary>
        /// 条件連鎖をAndAlso演算として結合する
        /// </summary>
        /// <param name="conditionChain">結合するConditionChainインスタンス</param>
        /// <returns>結合した結果のConditionChainインスタンス</returns>
        public ConditionChain AndAlso(ConditionChain conditionChain)
        {
            if (this.IsEmpty)
            {
                this.ConditionGroup = new ConditionGroup(conditionChain.ConditionGroup);
            }
            else
            {
                this.ConditionGroup.AddChild(conditionChain.ConditionGroup, ChainType.AndAlso);
            }

            //// 結合しようとするChainが空だった場合は結合しない
            //if (conditionChain.IsEmpty)
            //{
            //    return this;
            //}

            //if (this.IsEmpty)
            //{
            //    _conditionGroupList.Add(conditionChain.Groups.Last());
            //    return this;
            //}

            //_conditionGroupList.Last().Next = ChainType.AndAlso;
            //_conditionGroupList.Add(conditionChain.Groups.Last());
            return this;
        }

        /// <summary>
        /// 条件連鎖をOrElse演算として結合する
        /// </summary>
        /// <param name="conditionChain">結合するConditionChainインスタンス</param>
        /// <returns>結合した結果のConditionChainインスタンス</returns>
        public ConditionChain OrElse(ConditionChain conditionChain)
        {
            if (this.IsEmpty)
            {
                this.ConditionGroup = new ConditionGroup(conditionChain.ConditionGroup);
            }
            else
            {
                this.ConditionGroup.AddChild(conditionChain.ConditionGroup, ChainType.OrElse);
            }
            return this;
        }

        /// <summary>
        /// 現在の条件連鎖情報から生成されるExpressionを取得する
        /// </summary>
        /// <typeparam name="TSource">条件判定を適用する要素の型</typeparam>
        /// <returns>現在の条件連鎖情報から生成されたExpression</returns>
        public Expression<Func<TSource, bool>> GetExpression<TSource>()
        {
            if (this.IsEmpty)
            {
                return null;
            }
            return ExpressionUtil.CreateConditionPredicate<TSource>(this);
        }
    }
}
