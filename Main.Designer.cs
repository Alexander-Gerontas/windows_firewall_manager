namespace fireWall
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autolearnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.windowsDhcpClientCheckBox = new System.Windows.Forms.CheckBox();
            this.windowsDnsClientCheckBox = new System.Windows.Forms.CheckBox();
            this.windonsUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.blackTab = new System.Windows.Forms.TabPage();
            this.modifyButtonBlacklist = new System.Windows.Forms.Button();
            this.removeAll_BlockList = new System.Windows.Forms.Button();
            this.removeButton2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.blackGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new TradeGrid.TextAndImageColumn();
            this.dataGridViewTextBoxColumn2 = new TradeGrid.TextAndImageColumn();
            this.whiteTab = new System.Windows.Forms.TabPage();
            this.modifyButton = new System.Windows.Forms.Button();
            this.removeAll = new System.Windows.Forms.Button();
            this.exceptionGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new TradeGrid.TextAndImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.blackTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackGrid)).BeginInit();
            this.whiteTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exceptionGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Guardian";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeModeToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 70);
            // 
            // changeModeToolStripMenuItem
            // 
            this.changeModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.autolearnToolStripMenuItem,
            this.blockAllToolStripMenuItem,
            this.disableToolStripMenuItem1});
            this.changeModeToolStripMenuItem.Name = "changeModeToolStripMenuItem";
            this.changeModeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.changeModeToolStripMenuItem.Text = "Change Mode";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Image = global::fireWall.Properties.Resources.firewall;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.normalToolStripMenuItem.Text = "Whitelist mode";
            this.normalToolStripMenuItem.ToolTipText = "Block all connections to applications that are not in the Whitelist";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.WhiteListToolStripMenuItem_Click);
            // 
            // autolearnToolStripMenuItem
            // 
            this.autolearnToolStripMenuItem.Image = global::fireWall.Properties.Resources.disable161;
            this.autolearnToolStripMenuItem.Name = "autolearnToolStripMenuItem";
            this.autolearnToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.autolearnToolStripMenuItem.Text = "Blacklist mode";
            this.autolearnToolStripMenuItem.ToolTipText = "Allow all connections to applications that are not in the Blocklist";
            this.autolearnToolStripMenuItem.Click += new System.EventHandler(this.BlockListToolStripMenuItem_Click);
            // 
            // blockAllToolStripMenuItem
            // 
            this.blockAllToolStripMenuItem.Image = global::fireWall.Properties.Resources.lock11;
            this.blockAllToolStripMenuItem.Name = "blockAllToolStripMenuItem";
            this.blockAllToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.blockAllToolStripMenuItem.Text = "Block all";
            this.blockAllToolStripMenuItem.ToolTipText = "Block Incoming and Outgoing Connections";
            this.blockAllToolStripMenuItem.Click += new System.EventHandler(this.blockAllToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem1
            // 
            this.disableToolStripMenuItem1.Image = global::fireWall.Properties.Resources.error;
            this.disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
            this.disableToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.disableToolStripMenuItem1.Text = "Disable firewall";
            this.disableToolStripMenuItem1.ToolTipText = "Turns off Windows Firewall";
            this.disableToolStripMenuItem1.Click += new System.EventHandler(this.DisableFirewallState);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Image = global::fireWall.Properties.Resources.settings2;
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::fireWall.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Image = global::fireWall.Properties.Resources.exit;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(700, 540);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 34);
            this.button4.TabIndex = 7;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.close_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Disable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mode : ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(809, 493);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Special Exceptions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Optional:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Recommended:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Special exceptions for the services of Svchost:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(108, 95);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.windowsDhcpClientCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.windowsDnsClientCheckBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.windonsUpdateCheckBox);
            this.splitContainer1.Size = new System.Drawing.Size(647, 357);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.TabIndex = 3;
            // 
            // windowsDhcpClientCheckBox
            // 
            this.windowsDhcpClientCheckBox.AutoSize = true;
            this.windowsDhcpClientCheckBox.Location = new System.Drawing.Point(3, 3);
            this.windowsDhcpClientCheckBox.Name = "windowsDhcpClientCheckBox";
            this.windowsDhcpClientCheckBox.Size = new System.Drawing.Size(132, 17);
            this.windowsDhcpClientCheckBox.TabIndex = 1;
            this.windowsDhcpClientCheckBox.Text = "Windows DHCP Client";
            this.windowsDhcpClientCheckBox.UseVisualStyleBackColor = true;
            this.windowsDhcpClientCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.windowsDhcpClientCheckBox_MouseClick);
            // 
            // windowsDnsClientCheckBox
            // 
            this.windowsDnsClientCheckBox.AutoSize = true;
            this.windowsDnsClientCheckBox.Location = new System.Drawing.Point(3, 24);
            this.windowsDnsClientCheckBox.Name = "windowsDnsClientCheckBox";
            this.windowsDnsClientCheckBox.Size = new System.Drawing.Size(125, 17);
            this.windowsDnsClientCheckBox.TabIndex = 2;
            this.windowsDnsClientCheckBox.Text = "Windows DNS Client";
            this.windowsDnsClientCheckBox.UseVisualStyleBackColor = true;
            this.windowsDnsClientCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.windowsDnsClientCheckBox_MouseClick);
            // 
            // windonsUpdateCheckBox
            // 
            this.windonsUpdateCheckBox.AutoSize = true;
            this.windonsUpdateCheckBox.Location = new System.Drawing.Point(3, 3);
            this.windonsUpdateCheckBox.Name = "windonsUpdateCheckBox";
            this.windonsUpdateCheckBox.Size = new System.Drawing.Size(108, 17);
            this.windonsUpdateCheckBox.TabIndex = 0;
            this.windonsUpdateCheckBox.Text = "Windows Update";
            this.windonsUpdateCheckBox.UseVisualStyleBackColor = true;
            this.windonsUpdateCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.windonsUpdateCheckBox_MouseClick);
            // 
            // blackTab
            // 
            this.blackTab.Controls.Add(this.modifyButtonBlacklist);
            this.blackTab.Controls.Add(this.removeAll_BlockList);
            this.blackTab.Controls.Add(this.removeButton2);
            this.blackTab.Controls.Add(this.button6);
            this.blackTab.Controls.Add(this.blackGrid);
            this.blackTab.Location = new System.Drawing.Point(4, 22);
            this.blackTab.Name = "blackTab";
            this.blackTab.Padding = new System.Windows.Forms.Padding(3);
            this.blackTab.Size = new System.Drawing.Size(809, 493);
            this.blackTab.TabIndex = 1;
            this.blackTab.Text = "Blocked Apps";
            this.blackTab.UseVisualStyleBackColor = true;
            // 
            // modifyButtonBlacklist
            // 
            this.modifyButtonBlacklist.Enabled = false;
            this.modifyButtonBlacklist.Image = ((System.Drawing.Image)(resources.GetObject("modifyButtonBlacklist.Image")));
            this.modifyButtonBlacklist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modifyButtonBlacklist.Location = new System.Drawing.Point(656, 361);
            this.modifyButtonBlacklist.Name = "modifyButtonBlacklist";
            this.modifyButtonBlacklist.Size = new System.Drawing.Size(147, 27);
            this.modifyButtonBlacklist.TabIndex = 15;
            this.modifyButtonBlacklist.Text = "Modify";
            this.modifyButtonBlacklist.UseVisualStyleBackColor = true;
            this.modifyButtonBlacklist.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // removeAll_BlockList
            // 
            this.removeAll_BlockList.Enabled = false;
            this.removeAll_BlockList.Image = ((System.Drawing.Image)(resources.GetObject("removeAll_BlockList.Image")));
            this.removeAll_BlockList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeAll_BlockList.Location = new System.Drawing.Point(656, 460);
            this.removeAll_BlockList.Name = "removeAll_BlockList";
            this.removeAll_BlockList.Size = new System.Drawing.Size(147, 27);
            this.removeAll_BlockList.TabIndex = 14;
            this.removeAll_BlockList.Text = "Remove all";
            this.removeAll_BlockList.UseVisualStyleBackColor = true;
            this.removeAll_BlockList.Click += new System.EventHandler(this.removeAll_Click);
            // 
            // removeButton2
            // 
            this.removeButton2.Enabled = false;
            this.removeButton2.Image = ((System.Drawing.Image)(resources.GetObject("removeButton2.Image")));
            this.removeButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeButton2.Location = new System.Drawing.Point(656, 427);
            this.removeButton2.Name = "removeButton2";
            this.removeButton2.Size = new System.Drawing.Size(147, 27);
            this.removeButton2.TabIndex = 13;
            this.removeButton2.Text = "Remove";
            this.removeButton2.UseVisualStyleBackColor = true;
            this.removeButton2.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(656, 394);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(147, 27);
            this.button6.TabIndex = 12;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button1_Click);
            // 
            // blackGrid
            // 
            this.blackGrid.AllowUserToAddRows = false;
            this.blackGrid.AllowUserToDeleteRows = false;
            this.blackGrid.AllowUserToResizeColumns = false;
            this.blackGrid.AllowUserToResizeRows = false;
            this.blackGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.blackGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blackGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.blackGrid.Location = new System.Drawing.Point(6, 6);
            this.blackGrid.Name = "blackGrid";
            this.blackGrid.ReadOnly = true;
            this.blackGrid.RowHeadersVisible = false;
            this.blackGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.blackGrid.Size = new System.Drawing.Size(645, 481);
            this.blackGrid.TabIndex = 5;
            this.blackGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.exceptionGrid_RowsAdded);
            this.blackGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.blockGrid_RowsRemoved);
            this.blackGrid.SelectionChanged += new System.EventHandler(this.exceptionGrid_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Executable";
            this.dataGridViewTextBoxColumn1.Image = null;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Path";
            this.dataGridViewTextBoxColumn2.Image = null;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // whiteTab
            // 
            this.whiteTab.Controls.Add(this.modifyButton);
            this.whiteTab.Controls.Add(this.removeAll);
            this.whiteTab.Controls.Add(this.exceptionGrid);
            this.whiteTab.Controls.Add(this.removeButton);
            this.whiteTab.Controls.Add(this.button1);
            this.whiteTab.Location = new System.Drawing.Point(4, 22);
            this.whiteTab.Name = "whiteTab";
            this.whiteTab.Padding = new System.Windows.Forms.Padding(3);
            this.whiteTab.Size = new System.Drawing.Size(809, 493);
            this.whiteTab.TabIndex = 0;
            this.whiteTab.Text = "Allowed Apps";
            this.whiteTab.UseVisualStyleBackColor = true;
            // 
            // modifyButton
            // 
            this.modifyButton.Enabled = false;
            this.modifyButton.Image = ((System.Drawing.Image)(resources.GetObject("modifyButton.Image")));
            this.modifyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modifyButton.Location = new System.Drawing.Point(656, 361);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(147, 27);
            this.modifyButton.TabIndex = 14;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // removeAll
            // 
            this.removeAll.Enabled = false;
            this.removeAll.Image = ((System.Drawing.Image)(resources.GetObject("removeAll.Image")));
            this.removeAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeAll.Location = new System.Drawing.Point(656, 460);
            this.removeAll.Name = "removeAll";
            this.removeAll.Size = new System.Drawing.Size(147, 27);
            this.removeAll.TabIndex = 9;
            this.removeAll.Text = "Remove all";
            this.removeAll.UseVisualStyleBackColor = true;
            this.removeAll.Click += new System.EventHandler(this.removeAll_Click);
            // 
            // exceptionGrid
            // 
            this.exceptionGrid.AllowUserToAddRows = false;
            this.exceptionGrid.AllowUserToDeleteRows = false;
            this.exceptionGrid.AllowUserToResizeColumns = false;
            this.exceptionGrid.AllowUserToResizeRows = false;
            this.exceptionGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.exceptionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exceptionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.exceptionGrid.Location = new System.Drawing.Point(6, 6);
            this.exceptionGrid.Name = "exceptionGrid";
            this.exceptionGrid.ReadOnly = true;
            this.exceptionGrid.RowHeadersVisible = false;
            this.exceptionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exceptionGrid.Size = new System.Drawing.Size(645, 481);
            this.exceptionGrid.TabIndex = 4;
            this.exceptionGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.exceptionGrid_RowsAdded);
            this.exceptionGrid.SelectionChanged += new System.EventHandler(this.exceptionGrid_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Executable";
            this.Column1.Image = null;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Path";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeButton.Location = new System.Drawing.Point(656, 427);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(147, 27);
            this.removeButton.TabIndex = 8;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(656, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.whiteTab);
            this.tabControl1.Controls.Add(this.blackTab);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(817, 519);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 586);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button4);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::fireWall.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = global::fireWall.Properties.Settings.Default.Location;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Guardian";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.blackTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blackGrid)).EndInit();
            this.whiteTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exceptionGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem changeModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blockAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autolearnToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox windowsDhcpClientCheckBox;
        private System.Windows.Forms.CheckBox windowsDnsClientCheckBox;
        private System.Windows.Forms.CheckBox windonsUpdateCheckBox;
        private System.Windows.Forms.TabPage blackTab;
        private System.Windows.Forms.Button removeAll_BlockList;
        private System.Windows.Forms.Button removeButton2;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.DataGridView blackGrid;
        private System.Windows.Forms.TabPage whiteTab;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button removeAll;
        public System.Windows.Forms.DataGridView exceptionGrid;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button modifyButtonBlacklist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private TradeGrid.TextAndImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private TradeGrid.TextAndImageColumn dataGridViewTextBoxColumn1;
        private TradeGrid.TextAndImageColumn dataGridViewTextBoxColumn2;
    }
}

