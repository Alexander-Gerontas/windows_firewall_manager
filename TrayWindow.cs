using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using NetFwTypeLib;

namespace fireWall
{
    public partial class TrayWindow : Form
    {
        private RuleManager ruleManager;

        // List of Active TCP Connections.
        private static List<TcpProcessRecord> TcpActiveConnections = null;
        
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int pdwSize,
            bool bOrder, int ulAf, TcpTableClass tableClass, uint reserved = 0);

        public TrayWindow()
        {
            InitializeComponent();
        }

        public ListView getList()
        {
            threadFunc(); 
            return listView1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.StartPosition = FormStartPosition.Manual;
            this.SetDesktopLocation(MousePosition.X - this.Width / 2, MousePosition.Y - this.Height - 20);
        }

        public void setRuleList(RuleManager ruleManager)
        {
            this.ruleManager = ruleManager;
        }

        public void refresh_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Path", 500);
            
            new Thread(threadFunc).Start();
        }

        private void threadFunc()
        {
            TcpActiveConnections = NetClass.GetAllTcpConnections();
            Process process;

            // for me sinartisi gia Tcp
            foreach (var tcp in TcpActiveConnections)
            {
                // Proccess of an id is not running -- unhandled exception
                try
                {
                    process = Process.GetProcessById(Int32.Parse(tcp.ProcessId.ToString()));
                    AddToList(process);
                }
                catch
                {
                    // system argument  exception proccess of id is not running
                }
            }
        }

        private void AddToList(Process process)
        {
            //Process process;
            string fullPath = "";

            try
            {
                fullPath = process.MainModule.FileName;
            }

            catch
            {
                string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                foreach (ManagementObject item in searcher.Get())
                {
                    object id = item["ProcessID"];
                    object path = item["ExecutablePath"];

                    if (path != null && id.ToString() == process.Id.ToString())
                    {
                        fullPath = path.ToString();
                    }
                }
            }

            if (fullPath.Equals("")) return;

            bool exists = fullPath.Contains("svchost");

            if (exists == false)
                listView1.Invoke(new MethodInvoker(delegate
                {
                    if (listView1.FindItemWithText(fullPath) != null) exists = true;
                }));


            if (exists == false)
                // new code
                foreach (Application superRule in ruleManager.GetWhiteList())
                    if (superRule.ApplicationName == fullPath)
                    {
                        exists = true;
                        break;
                    }

            if (exists == false)
                foreach (Application rule in ruleManager.GetBlackList())

                    if (rule.ApplicationName == fullPath)
                    {
                        exists = true;
                        break;
                    }


            if (!exists)
            {
                // prostiki stin lista

                ListViewItem itm;
                string[] arr = new string[4];

                arr[0] = fullPath;
                arr[1] = "100";

                itm = new ListViewItem(arr);

                if (listView1.InvokeRequired)
                {
                    listView1.Invoke(new MethodInvoker(delegate { listView1.Items.Add(itm); }));
                }
                else
                {
                    listView1.Items.Add(itm);
                }
            }
        }
        
        private void allow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.CheckedItems.Count; i++)            
                ruleManager.Add(listView1.CheckedItems[i].Text, 1);            
            
            Hide();
        }

        private void block_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.CheckedItems.Count; i++)            
                ruleManager.Add(listView1.CheckedItems[i].Text, 0);            
            
            Hide();
        }

        private void Form2_Leave(object sender, EventArgs e)
        {
            Hide();
        }
    }
}