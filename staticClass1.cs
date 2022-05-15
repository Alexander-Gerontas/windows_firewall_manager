using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;

namespace fireWall
{
    class staticClass1
    {
        private Rule rule = new Rule();

        public staticClass1(String str, String ruleAction = "allow")
        {
            if (str.Equals("windowsUpdate 1"))
            {
                rule.Name = "Windows Update TCP Outbound Ports";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 6;
                rule.serviceName = "wuauserv";
            }

            if (str.Equals("windowsUpdate 2"))
            {
                rule.Name = "Windows Update TCP Outbound Ports 2";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 6;
                rule.RemotePorts = "443,80";

                // dn thelei service name edo?
            }

            // Windows DNS Client

            if (str.Equals("DNS client TCP")) // 1.
            {
                rule.Name = "[TWPOahoT4GMUEp] DNS client TCP";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 6;
                rule.RemotePorts = "53";
                rule.RemoteAddresses = "DNS";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("DNS client UDP Out")) // 2.
            {
                rule.Name = "[TWPOahoT4GMUEp][out] DNS client UDP";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 17;
                rule.RemotePorts = "53";
                rule.RemoteAddresses = "DNS";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("DNS client UDP In")) // 3.
            {
                rule.Name = "[TWPOahoT4GMUEp][in] DNS client UDP";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                rule.Protocol = 17;
                rule.RemotePorts = "53";
                rule.RemoteAddresses = "DNS";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (client) Out")) // 4.
            {
                rule.Name = "[TWPOahoT4GMUEp][out] LLMNR-UDP (client)";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 17;
                rule.RemotePorts = "5355";
                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (client) In")) // 5.
            {
                rule.Name = "[TWPOahoT4GMUEp][in] LLMNR-UDP (client)";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                rule.Protocol = 17;

                rule.RemotePorts = "5355";

                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (server) Out")) // 6.
            {
                rule.Name = "[TWPOahoT4GMUEp][out] LLMNR-UDP (server)";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                rule.Protocol = 17;
                rule.LocalPorts = "5355";

                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Equals("LLMNR-UDP (server) In")) // 7.
            {
                rule.Name = "[TWPOahoT4GMUEp][in] LLMNR-UDP (server)";
                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                rule.Protocol = 17;
                rule.LocalPorts = "5355";

                rule.RemoteAddresses = "LocalSubnet";
                rule.serviceName = "Dnscache";
            }

            if (str.Contains("DHCP IPv") || str.Contains("UDP Outbound"))
            {
                if (str.Equals("DHCP IPv4 client Out")) rule.Name = "[TWorumSz5pVtaD][out] DHCP IPv4 client";
                else if (str.Equals("DHCP IPv4 client In")) rule.Name = "[TWorumSz5pVtaD][in] DHCP IPv4 client";
                else if (str.Equals("DHCP IPv6 client Out")) rule.Name = "[TWorumSz5pVtaD][out] DHCP IPv6 client";
                else if (str.Equals("DHCP IPv6 client In")) rule.Name = "[TWorumSz5pVtaD][in] DHCP IPv6 client";
                else if (str.Equals("UDP Outbound Ports")) rule.Name = "[TWVBDbtmy3kWm9] UDP Outbound Ports";

                //                Console.WriteLine(Name);

                rule.ApplicationName = "C:\\Windows\\system32\\svchost.exe";
                rule.Enabled = true;
                rule.action = ruleAction.Equals("allow")
                    ? NET_FW_ACTION_.NET_FW_ACTION_ALLOW
                    : NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
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

            if (str.Contains("Block all"))
            {
                if (str.Equals("Block all out"))
                {
                    rule.Name = "[TWZz9j9j5r2oBl] [out] Block all traffic";
                    rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                }

                if (str.Equals("Block all in"))
                {
                    rule.Name = "[TWdTBQO4B6pyXa][in] Block all traffic";
                    rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                }

                rule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                rule.Enabled = true;
                rule.action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            }

            if (str.Contains("Allow Everything"))
            {
                if (str.Equals("Allow Everything 1"))
                {
                    rule.Name = "[TWgk3GiSNvYm4u][out] Allow everything";
                    //location
                    rule.Enabled = true;
                    rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    rule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                }

                if (str.Equals("Allow Everything 2"))
                {
                    rule.Name = "[TWgk3GiSNvYm4u][in] Allow everything";
                    //location
                    rule.Enabled = true;
                    rule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    rule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                }

                rule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            }
        }

        private INetFwRule2 getINetFwRule()
        {
            return rule.GetINetFwRule();
        }

        public static void setRule(String ruleName, String action)
        {
            Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2) Activator.CreateInstance(netFwPolicy2Type);
            
            if (ruleName.Equals("windowsUpdate"))
            {
                fwPolicy2.Rules.Add(new staticClass1("windowsUpdate 1", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("windowsUpdate 2", action).getINetFwRule());
            }

            else if (ruleName.Equals("windowsDHCP"))
            {
                fwPolicy2.Rules.Add(new staticClass1("UDP Outbound Ports", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DHCP IPv6 client In", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DHCP IPv6 client Out", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DHCP IPv4 client In", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DHCP IPv4 client Out", action).getINetFwRule());
            }

            else if (ruleName.Equals("windowsDNS"))
            {
                fwPolicy2.Rules.Add(new staticClass1("LLMNR-UDP (server) In", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("LLMNR-UDP (server) Out", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("LLMNR-UDP (client) In", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("LLMNR-UDP (client) Out", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DNS client UDP In", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DNS client UDP Out", action).getINetFwRule());
                fwPolicy2.Rules.Add(new staticClass1("DNS client TCP", action).getINetFwRule());
            }
        }

        

    }
}
