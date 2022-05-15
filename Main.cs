using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NetFwTypeLib;
using fireWall.Properties;
using Newtonsoft.Json;
using TradeGrid;

namespace fireWall
{
    public partial class Main : Form
    {
        // metablites firewall
        private Type netFwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        private INetFwPolicy2 fwPolicy2;

        private TrayWindow _trayWindow = new TrayWindow();

        private string mode;

        private RuleManager ruleManager;

        private Dictionary<string, bool> dict = new Dictionary<string, bool>();

        // tha prepei na fortonoun kai oi kenoi kanones
        public Main()
        {
            ruleManager = new RuleManager(this);
            InitializeComponent();

            fwPolicy2 = (INetFwPolicy2) Activator.CreateInstance(netFwPolicy2Type);

            // an to arxeio dn iparxei to dimiourgei
            if (Settings.Default.StringRuleList == null)
            {
                mode = "Whitelist mode";
                label1.Text = "Mode: " + mode;

                Settings.Default.StringRuleList = new List<String>();

                foreach (INetFwRule2 rule in fwPolicy2.Rules)
                {
                    if (rule.ApplicationName != null && !rule.ApplicationName.ToLower().Contains("microsoft") &&
                        !rule.ApplicationName.ToLower().Contains("windows"))
                    {
                        rule.Description = (rule.Action == NET_FW_ACTION_.NET_FW_ACTION_ALLOW)
                            ? "Allow outgoing UDP and TCP traffic"
                            : "Always block all traffic";

                        Settings.Default.StringRuleList.Add(JsonConvert.SerializeObject(new Rule(rule)));
                        ruleManager.Add(rule);
                    }
                }

                dict.Add("windonsUpdateCheckBox", false);
                dict.Add("windowsDhcpClientCheckBox", false);
                dict.Add("windowsDnsClientCheckBox", false);

                Settings.Default.checkBoxDictionary = JsonConvert.SerializeObject(dict);
                Settings.Default.Mode = "Whitelist mode";

                // enable dns for internet connection
                windowsDhcpClientCheckBox.Checked = true;
                windowsDnsClientCheckBox.Checked = true;

                Settings.Default.Save();
            }

            // diabasma rithmiseon apo to arxeio
            else
            {
                mode = Settings.Default.Mode;
                label1.Text = "Mode: " + mode;

                Console.WriteLine("file not missing");

                foreach (var rule in Settings.Default.StringRuleList)
                {
                    Rule ruleY = JsonConvert.DeserializeObject<Rule>(rule);
                    ruleManager.Add(ruleY.GetINetFwRule());
                }

                dict =
                    JsonConvert.DeserializeObject<Dictionary<string, bool>>(Settings.Default
                        .checkBoxDictionary);

                windonsUpdateCheckBox.Checked = dict["windonsUpdateCheckBox"];
                windowsDhcpClientCheckBox.Checked = dict["windowsDhcpClientCheckBox"];
                windowsDnsClientCheckBox.Checked = dict["windowsDnsClientCheckBox"];
            }

            // Ikonidio tray
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Visible = true;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            Apply();
        }

        // isos na tairiaze perisotero ston constructor
        private void Form1_Load(object sender, EventArgs e)
        {
//            this.ShowInTaskbar = false;

            RefreshFunc("exceptionGrid");
            RefreshFunc("blackGrid");

            exceptionGrid.ClearSelection();
            blackGrid.ClearSelection();
        }

        public void Apply()
        {
            // Diagraphi olon ton kanonon tou fireWall
            ruleManager.RemoveAllRules();

            Settings.Default.StringRuleList = new List<String>();

            // perasma checkbox sto arxeio
            dict["windonsUpdateCheckBox"] = windonsUpdateCheckBox.Checked;
            dict["windowsDhcpClientCheckBox"] = windowsDhcpClientCheckBox.Checked;
            dict["windowsDnsClientCheckBox"] = windowsDnsClientCheckBox.Checked;

            // apothikeusi arxeiou
            Settings.Default.checkBoxDictionary = JsonConvert.SerializeObject(dict);
            Settings.Default.Mode = mode;
            ruleManager.SaveRules();

            ruleManager.ChangeFirewallState(true);
            ruleManager.TurnOffFirewallNotifications();

            if (mode.Equals("Whitelist mode"))
            {
                label1.Text = "Mode: " + mode;

                ruleManager.AddWhitelistRules();
                ruleManager.AddBlacklistRules();

                ruleManager.SetInboundConnections(false);
                ruleManager.SetOutboundConnections(false);

                this.Icon = Resources._139762;
                notifyIcon1.Icon = Resources._139762;
                contextMenuStrip1.Items[0].Image = Resources.firewall;

                checkboxFunc();
            }

            else if (mode.Equals("Blacklist mode"))
            {
                label1.Text = "Mode: " + mode;

                ruleManager.AddWhitelistRules();
                ruleManager.AddBlacklistRules();

                ruleManager.SetInboundConnections(false);
                ruleManager.SetOutboundConnections(true);

                this.Icon = Resources.firewallblack;
                notifyIcon1.Icon = Resources.firewallblack;
                contextMenuStrip1.Items[0].Image = Resources.disable161;

                checkboxFunc();
            }

            else if (mode.Equals("Block all"))
            {
                label1.Text = "Mode: " + mode;

                ruleManager.SetInboundConnections(false);
                ruleManager.SetOutboundConnections(false);

                this.Icon = Resources.lock22;
                notifyIcon1.Icon = Resources.lock22;
                contextMenuStrip1.Items[0].Image = Resources.lock1;
            }

            else if (mode.Equals("Firewall is Disabled"))
            {
                label1.Text = "Mode: " + mode;
                ruleManager.ChangeFirewallState(false);

                this.Icon = Resources.error_this;
                notifyIcon1.Icon = Resources.error_this;
                contextMenuStrip1.Items[0].Image = Resources.error;
            }

            RefreshFunc("exceptionGrid");
            RefreshFunc("blackGrid");
        }
        public void checkboxFunc()
        {
            // PRosthiki windows update stin lista
            ruleManager.SetWindowsUpdate(windonsUpdateCheckBox.Checked);
            ruleManager.SetDhcpClient(windowsDhcpClientCheckBox.Checked);
            ruleManager.SetDnsClient(windowsDnsClientCheckBox.Checked);
            ruleManager.AddSvchostRules();
        }

