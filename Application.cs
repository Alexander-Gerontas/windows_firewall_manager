using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;

namespace fireWall
{
    public class Application
    {
        public List<Rule> RuleList = new List<Rule>(); 
        public String ApplicationName;

        public Application(INetFwRule2 rule)
        {
            ApplicationName = rule.ApplicationName;
            Add(rule);
        }

        public void Add(INetFwRule2 NewRule)
        {
            RuleList.Add(new Rule(NewRule));
        }

        public void SetAction(bool enabled)
        {
            foreach (Rule rule in RuleList)
            {
                rule.action = enabled 
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            }
        }
    }
}
