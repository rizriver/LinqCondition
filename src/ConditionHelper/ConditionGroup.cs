using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.ConditionHelper
{
    public class ConditionGroup : ICondition
    {
        public ConditionGroup() : this(null) { }
        
        public ConditionGroup(ICondition baseCondition)
        {
            this.GroupList = new List<Tuple<ICondition, ChainType>>();
            if (baseCondition != null)
            {
                this.GroupList.Add(Tuple.Create(baseCondition, default(ChainType)));
            }
        }
        
        internal List<Tuple<ICondition, ChainType>> GroupList { get; set; }


        public void AddCondition(ICondition condition, ChainType chainType)
        {
            this.GroupList.Add(Tuple.Create(condition, chainType));
        }
        public void AndAlso(ICondition condition)
        {
            this.GroupList.Add(Tuple.Create(condition, ChainType.AndAlso));
        }
        public void OrElse(ICondition condition)
        {
            this.GroupList.Add(Tuple.Create(condition, ChainType.OrElse));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(this.GroupList.Count > 1 ? "(" : string.Empty);
            for (int i = 0; i < this.GroupList.Count; i++)
            {
                var current = this.GroupList[i];
                if (i != 0)
                {
                    sb.Append(current.Item2 == ChainType.OrElse ? " OR " : " AND ");
                }

                sb.Append(current.Item1.ToString());
            }
            sb.Append(this.GroupList.Count > 1 ? ")" : string.Empty);
            return sb.ToString();
        }
    }
}
