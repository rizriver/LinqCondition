using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.Linq.LinqCondition.Supports
{
    /// <summary>
    /// 条件連鎖情報のグループクラス
    /// </summary>
    internal class ConditionWithChainInfoGroup
    {
        /// <summary>
        /// 条件リスト
        /// </summary>
        private List<ConditionWithChainInfo> _conditionList = new List<ConditionWithChainInfo>();

        /// <summary>
        /// このグループが管理している条件群を取得する
        /// </summary>
        public ConditionWithChainInfo[] Conditions { get { return _conditionList.ToArray(); } }

        /// <summary>
        /// 次の連鎖の接続タイプ
        /// </summary>
        public ChainType Next { get; set; }

        /// <summary>
        /// このグループに、AndAlso演算として条件を追加する
        /// </summary>
        /// <param name="condition">条件</param>
        public void AddAndAlso(Condition condition)
        {
            if (_conditionList.Count > 0)
            {
                _conditionList.Last().Next = ChainType.AndAlso;
            }

            _conditionList.Add(new ConditionWithChainInfo(condition));
        }

        /// <summary>
        /// このグループに、OrElse演算として条件を追加する
        /// </summary>
        /// <param name="condition">条件</param>
        public void AddOrElse(Condition condition)
        {
            if (_conditionList.Count > 0)
            {
                _conditionList.Last().Next = ChainType.OrElse;
            }

            _conditionList.Add(new ConditionWithChainInfo(condition));
        }
    }
}
