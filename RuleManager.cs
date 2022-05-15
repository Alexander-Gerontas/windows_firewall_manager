using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using fireWall.Properties;
using Microsoft.Win32;
using NetFwTypeLib;
using Newtonsoft.Json;

namespace fireWall
{
    public class RuleManager
    {
        // listes me olous tous kanones tou fireWall      
        private List<Application> WhiteList = new List<Application>();
        private List<Application> BlackList = new List<Application>();

        private RuleProperties ruleProperties;
        
        private Main _main;

        private SvchostRules svchostRules;

        private Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        private INetFwPolicy2 fwPolicy2;

        public RuleManager(Main main)
        {
            fwPolicy2 = (INetFwPolicy2) Activator.CreateInstance(netFwPolicy2Type);
            this._main = main;
            svchostRules = new SvchostRules();
        }

        public void Add(INetFwRule2 rule)
        {
            bool exists = false;

            if (rule.Action == NET_FW_ACTION_.NET_FW_ACTION_ALLOW)
            {
                foreach (Application superRule in WhiteList)
                {
                    if (superRule.ApplicationName.Equals(rule.ApplicationName))
                    {
                        superRule.Add(rule);
                        exists = true;
                        break;
                    }
                }

                if (exists == false)
                {
                    Application superRule = new Application(rule);
                    WhiteList.Add(superRule);
                }
            }

            else if (rule.Action == NET_FW_ACTION_.NET_FW_ACTION_BLOCK)
            {
                foreach (var rule2 in BlackList)
                {
                    if (rule2.ApplicationName.Equals(rule.ApplicationName))
                    {
                        rule2.Add(rule);
                        exists = true;
                        break;
                    }
                }

                if (exists == false)
                {
                    Application superRule = new Application(rule);
                    BlackList.Add(superRule);
                }
            }
        }

