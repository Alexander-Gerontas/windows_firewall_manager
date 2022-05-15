using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using NetFwTypeLib;
using Newtonsoft.Json;

namespace fireWall
{
    public class Rule
    {
        public String Name;
        public String ApplicationName;
        public bool Enabled;
        public NET_FW_ACTION_ action;
        public NET_FW_RULE_DIRECTION_ direction;
        public int? Profiles;
        public String LocalPorts = "*";
        public String Grouping;
        public String LocalAddresses;
        public String RemoteAddresses;
        public String RemotePorts = "*";
        public int Protocol; // to protocol mporei na antikatastathei me string
        public String serviceName;
        public String Description;

        // mia klasi gia default constructor
        [JsonConstructor]
        public Rule()
        {
        }

        // copy constructor
        public Rule(INetFwRule2 copyRule)
        {
            Name = copyRule.Name;
            ApplicationName = copyRule.ApplicationName;
            Enabled = copyRule.Enabled;
            action = copyRule.Action;
            direction = copyRule.Direction;
            Profiles = copyRule.Profiles;
            LocalPorts = copyRule.LocalPorts;
            Grouping = copyRule.Grouping;
            LocalAddresses = copyRule.LocalAddresses;
            RemoteAddresses = copyRule.RemoteAddresses;
            RemotePorts = copyRule.RemotePorts;
            Protocol = copyRule.Protocol;
            serviceName = copyRule.serviceName;
            Description = copyRule.Description;
        }

        public INetFwRule2 GetINetFwRule()
        {
            INetFwRule2 rule;

            rule = (INetFwRule2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

            rule.Name = Name;
            rule.ApplicationName = ApplicationName;
            rule.Description = Description;
            rule.Enabled = Enabled;
            rule.Action = action;
            rule.Direction = direction;
            if (Profiles.HasValue) rule.Profiles = (int) Profiles;
            rule.Grouping = Grouping;
            rule.LocalAddresses = LocalAddresses;
            if (RemoteAddresses != null) rule.RemoteAddresses = RemoteAddresses;
            rule.Protocol = Protocol;
            if (LocalPorts != null && !LocalPorts.Equals("*")) rule.LocalPorts = LocalPorts;
            if (RemotePorts != null && !RemotePorts.Equals("*")) rule.RemotePorts = RemotePorts;
            rule.serviceName = serviceName;
            
            return rule;
        }
    }
}