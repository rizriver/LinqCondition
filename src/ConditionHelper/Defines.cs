using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.ConditionHelper
{
    /// <summary>
    /// 比較方法
    /// </summary>
    public enum CompareType
    {
        /// <summary>
        /// 等価比較
        /// </summary>
        Equal,
        /// <summary>
        /// 非等価比較
        /// </summary>
        NotEqual,
        /// <summary>
        /// "小なり" 数値比較
        /// </summary>
        LessThan,
        /// <summary>
        /// "以下" 数値比較
        /// </summary>
        LessThanOrEqual,
        /// <summary>
        /// "大なり" 数値比較
        /// </summary>
        GreaterThan,
        /// <summary>
        /// "以上" 数値比較
        /// </summary>
        GreaterThanOrEqual
    }

    /// <summary>
    /// Like指定
    /// </summary>
    [Flags]
    public enum LikeTypes
    {
        /// <summary>
        /// 完全一致
        /// </summary>
        None = 0,
        /// <summary>
        /// 前方一致
        /// </summary>
        Forward = 0x0001,
        /// <summary>
        /// 後方一致
        /// </summary>
        Backward = 0x0002,
        /// <summary>
        /// 部分一致
        /// </summary>
        Part = Forward | Backward,
        /// <summary>
        /// 否定
        /// </summary>
        Not = 0x0008
    }

    /// <summary>
    /// 連鎖タイプ
    /// </summary>
    public enum ChainType
    {
        /// <summary>
        /// AndAlso
        /// </summary>
        AndAlso,
        /// <summary>
        /// OrElse
        /// </summary>
        OrElse,
    }
}