        public void Add(String rule, int allow)
        {
            INetFwRule2 newRule =
                (INetFwRule2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

            newRule.Name = Path.GetFileNameWithoutExtension(rule) + " TCP OutBound Ports";
            newRule.ApplicationName = rule;
            newRule.Enabled = true;
            newRule.Action = (NET_FW_ACTION_) allow;
            newRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            newRule.Description = (allow == 1) ? "Allow outgoing UDP and TCP traffic" : "Always block all traffic";
            newRule.Protocol = 6;
            
            Add(new Rule(newRule).GetINetFwRule());

            newRule.Name = Path.GetFileNameWithoutExtension(rule) + " UDP OutBound Ports";
            newRule.Protocol = 17;
     
            Add(new Rule(newRule).GetINetFwRule());

            _main.Apply();
            SaveRules();
        }

        public void AddRules(List<Application> tempList)
        {
            foreach (Application superRule in tempList)
            {
                foreach (Rule rule in superRule.RuleList)
                {
                    try
                    {
                        fwPolicy2.Rules.Add(rule.GetINetFwRule());
                    }

                    catch
                    {
                        Console.WriteLine("Error adding " + rule.ApplicationName + " firewall rule " +
                                          rule.serviceName);
                    }
                }
            }
        }
        
        public void AddWhitelistRules()
        {
            AddRules(WhiteList);
        }

        public void AddBlacklistRules()
        {
            AddRules(BlackList);
        }

        public void AddSvchostRules()
        {
            AddRules(svchostRules.GetSvchostRules());
        }

        public void ClearWhitelistRules()
        {
            WhiteList.Clear();
        }

        public List<Application> GetWhiteList()
        {
            return WhiteList;
        }

        public List<Application> GetBlackList()
        {
            return BlackList;
        }

        public void ClearBlacklistRules()
        {
            BlackList.Clear();
        }

        public void SetWindowsUpdate(bool enabled)
        {
            svchostRules.SetRuleAction("WindowsUpdate", enabled);
        }

        public void SetDhcpClient(bool enabled)
        {
            svchostRules.SetRuleAction("WindowsDhcp", enabled);
        }

        public void SetDnsClient(bool enabled)
        {
            svchostRules.SetRuleAction("WindowsDns", enabled);
        }

        // Kλείσιμο ειδοποιήσεων του windows firewall
        public void TurnOffFirewallNotifications()
        {
            // Kλείσιμο ειδοποιήσεων του windows firewall
            fwPolicy2.NotificationsDisabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN] = true;
            fwPolicy2.NotificationsDisabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE] = true;
            fwPolicy2.NotificationsDisabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] = true;
        }

        public void ChangeFirewallState(bool enabled)
        {
            // Ενεργοποίηση/Aπενεργοποίηση firewall
            fwPolicy2.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN] = enabled;
            fwPolicy2.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE] = enabled;
            fwPolicy2.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] = enabled;
        }

        public void SetInboundConnections(bool enabled)
        {
            fwPolicy2.DefaultInboundAction[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN] =
                enabled ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            fwPolicy2.DefaultInboundAction[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE] =
                enabled ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            fwPolicy2.DefaultInboundAction[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] =
                enabled ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
        }

        public void SetOutboundConnections(bool enabled)
        {
            fwPolicy2.DefaultOutboundAction[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN] =
                enabled ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            fwPolicy2.DefaultOutboundAction[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE] =
                enabled ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            fwPolicy2.DefaultOutboundAction[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] =
                enabled ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
        }

        // Diagraphi olon ton kanonon tou fireWall
        public void RemoveAllRules()
        {
            foreach (INetFwRule2 rule in fwPolicy2.Rules)
            {
                try
                {
                    fwPolicy2.Rules.Remove(rule.Name);
                }
                catch
                {
                    fwPolicy2.RestoreLocalFirewallDefaults();
                    RemoveAllRules();
                }
            }
        }

        public Application getRule(String str, String action)
        {
            if (action.Equals("allow"))
            {
                foreach (Application rule in WhiteList)
                {
                    if (rule.ApplicationName.Equals(str)) return rule;
                }
            }

            else if (action.Equals("block"))
            {
                foreach (Application rule in BlackList)
                {
                    if (rule.ApplicationName.Equals(str)) return rule;
                }
            }

            throw new InvalidOperationException();
        }

        public void RemoveFromWhiteList(DataGridView WhiteList)
        {
            foreach (DataGridViewRow item in WhiteList.SelectedRows)
            {
                for (int i = 0; i < this.WhiteList.Count; i++)
                    if (item.Cells[1].Value != null && this.WhiteList[i].ApplicationName.Equals(item.Cells[1].Value))
                    {
                        this.WhiteList.RemoveAt(i--);
                    }

                WhiteList.Rows.RemoveAt(item.Index);
            }
        }

        public void RemoveFromBlackList(DataGridView BlackList)
        {
            foreach (DataGridViewRow item in BlackList.SelectedRows)
            {
                for (int i = 0; i < this.BlackList.Count; i++)
                    if (item.Cells[1].Value != null && this.BlackList[i].ApplicationName.Equals(item.Cells[1].Value))
                    {
                        this.BlackList.RemoveAt(i--);
                    }

                BlackList.Rows.RemoveAt(item.Index);
            }
        }

        public void modifyRule(Application rule, bool allow)
        {
            ruleProperties = new RuleProperties(rule);

            // to cancel as kleinei apla to parathiro
            if (ruleProperties.ShowDialog() == DialogResult.OK)
            {
                Application modRule = ruleProperties.GetRule();

                if (allow) RemoveFromWhiteList(_main.exceptionGrid);
                else if (!allow) RemoveFromBlackList(_main.blackGrid);

                for (int i = 0; i < modRule.RuleList.Count; i++)
                    Add(modRule.RuleList[i].GetINetFwRule());
            }
        }

        public void SaveRules()
        {
            Settings.Default.StringRuleList.Clear();
            Settings.Default.StringRuleList = new List<string>();

            foreach (Application path in WhiteList)
            foreach (Rule rule in path.RuleList)
                Settings.Default.StringRuleList.Add(JsonConvert.SerializeObject(rule));

            foreach (Application superRule in BlackList)
            foreach (Rule rule in superRule.RuleList)
                Settings.Default.StringRuleList.Add(JsonConvert.SerializeObject(rule));

            Settings.Default.Save();
        }
    }
}