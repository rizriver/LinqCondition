using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RizRiver.Linq.LinqCondition
{
    public class ConditionGroup : ICondition
    {
        public ConditionGroup(ICondition baseCondition)
        {
            this.GroupList = new List<Tuple<ICondition, ChainType>>();
            this.GroupList.Add(Tuple.Create<ICondition, ChainType>(baseCondition, ChainType.AndAlso));
        }


        public List<Tuple<ICondition, ChainType>> GroupList { get; set; }


        public void AddChild(ICondition child, ChainType chainType)
        {
            this.GroupList.Add(Tuple.Create<ICondition, ChainType>(child, chainType));
        }
        
    }
}
