using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.Linq.LinqCondition
{
    public class ConditionGroup : ICondition
    {
        public ConditionGroup() : this(null) { }

        public ConditionGroup(ICondition baseCondition)
        {
            this.GroupList = new List<Tuple<ICondition, ChainType>>();
            if (baseCondition != null)
            {
                this.GroupList.Add(Tuple.Create<ICondition, ChainType>(baseCondition, ChainType.AndAlso));
            }
        }
        
        public List<Tuple<ICondition, ChainType>> GroupList { get; set; }


        public void AddChild(ICondition child, ChainType chainType)
        {
            this.GroupList.Add(Tuple.Create<ICondition, ChainType>(child, chainType));
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.GroupList.Count; i++)
            {
                var current = this.GroupList[i];
                if (i != 0)
                {
                    sb.Append(current.Item2 == ChainType.OrElse ? " OR " : " AND ");
                }

                sb.Append("(").Append(current.Item1.ToString()).Append(")");

            }
            return sb.ToString();
        }
    }
}
