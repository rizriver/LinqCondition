using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.ConditionHelper
{
    /// <summary>
    /// 条件を表現するクラス
    /// </summary>
    [Serializable]
    public class Condition : ICondition
    {
        /// <summary>
        /// 項目名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 値
        /// </summary>
        public object[] Values { get; private set; }
        /// <summary>
        /// 比較方法
        /// </summary>
        public CompareType CompareType { get; set; }
        /// <summary>
        /// Like指定
        /// </summary>
        public LikeTypes Like { get; set; }

        /// <summary>
        /// プライベート コンストラクタ
        /// </summary>
        /// <param name="name">項目名</param>
        /// <param name="values">比較判定する値。複数指定した時は、それぞれの値でのOrElse比較となる</param>
        private Condition(string name, params object[] values)
        {
            this.Name = name;
            this.Values = values;
            this.CompareType = CompareType.Equal;
            this.Like = LikeTypes.None;
        }

        /// <summary>
        /// 新しいConditionインスタンスを生成する
        /// </summary>
        /// <param name="name">項目名</param>
        /// <param name="value">比較判定する値</param>
        /// <returns>生成されたConditionインスタンス</returns>
        public static Condition Create(string name, object value)
        {
            return new Condition(name, value);
        }

        /// <summary>
        /// 新しいConditionインスタンスを生成する
        /// </summary>
        /// <param name="name">項目名</param>
        /// <param name="values">比較判定する値。複数指定した時は、それぞれの値でのOrElse比較となる</param>
        /// <returns>生成されたConditionインスタンス</returns>
        public static Condition Create(string name, object[] values)
        {
            return new Condition(name, values);
        }

        /// <summary>
        /// 新しいConditionインスタンスを生成する
        /// </summary>
        /// <param name="name">項目名</param>
        /// <param name="value">比較判定する値</param>
        /// <param name="compareType">比較判定方法</param>
        /// <returns>生成されたConditionインスタンス</returns>
        public static Condition Create(string name, object value, CompareType compareType)
        {
            return new Condition(name, value) { CompareType = compareType };
        }

        /// <summary>
        /// 新しいConditionインスタンスを生成する
        /// </summary>
        /// <param name="name">項目名</param>
        /// <param name="value">比較判定する値</param>
        /// <param name="likeType">Like判定方法</param>
        /// <returns>生成されたConditionインスタンス</returns>
        public static Condition Create(string name, object value, LikeTypes likeType)
        {
            return new Condition(name, value) { Like = likeType };
        }

        public override string ToString()
        {
            Func<CompareType, string> getOp = c =>
            {
                switch (c)
                {
                    case CompareType.Equal:
                        return "==";
                    case CompareType.NotEqual:
                        return "!=";
                    case CompareType.GreaterThan:
                        return ">";
                    case CompareType.GreaterThanOrEqual:
                        return ">=";
                    case CompareType.LessThan:
                        return "<";
                    case CompareType.LessThanOrEqual:
                        return "<=";
                }
                return null;
            };

            StringBuilder sb = new StringBuilder();
            sb.Append(this.Values.Length > 1 ? "(" : string.Empty);
            foreach (var value in this.Values)
            {
                sb.Append("[").Append(this.Name).Append("]");

                if (this.Like == LikeTypes.None)
                {
                    sb.Append(getOp(this.CompareType));
                    sb.Append(value);
                }
                else
                {
                    sb.Append(" LIKE ");
                    if ((this.Like ^ LikeTypes.Forward) == LikeTypes.Forward)
                    {
                        sb.Append("%");
                    }
                    sb.Append(value);
                    if ((this.Like ^ LikeTypes.Backward) == LikeTypes.Backward)
                    {
                        sb.Append("%");
                    }
                    if (this.Like.HasFlag(LikeTypes.Not))
                    {
                        sb.Append(" == FALSE");
                    }
                }
            }
            sb.Append(this.Values.Length > 1 ? ")" : string.Empty);
            return sb.ToString();
        }
    }
}
