namespace BitcoinDESystemTray
{
    partial class BitcoinWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitcoinWindow));
            this.bitcoinIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openBitcoindeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bitcoinIcon
            // 
            this.bitcoinIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.bitcoinIcon.BalloonTipText = " ";
            this.bitcoinIcon.BalloonTipTitle = "Bitcoin.de Prices";
            this.bitcoinIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.bitcoinIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("bitcoinIcon.Icon")));
            this.bitcoinIcon.Tag = " ";
            this.bitcoinIcon.Text = "Bitcoin,de Buy: 0.00€ Sell: 0.00€ ~Price: 0.00€ (00:00:00h)";
            this.bitcoinIcon.Visible = true;
            this.bitcoinIcon.BalloonTipClicked += new System.EventHandler(this.bitcoinIcon_BalloonTipClicked);
            this.bitcoinIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bitcoinIcon_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBitcoindeToolStripMenuItem,
            this.importentToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 70);
            // 
            // openBitcoindeToolStripMenuItem
            // 
            this.openBitcoindeToolStripMenuItem.Name = "openBitcoindeToolStripMenuItem";
            this.openBitcoindeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openBitcoindeToolStripMenuItem.Text = "Open Bitcoin.de";
            this.openBitcoindeToolStripMenuItem.Click += new System.EventHandler(this.openBitcoindeToolStripMenuItem_Click);
            // 
            // importentToolStripMenuItem
            // 
            this.importentToolStripMenuItem.Name = "importentToolStripMenuItem";
            this.importentToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.importentToolStripMenuItem.Text = "Importent";
            this.importentToolStripMenuItem.Visible = false;
            this.importentToolStripMenuItem.Click += new System.EventHandler(this.importentToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Copyright by Sven-Goessling.de";
            // 
            // BitcoinWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BitcoinWindow";
            this.Text = "Bitcoin.de Price Status";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon bitcoinIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openBitcoindeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importentToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

