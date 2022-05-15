using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetFwTypeLib;

namespace fireWall
{
    public partial class RuleProperties : Form
    {
        private Application OldRule;
        private Application returnRule;

        private Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        private INetFwPolicy2 fwPolicy2;

        public RuleProperties(Application OldRule)
        {
            InitializeComponent();
            this.OldRule = OldRule;

            fwPolicy2 = (INetFwPolicy2) Activator.CreateInstance(netFwPolicy2Type);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox1.Text = OldRule.ApplicationName;

            if (OldRule.RuleList[0].Description.Equals("Always block all traffic"))
            {
                block.Checked = true;
                block.PerformClick();
            }

            else if (OldRule.RuleList[0].Description.Equals("Allow only specified ports"))
            {
                ports.Checked = true;
                ports.PerformClick();
            }

            else if (OldRule.RuleList[0].Description.Equals("Allow outgoing UDP and TCP traffic"))
            {
                allow.Checked = true;
                allow.PerformClick();
            }

            else if (OldRule.RuleList[0].Description.Equals("Unrestricted UDP and TCP traffic"))
            {
                unrestricted.Checked = true;
                unrestricted.PerformClick();
            }

            else if (OldRule.RuleList[0].Description.Equals("No restrictions"))
            {
                NoRestrictions.Checked = true;
                NoRestrictions.PerformClick();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Rule tempRule = new Rule();

            // 1.
            if (block.Checked)
            {
                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " OutBound Ports";
                tempRule.ApplicationName = OldRule.ApplicationName;
                tempRule.Description = "Always block all traffic";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                tempRule.Enabled = true;
                tempRule.LocalPorts = "*";
                tempRule.RemotePorts = "*";

                returnRule = new Application(tempRule.GetINetFwRule());

                tempRule.Name = System.IO.Path.GetFileNameWithoutExtension(tempRule.ApplicationName) + " InBound Ports";
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;

                returnRule.Add(tempRule.GetINetFwRule());
            }

            // 2.
            else if (ports.Checked)
            {
                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " TCP InBound Ports";
                tempRule.ApplicationName = OldRule.ApplicationName;
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                tempRule.Enabled = true;
                tempRule.Description = "Allow only specified ports";
                tempRule.LocalPorts = localTCP.Text;
                tempRule.RemotePorts = "";
                if (localTCP.Text.Equals("")) tempRule.Enabled = false;

                returnRule = new Application(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " TCP OutBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.Enabled = true;
                tempRule.LocalPorts = "";
                tempRule.RemotePorts = remoteTCP.Text;
                if (remoteTCP.Text.Equals("")) tempRule.Enabled = false;

                returnRule.Add(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " UDP OutBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.Enabled = true;
                tempRule.LocalPorts = "";
                tempRule.RemotePorts = remoteUDP.Text;
                if (remoteUDP.Text.Equals("")) tempRule.Enabled = false;

                returnRule.Add(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " UDP InBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                tempRule.Enabled = true;
                tempRule.LocalPorts = localUDP.Text;
                tempRule.RemotePorts = "";
                if (localUDP.Text.Equals("")) tempRule.Enabled = false;

                returnRule.Add(tempRule.GetINetFwRule());
            }

            // 3.
            else if (allow.Checked)
            {
                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " TCP OutBound Ports";
                tempRule.ApplicationName = OldRule.ApplicationName;
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                tempRule.Enabled = true;
                tempRule.Description = "Allow outgoing UDP and TCP traffic";
                tempRule.LocalPorts = "*";
                tempRule.RemotePorts = "*";

                returnRule = new Application(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " UDP OutBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

                returnRule.Add(tempRule.GetINetFwRule());

                if (!localTCP.Text.Equals(""))
                {
                    tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " TCP InBound Ports";
                    tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                    tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    tempRule.Enabled = true;
                    tempRule.LocalPorts = localTCP.Text;

                    returnRule.Add(tempRule.GetINetFwRule());
                }

                if (!localUDP.Text.Equals(""))
                {
                    tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " UDP InBound Ports";
                    tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                    tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    tempRule.Enabled = true;
                    tempRule.LocalPorts = localUDP.Text;

                    returnRule.Add(tempRule.GetINetFwRule());
                }
            }

            // 4.
            else if (unrestricted.Checked)
            {
                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " TCP InBound Ports";
                tempRule.ApplicationName = OldRule.ApplicationName;
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                tempRule.Enabled = true;
                tempRule.Description = "Unrestricted UDP and TCP traffic";

                returnRule = new Application(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " TCP OutBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;

                returnRule.Add(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " UDP InBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;

                returnRule.Add(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " UDP OutBound Ports";
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;

                returnRule.Add(tempRule.GetINetFwRule());
            }

            else if (NoRestrictions.Checked)
            {
                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " Any OutBound Ports";
                tempRule.ApplicationName = OldRule.ApplicationName;
                tempRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                tempRule.action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                tempRule.Enabled = true;
                tempRule.Description = "No restrictions";

                returnRule = new Application(tempRule.GetINetFwRule());

                tempRule.Name = Path.GetFileNameWithoutExtension(OldRule.ApplicationName) + " Any InBound Ports";
                tempRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;

                returnRule.Add(tempRule.GetINetFwRule());
            }

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Application GetRule()
        {
            return returnRule;
        }

        private void block_CheckedChanged(object sender, EventArgs e)
        {
            allDisabled();
        }

        private void ports_CheckedChanged(object sender, EventArgs e)
        {
            OutTCP.Enabled = true;
            InUDP.Enabled = true;
            OutUDP.Enabled = true;
            InTCP.Enabled = true;

            remoteTCP.Enabled = true;
            remoteUDP.Enabled = true;
            localTCP.Enabled = true;
            localUDP.Enabled = true;

            foreach (var rule2 in OldRule.RuleList)
            {
                if (rule2.Protocol == (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP)
                {
                    if (!rule2.LocalPorts.Equals("*")) localTCP.Text = rule2.LocalPorts;
                    if (!rule2.RemotePorts.Equals("*")) remoteTCP.Text = rule2.RemotePorts;
                }

                else if (rule2.Protocol == (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP)
                {
                    if (!rule2.LocalPorts.Equals("*")) localUDP.Text = rule2.LocalPorts;
                    if (!rule2.RemotePorts.Equals("*")) remoteUDP.Text = rule2.RemotePorts;
                }
            }
        }

        private void allow_CheckedChanged(object sender, EventArgs e)
        {
            OutTCP.Enabled = false;
            InUDP.Enabled = true;
            OutUDP.Enabled = false;
            InTCP.Enabled = true;

            localTCP.Clear();
            localUDP.Clear();

            remoteTCP.Enabled = false;
            remoteUDP.Enabled = false;
            localTCP.Enabled = true;
            localUDP.Enabled = true;

            foreach (var rule2 in OldRule.RuleList)
            {
                if (rule2.Protocol == (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP)
                {
                    if (!rule2.LocalPorts.Equals("*")) localTCP.Text = rule2.LocalPorts;
                    if (!rule2.RemotePorts.Equals("*")) remoteTCP.Text = rule2.RemotePorts;
                }

                else if (rule2.Protocol == (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP)
                {
                    if (!rule2.LocalPorts.Equals("*")) localUDP.Text = rule2.LocalPorts;
                    if (!rule2.RemotePorts.Equals("*")) remoteUDP.Text = rule2.RemotePorts;
                }
            }
        }

        private void unrestricted_CheckedChanged(object sender, EventArgs e)
        {
            allDisabled();
        }

        private void NoRestrictions_CheckedChanged(object sender, EventArgs e)
        {
            allDisabled();
        }

        private void allDisabled()
        {
            InTCP.Enabled = false;
            OutTCP.Enabled = false;
            InUDP.Enabled = false;
            OutUDP.Enabled = false;

            localTCP.Clear();
            remoteTCP.Clear();
            localUDP.Clear();
            remoteUDP.Clear();

            remoteTCP.Enabled = false;
            remoteUDP.Enabled = false;
            localTCP.Enabled = false;
            localUDP.Enabled = false;
        }

        private void localTCP_TextChanged(object sender, EventArgs e)
        {
            Rule testRule = new Rule();

            try
            {
                testRule.Name = "testRule";
                testRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                testRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                testRule.LocalPorts = localTCP.Text;

                fwPolicy2.Rules.Add(testRule.GetINetFwRule());
                ok_button.Enabled = true;
            }
            catch (Exception)
            {
                ok_button.Enabled = false;
            }

            fwPolicy2.Rules.Remove(testRule.Name);
        }

        private void remoteTCP_TextChanged(object sender, EventArgs e)
        {
            Rule testRule = new Rule();
            ;

            try
            {
                testRule.Name = "testRule";
                testRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                testRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                testRule.RemotePorts = remoteTCP.Text;

                fwPolicy2.Rules.Add(testRule.GetINetFwRule());
                ok_button.Enabled = true;
            }
            catch (Exception)
            {
                ok_button.Enabled = false;
            }

            fwPolicy2.Rules.Remove(testRule.Name);
        }

        private void remoteUDP_TextChanged(object sender, EventArgs e)
        {
            Rule testRule = new Rule();

            try
            {
                testRule.Name = "testRule";
                testRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                testRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                testRule.RemotePorts = remoteUDP.Text;

                fwPolicy2.Rules.Add(testRule.GetINetFwRule());
                ok_button.Enabled = true;
            }
            catch (Exception)
            {
                ok_button.Enabled = false;
            }

            fwPolicy2.Rules.Remove(testRule.Name);
        }

        private void localUDP_TextChanged(object sender, EventArgs e)
        {
            Rule testRule = new Rule();

            try
            {
                testRule.Name = "testRule";
                testRule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                testRule.direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                testRule.LocalPorts = localUDP.Text;

                fwPolicy2.Rules.Add(testRule.GetINetFwRule());
                ok_button.Enabled = true;
            }
            catch (Exception)
            {
                ok_button.Enabled = false;
            }

            fwPolicy2.Rules.Remove(testRule.Name);
        }
    }
}