using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.Linq.LinqCondition.Supports
{
    /// <summary>
    /// 条件とその連鎖情報を保持するクラス
    /// </summary>
    internal class ConditionWithChainInfo
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="condition">条件</param>
        public ConditionWithChainInfo(Condition condition) { this.Condition = condition; }

        /// <summary>
        /// 条件
        /// </summary>
        public Condition Condition { get; set; }

        /// <summary>
        /// 次の連鎖の接続タイプ
        /// </summary>
        public ChainType Next { get; set; }
    }
}
