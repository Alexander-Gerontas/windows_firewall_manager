namespace fireWall
{
    partial class RuleProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleProperties));
            this.ok_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.allow = new System.Windows.Forms.RadioButton();
            this.block = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NoRestrictions = new System.Windows.Forms.RadioButton();
            this.ports = new System.Windows.Forms.RadioButton();
            this.localUDP = new System.Windows.Forms.TextBox();
            this.remoteUDP = new System.Windows.Forms.TextBox();
            this.localTCP = new System.Windows.Forms.TextBox();
            this.remoteTCP = new System.Windows.Forms.TextBox();
            this.OutTCP = new System.Windows.Forms.Label();
            this.InUDP = new System.Windows.Forms.Label();
            this.OutUDP = new System.Windows.Forms.Label();
            this.InTCP = new System.Windows.Forms.Label();
            this.unrestricted = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(186, 334);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // allow
            // 
            this.allow.AutoSize = true;
            this.allow.Location = new System.Drawing.Point(12, 133);
            this.allow.Name = "allow";
            this.allow.Size = new System.Drawing.Size(194, 17);
            this.allow.TabIndex = 2;
            this.allow.TabStop = true;
            this.allow.Text = "Allow outgoing UDP and TCP traffic";
            this.allow.UseVisualStyleBackColor = true;
            this.allow.CheckedChanged += new System.EventHandler(this.allow_CheckedChanged);
            // 
            // block
            // 
            this.block.AutoSize = true;
            this.block.Location = new System.Drawing.Point(12, 87);
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(129, 17);
            this.block.TabIndex = 3;
            this.block.TabStop = true;
            this.block.Text = "Always block all traffic";
            this.block.UseVisualStyleBackColor = true;
            this.block.CheckedChanged += new System.EventHandler(this.block_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path: ";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(50, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 20);
            this.textBox1.TabIndex = 5;
            // 
            // NoRestrictions
            // 
            this.NoRestrictions.AutoSize = true;
            this.NoRestrictions.Location = new System.Drawing.Point(12, 179);
            this.NoRestrictions.Name = "NoRestrictions";
            this.NoRestrictions.Size = new System.Drawing.Size(92, 17);
            this.NoRestrictions.TabIndex = 6;
            this.NoRestrictions.TabStop = true;
            this.NoRestrictions.Text = "No restrictions";
            this.NoRestrictions.UseVisualStyleBackColor = true;
            this.NoRestrictions.CheckedChanged += new System.EventHandler(this.NoRestrictions_CheckedChanged);
            // 
            // ports
            // 
            this.ports.AutoSize = true;
            this.ports.Location = new System.Drawing.Point(12, 110);
            this.ports.Name = "ports";
            this.ports.Size = new System.Drawing.Size(143, 17);
            this.ports.TabIndex = 7;
            this.ports.TabStop = true;
            this.ports.Text = "Allow only specified ports";
            this.ports.UseVisualStyleBackColor = true;
            this.ports.CheckedChanged += new System.EventHandler(this.ports_CheckedChanged);
            // 
            // localUDP
            // 
            this.localUDP.Location = new System.Drawing.Point(245, 287);
            this.localUDP.Name = "localUDP";
            this.localUDP.Size = new System.Drawing.Size(100, 20);
            this.localUDP.TabIndex = 9;
            this.localUDP.TextChanged += new System.EventHandler(this.localUDP_TextChanged);
            // 
            // remoteUDP
            // 
            this.remoteUDP.Location = new System.Drawing.Point(245, 252);
            this.remoteUDP.Name = "remoteUDP";
            this.remoteUDP.Size = new System.Drawing.Size(100, 20);
            this.remoteUDP.TabIndex = 10;
            this.remoteUDP.TextChanged += new System.EventHandler(this.remoteUDP_TextChanged);
            // 
            // localTCP
            // 
            this.localTCP.Location = new System.Drawing.Point(72, 287);
            this.localTCP.Name = "localTCP";
            this.localTCP.Size = new System.Drawing.Size(100, 20);
            this.localTCP.TabIndex = 11;
            this.localTCP.TextChanged += new System.EventHandler(this.localTCP_TextChanged);
            // 
            // remoteTCP
            // 
            this.remoteTCP.Location = new System.Drawing.Point(72, 252);
            this.remoteTCP.Name = "remoteTCP";
            this.remoteTCP.Size = new System.Drawing.Size(100, 20);
            this.remoteTCP.TabIndex = 12;
            this.remoteTCP.TextChanged += new System.EventHandler(this.remoteTCP_TextChanged);
            // 
            // OutTCP
            // 
            this.OutTCP.AutoSize = true;
            this.OutTCP.Location = new System.Drawing.Point(12, 255);
            this.OutTCP.Name = "OutTCP";
            this.OutTCP.Size = new System.Drawing.Size(54, 13);
            this.OutTCP.TabIndex = 13;
            this.OutTCP.Text = "Out TCP: ";
            // 
            // InUDP
            // 
            this.InUDP.AutoSize = true;
            this.InUDP.Location = new System.Drawing.Point(183, 290);
            this.InUDP.Name = "InUDP";
            this.InUDP.Size = new System.Drawing.Size(48, 13);
            this.InUDP.TabIndex = 14;
            this.InUDP.Text = "In UDP: ";
            // 
            // OutUDP
            // 
            this.OutUDP.AutoSize = true;
            this.OutUDP.Location = new System.Drawing.Point(183, 255);
            this.OutUDP.Name = "OutUDP";
            this.OutUDP.Size = new System.Drawing.Size(56, 13);
            this.OutUDP.TabIndex = 15;
            this.OutUDP.Text = "Out UDP: ";
            // 
            // InTCP
            // 
            this.InTCP.AutoSize = true;
            this.InTCP.Location = new System.Drawing.Point(12, 290);
            this.InTCP.Name = "InTCP";
            this.InTCP.Size = new System.Drawing.Size(46, 13);
            this.InTCP.TabIndex = 16;
            this.InTCP.Text = "In TCP: ";
            // 
            // unrestricted
            // 
            this.unrestricted.AutoSize = true;
            this.unrestricted.Location = new System.Drawing.Point(12, 156);
            this.unrestricted.Name = "unrestricted";
            this.unrestricted.Size = new System.Drawing.Size(182, 17);
            this.unrestricted.TabIndex = 17;
            this.unrestricted.TabStop = true;
            this.unrestricted.Text = "Unrestricted UDP and TCP traffic";
            this.unrestricted.UseVisualStyleBackColor = true;
            this.unrestricted.CheckedChanged += new System.EventHandler(this.unrestricted_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Open up the following ports, in addition to the restrictions above.";
            // 
            // RuleProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 369);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unrestricted);
            this.Controls.Add(this.InTCP);
            this.Controls.Add(this.OutUDP);
            this.Controls.Add(this.InUDP);
            this.Controls.Add(this.OutTCP);
            this.Controls.Add(this.remoteTCP);
            this.Controls.Add(this.localTCP);
            this.Controls.Add(this.remoteUDP);
            this.Controls.Add(this.localUDP);
            this.Controls.Add(this.ports);
            this.Controls.Add(this.NoRestrictions);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.block);
            this.Controls.Add(this.allow);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ok_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RuleProperties";
            this.Text = "Rule Properties";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton allow;
        private System.Windows.Forms.RadioButton block;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton NoRestrictions;
        private System.Windows.Forms.RadioButton ports;
        private System.Windows.Forms.TextBox localUDP;
        private System.Windows.Forms.TextBox remoteUDP;
        private System.Windows.Forms.TextBox localTCP;
        private System.Windows.Forms.TextBox remoteTCP;
        private System.Windows.Forms.Label OutTCP;
        private System.Windows.Forms.Label InUDP;
        private System.Windows.Forms.Label OutUDP;
        private System.Windows.Forms.Label InTCP;
        private System.Windows.Forms.RadioButton unrestricted;
        private System.Windows.Forms.Label label2;
    }
}