        private void WhiteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "Whitelist mode";
            Apply();
        }

        private void BlockListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "Blacklist mode";
            Apply();
        }

        private void blockAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = "Block all";
            Apply();
        }

        private void DisableFirewallState(object sender, EventArgs e)
        {
            mode = "Firewall is Disabled";
            Apply();
        }

        // Bαζει στο fw τα rules στο special expeptions tab
        

        // afairesi 1-n kanonon apo to firewall -- stable
        private void removeButton_Click(object sender, EventArgs e)
        {
            // auti i metabliti dimiourgithike gia tin anafora mono
            DataGridView dat = new DataGridView();
            ref DataGridView dataGridView = ref dat;

            if (tabControl1.SelectedTab == whiteTab)
            {
                dataGridView = exceptionGrid;
                ruleManager.RemoveFromWhiteList(dataGridView);
            }

            else if (tabControl1.SelectedTab == blackTab)
            {
                dataGridView = blackGrid;
                ruleManager.RemoveFromBlackList(dataGridView);
            }

            dataGridView.ClearSelection();

            Apply();
        }

        // prosthiki arxeiou sta expections tou fireWall
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "exe files (*.exe)|*.exe";
            dialog.InitialDirectory = @"C:\Program Files\";

            // ανοιγουμε dialog
            if (dialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                string file = dialog.FileName;

                try
                {
                    // βαζουμε το προγραμμα στο ruleManager
                    if (tabControl1.SelectedTab == whiteTab)
                        ruleManager.Add(file, 1);
                    else
                        ruleManager.Add(file, 0);
                }
                catch (IOException)
                {
                }
            }

            // παταμε apply
            Apply();

            // refresh και τις 2 λιστες
            RefreshFunc("exceptionGrid");
            RefreshFunc("blackGrid");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = whiteTab;
            exceptionGrid.ClearSelection();

            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            ShowInTaskbar = true;
        }

        // afairesi olon ton kanonon exceptionlist/blocklist -- stable
        private void removeAll_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == whiteTab)
            {
                exceptionGrid.Rows.Clear();
                ruleManager.ClearWhitelistRules();
            }

            else if (tabControl1.SelectedTab == blackTab)
            {
                blackGrid.Rows.Clear();
                ruleManager.ClearBlacklistRules();
            }
        }

        private void RefreshFunc(String str)
        {
            // auti i metabliti dimiourgithike gia tin anafora mono
            DataGridView dat = new DataGridView();
            ref DataGridView grid = ref dat;

            // patenta prepei na figoun
            List<Application> RuleList = new List<Application>();

            if (str.Equals("exceptionGrid"))
            {
                grid = exceptionGrid;
                RuleList = ruleManager.GetWhiteList();
            }

            else if (str.Equals("blackGrid"))
            {
                grid = blackGrid;
                RuleList = ruleManager.GetBlackList();
            }

            grid.DataSource = null;
            grid.Rows.Clear();

            // perasma eksereseon sto dataGridView kai sto RuleList
            foreach (Application rule in RuleList)
            {
                if (rule.RuleList[0].Description == "Always block all traffic")
                    grid.Rows.Add(
                        " " + Path.GetFileNameWithoutExtension(rule.ApplicationName) + " InBound/OutBound Ports",
                        rule.ApplicationName);

                else if (rule.RuleList[0].Description == "Allow only specified ports")
                    grid.Rows.Add(
                        " " + Path.GetFileNameWithoutExtension(rule.ApplicationName) +
                        " TCP/UDP InBound/OutBound Ports", rule.ApplicationName);

                else if (rule.RuleList[0].Description == "Allow outgoing UDP and TCP traffic")
                    grid.Rows.Add(
                        " " + Path.GetFileNameWithoutExtension(rule.ApplicationName) +
                        " TCP/UDP InBound/OutBound Ports", rule.ApplicationName);

                else if (rule.RuleList[0].Description == "Unrestricted UDP and TCP traffic")
                    grid.Rows.Add(
                        " " + Path.GetFileNameWithoutExtension(rule.ApplicationName) +
                        " TCP/UDP InBound/OutBound Ports", rule.ApplicationName);

                else if (rule.RuleList[0].Description == "No restrictions")
                    grid.Rows.Add(
                        " " + Path.GetFileNameWithoutExtension(rule.ApplicationName) + " Any InBound/OutBound Ports",
                        rule.ApplicationName);
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (File.Exists(row.Cells[1].Value.ToString()))
                    ((TextAndImageCell) row.Cells[0]).Image = new Bitmap(
                        Icon.ExtractAssociatedIcon(row.Cells[1].Value.ToString()).ToBitmap(), new Size(20, 20));
                ;
            }

            if (grid.Rows.Count > 0) grid.Sort(grid.Columns[0], ListSortDirection.Ascending);

            grid.ClearSelection();
        }

        // tray icon left click -- 
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_trayWindow.Visible)
                {
                    _trayWindow.Hide();
                }

                else if (!_trayWindow.Visible)
                {
                    // perasma metabliton sto _trayWindow
                    _trayWindow.setRuleList(ruleManager);
                    _trayWindow.refresh_Click(null, null);
                    _trayWindow.Show();
                    _trayWindow.TopMost = true;
                    _trayWindow.TopMost = false;
                }
            }

            Settings.Default.Save();
        }

        // Close Button 
        private void close_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            string x;
            Application rule = null;

            if (tabControl1.SelectedTab == whiteTab)
            {
                x = exceptionGrid.SelectedRows[0].Cells[1].Value.ToString();
                rule = ruleManager.getRule(x, "allow");
                ruleManager.modifyRule(rule, true);
                exceptionGrid.ClearSelection();
            }

            if (tabControl1.SelectedTab == blackTab)
            {
                x = blackGrid.SelectedRows[0].Cells[1].Value.ToString();
                rule = ruleManager.getRule(x, "block");
                ruleManager.modifyRule(rule, false);
                blackGrid.ClearSelection();
            }

            Apply();
        }

        // Overide Window Closing -- working
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                close_Click(null, null);
            }
        }

        // Oταν αλλαζει το tab
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            modifyButton.Enabled = false;
            modifyButtonBlacklist.Enabled = false;

            removeButton.Enabled = false;
            removeButton2.Enabled = false;

            exceptionGrid.ClearSelection();
            blackGrid.ClearSelection();
        }

        private void exceptionGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (exceptionGrid.Rows.Count > 0) removeAll.Enabled = true;
            if (blackGrid.Rows.Count > 0) removeAll_BlockList.Enabled = true;
        }

        private void blockGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (exceptionGrid.Rows.Count == 0) removeAll.Enabled = false;
            if (blackGrid.Rows.Count == 0) removeAll_BlockList.Enabled = false;
        }

        private void windonsUpdateCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            Apply();
        }

        private void windowsDnsClientCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            Apply();
        }

        private void windowsDhcpClientCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            Apply();
        }

        // Οταν ο χρηστης πατησει το κουμπι delete
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tabControl1.SelectedTab == whiteTab && removeButton.Enabled)
                {
                    removeButton.PerformClick();
                }

                if (tabControl1.SelectedTab == blackTab && removeButton2.Enabled)
                {
                    removeButton2.PerformClick();
                }
            }
        }

        // Oταν ο χρηστης επιλεγει γραμμες
        private void exceptionGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == whiteTab)
            {
                if (exceptionGrid.SelectedRows.Count == 0)
                {
                    modifyButton.Enabled = false;
                    removeButton.Enabled = false;
                }

                else if (exceptionGrid.SelectedRows.Count > 0)
                {
                    if (exceptionGrid.SelectedRows.Count == 1) modifyButton.Enabled = true;
                    else modifyButton.Enabled = false;
                    removeButton.Enabled = true;
                }
            }

            else if (tabControl1.SelectedTab == blackTab)
            {
                if (blackGrid.SelectedRows.Count == 0)
                {
                    modifyButtonBlacklist.Enabled = false;
                    removeButton2.Enabled = false;
                }

                else if (blackGrid.SelectedRows.Count > 0)
                {
                    if (blackGrid.SelectedRows.Count == 1) modifyButtonBlacklist.Enabled = true;
                    else modifyButtonBlacklist.Enabled = false;
                    removeButton2.Enabled = true;
                }
            }
        }
    }
}