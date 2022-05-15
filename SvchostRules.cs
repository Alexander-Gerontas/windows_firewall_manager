using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;

namespace fireWall
{
    class SvchostRules
    {
        private Application WindowsUpdate;
        private Application WindowsDhcp;
        private Application WindowsDns;
        

        public SvchostRules()
        {
            CreateWindowsUpdate();
            CreateWindowsDhcp();
            CreateWindowsDns();
        }

        private void CreateWindowsUpdate()
        {
            Rule rule = new Rule();

            rule.Name = "Windows Update TCP Outbound Ports";
            rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
            rule.Enabled = true;
            rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            rule.Protocol = 6;
            rule.RemotePorts = "443,80";

            WindowsUpdate = new Application(rule.GetINetFwRule());

            rule.Name = "Windows Update TCP Service Outbound Ports";
            rule.RemotePorts = "*";
            rule.serviceName = "wuauserv";

            WindowsUpdate.Add(rule.GetINetFwRule());
        }

        private void CreateWindowsDhcp()
        {
            WindowsDhcp = new Application(GetDhcpRule("UDP Outbound Ports"));
            WindowsDhcp.Add(GetDhcpRule("DHCP IPv6 client In"));
            WindowsDhcp.Add(GetDhcpRule("DHCP IPv6 client Out"));
            WindowsDhcp.Add(GetDhcpRule("DHCP IPv4 client In"));
            WindowsDhcp.Add(GetDhcpRule("DHCP IPv4 client Out"));
        }

        private void CreateWindowsDns()
        {
            WindowsDns = new Application(GetDnsRule("LLMNR-UDP (server) In"));
            WindowsDns.Add(GetDnsRule("LLMNR-UDP (server) Out"));
            WindowsDns.Add(GetDnsRule("LLMNR-UDP (client) In"));
            WindowsDns.Add(GetDnsRule("LLMNR-UDP (client) Out"));
            WindowsDns.Add(GetDnsRule("DNS client UDP In"));
            WindowsDns.Add(GetDnsRule("DNS client UDP Out"));
            WindowsDns.Add(GetDnsRule("DNS client TCP"));
        }

        private INetFwRule2 GetDhcpRule(String str)
        {
            Rule rule = new Rule();

            if (str.Contains("DHCP IPv") || str.Contains("UDP Outbound"))
            {
                if (str.Equals("DHCP IPv4 client Out")) rule.Name = "DHCP IPv4 client Outbound";
                else if (str.Equals("DHCP IPv4 client In")) rule.Name = "DHCP IPv4 client Inbound";
                else if (str.Equals("DHCP IPv6 client Out")) rule.Name = "DHCP IPv6 client Outbound";
                else if (str.Equals("DHCP IPv6 client In")) rule.Name = "DHCP IPv6 client Inbound";
                else if (str.Equals("UDP Outbound Ports")) rule.Name = "UDP Outbound Ports";
                
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    
                rule.Protocol = 17;

                if (str.Contains("Out")) rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                else if (str.Contains("In")) rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                else rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

                if (str.Contains("IPv4"))
                {
                    rule.LocalPorts = "68";
                    rule.RemotePorts = "67";
                }

                else if (str.Contains("IPv6"))
                {
                    rule.LocalPorts = "546";
                    rule.RemotePorts = "547";
                }

                else rule.RemotePorts = "67";

                if (str.Contains("DHCP")) rule.RemoteAddresses = "LocalSubnet";

                if (str.Contains("DHCP")) rule.serviceName = "dhcp";
                else rule.serviceName = "lmhosts";
            }

            return rule.GetINetFwRule();
        }
        
        public INetFwRule2 GetDnsRule(String str)
        {
            Rule rule = new Rule();

            if (str.Equals("DNS client TCP")) // 1.
            {
                rule.Name = "DNS client TCP Outbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 6;
                rule.RemotePorts = "53";
                rule.RemoteAddresses = "DNS";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("DNS client UDP Out")) // 2.
            {
                rule.Name = "DNS client UDP Outbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 17;
                rule.RemotePorts = "53";
                rule.RemoteAddresses = "DNS";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("DNS client UDP In")) // 3.
            {
                rule.Name = "DNS client UDP Inbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                rule.Protocol = 17;
                rule.RemotePorts = "53";
                rule.RemoteAddresses = "DNS";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (client) Out")) // 4.
            {
                rule.Name = "LLMNR-UDP (client) Outbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 17;
                rule.RemotePorts = "5355";
                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (client) In")) // 5.
            {
                rule.Name = "LLMNR-UDP (client) Inbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                rule.Protocol = 17;
                rule.RemotePorts = "5355";
                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (server) Out")) // 6.
            {
                rule.Name = "LLMNR-UDP (server) Outbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 17;
                rule.LocalPorts = "5355";

                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (server) In")) // 7.
            {
                rule.Name = "LLMNR-UDP (server) Inbound";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                rule.Protocol = 17;
                rule.LocalPorts = "5355";

                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            return rule.GetINetFwRule();
        }

        public void SetRuleAction(String rule, bool enabled)
        {
            if (rule.Equals("WindowsUpdate")) WindowsUpdate.SetAction(enabled);
            else if (rule.Equals("WindowsDhcp")) WindowsDhcp.SetAction(enabled);
            else if (rule.Equals("WindowsDns")) WindowsDns.SetAction(enabled);
        }

        public List<Application> GetSvchostRules()
        {
            List<Application> list = new List<Application>();

            list.Add(WindowsUpdate);
            list.Add(WindowsDhcp);
            list.Add(WindowsDns);

            return list;
        }
    }
}
