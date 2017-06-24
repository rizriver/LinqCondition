using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.Linq.LinqCondition
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
    }
}
