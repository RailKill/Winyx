namespace Winyx
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHidden = new System.Windows.Forms.Button();
            this.btnVisible = new System.Windows.Forms.Button();
            this.previewGrid = new System.Windows.Forms.TableLayoutPanel();
            this.panelCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.btnArrangeCat = new System.Windows.Forms.Button();
            this.btnCloseCat = new System.Windows.Forms.Button();
            this.btnKillCat = new System.Windows.Forms.Button();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnKillAll = new System.Windows.Forms.Button();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.btnAutoArrange = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblADDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblADStatus = new System.Windows.Forms.Label();
            this.lblCurrentCat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trayMenu.SuspendLayout();
            this.panelCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "The window manager is now hidden and can be viewed again by simply double clickin" +
    "g this icon.";
            this.notifyIcon.BalloonTipTitle = "Minimized to Tray";
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Winyx";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(117, 70);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnHidden
            // 
            this.btnHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHidden.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidden.Location = new System.Drawing.Point(647, 527);
            this.btnHidden.Name = "btnHidden";
            this.btnHidden.Size = new System.Drawing.Size(140, 45);
            this.btnHidden.TabIndex = 4;
            this.btnHidden.Text = "Hide Category";
            this.toolTips.SetToolTip(this.btnHidden, "Hide windows in current category.");
            this.btnHidden.UseVisualStyleBackColor = true;
            this.btnHidden.Click += new System.EventHandler(this.btnHidden_Click);
            // 
            // btnVisible
            // 
            this.btnVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisible.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisible.Location = new System.Drawing.Point(647, 476);
            this.btnVisible.Name = "btnVisible";
            this.btnVisible.Size = new System.Drawing.Size(140, 45);
            this.btnVisible.TabIndex = 3;
            this.btnVisible.Text = "Show Category";
            this.toolTips.SetToolTip(this.btnVisible, "Show windows in current category.");
            this.btnVisible.UseVisualStyleBackColor = true;
            this.btnVisible.Click += new System.EventHandler(this.btnVisible_Click);
            // 
            // previewGrid
            // 
            this.previewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGrid.AutoSize = true;
            this.previewGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.previewGrid.ColumnCount = 1;
            this.previewGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.previewGrid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.previewGrid.Location = new System.Drawing.Point(12, 12);
            this.previewGrid.Name = "previewGrid";
            this.previewGrid.RowCount = 2;
            this.previewGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.previewGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.previewGrid.Size = new System.Drawing.Size(593, 509);
            this.previewGrid.TabIndex = 13;
            // 
            // panelCategory
            // 
            this.panelCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategory.Controls.Add(this.btnArrangeCat);
            this.panelCategory.Controls.Add(this.btnCloseCat);
            this.panelCategory.Controls.Add(this.btnKillCat);
            this.panelCategory.Location = new System.Drawing.Point(648, 139);
            this.panelCategory.Name = "panelCategory";
            this.panelCategory.Size = new System.Drawing.Size(140, 330);
            this.panelCategory.TabIndex = 5;
            // 
            // btnArrangeCat
            // 
            this.btnArrangeCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrangeCat.Image = global::Winyx.Properties.Resources.windows;
            this.btnArrangeCat.Location = new System.Drawing.Point(0, 3);
            this.btnArrangeCat.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnArrangeCat.Name = "btnArrangeCat";
            this.btnArrangeCat.Size = new System.Drawing.Size(42, 42);
            this.btnArrangeCat.TabIndex = 10;
            this.toolTips.SetToolTip(this.btnArrangeCat, "Auto-arrange windows in the current category.");
            this.btnArrangeCat.UseVisualStyleBackColor = true;
            this.btnArrangeCat.Click += new System.EventHandler(this.btnArrangeCat_Click);
            // 
            // btnCloseCat
            // 
            this.btnCloseCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseCat.Image = global::Winyx.Properties.Resources.blackcross;
            this.btnCloseCat.Location = new System.Drawing.Point(48, 3);
            this.btnCloseCat.Name = "btnCloseCat";
            this.btnCloseCat.Size = new System.Drawing.Size(42, 42);
            this.btnCloseCat.TabIndex = 11;
            this.toolTips.SetToolTip(this.btnCloseCat, "Close all windows in current category.");
            this.btnCloseCat.UseCompatibleTextRendering = true;
            this.btnCloseCat.UseVisualStyleBackColor = true;
            this.btnCloseCat.Click += new System.EventHandler(this.btnCloseCat_Click);
            // 
            // btnKillCat
            // 
            this.btnKillCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKillCat.Image = ((System.Drawing.Image)(resources.GetObject("btnKillCat.Image")));
            this.btnKillCat.Location = new System.Drawing.Point(96, 3);
            this.btnKillCat.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnKillCat.Name = "btnKillCat";
            this.btnKillCat.Size = new System.Drawing.Size(42, 42);
            this.btnKillCat.TabIndex = 12;
            this.toolTips.SetToolTip(this.btnKillCat, "Terminates the processes of all windows in current category immediately.\r\n(Using " +
        "this function can lose all unsaved progress of the terminated programs!)");
            this.btnKillCat.UseVisualStyleBackColor = true;
            this.btnKillCat.Click += new System.EventHandler(this.btnKillCat_Click);
            // 
            // btnKillAll
            // 
            this.btnKillAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKillAll.Image = ((System.Drawing.Image)(resources.GetObject("btnKillAll.Image")));
            this.btnKillAll.Location = new System.Drawing.Point(746, 92);
            this.btnKillAll.Name = "btnKillAll";
            this.btnKillAll.Size = new System.Drawing.Size(42, 42);
            this.btnKillAll.TabIndex = 9;
            this.toolTips.SetToolTip(this.btnKillAll, "Terminate all windows. Any unsaved changes on those windows will be lost.");
            this.btnKillAll.UseVisualStyleBackColor = true;
            this.btnKillAll.Click += new System.EventHandler(this.btnKillAll_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAll.Image")));
            this.btnCloseAll.Location = new System.Drawing.Point(697, 92);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(42, 42);
            this.btnCloseAll.TabIndex = 8;
            this.toolTips.SetToolTip(this.btnCloseAll, "Close all windows.");
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // btnAutoArrange
            // 
            this.btnAutoArrange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoArrange.Image = global::Winyx.Properties.Resources.blackadd;
            this.btnAutoArrange.Location = new System.Drawing.Point(648, 91);
            this.btnAutoArrange.Name = "btnAutoArrange";
            this.btnAutoArrange.Size = new System.Drawing.Size(42, 42);
            this.btnAutoArrange.TabIndex = 7;
            this.toolTips.SetToolTip(this.btnAutoArrange, "Automatically sort all windows into categories and arrange them on the screen.\r\nW" +
        "indows which are not in any category will be assigned to an existing or new cate" +
        "gory.");
            this.btnAutoArrange.UseVisualStyleBackColor = true;
            this.btnAutoArrange.Click += new System.EventHandler(this.btnAutoArrange_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(648, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(64, 64);
            this.btnSettings.TabIndex = 6;
            this.toolTips.SetToolTip(this.btnSettings, "Change settings and user preferences.");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(724, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 64);
            this.btnClose.TabIndex = 2;
            this.toolTips.SetToolTip(this.btnClose, "Minimize and hide the interface to tray.");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblADDesc
            // 
            this.lblADDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblADDesc.AutoSize = true;
            this.lblADDesc.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblADDesc.ForeColor = System.Drawing.Color.White;
            this.lblADDesc.Location = new System.Drawing.Point(446, 539);
            this.lblADDesc.Name = "lblADDesc";
            this.lblADDesc.Size = new System.Drawing.Size(128, 25);
            this.lblADDesc.TabIndex = 14;
            this.lblADDesc.Text = "Auto-Dock:";
            this.toolTips.SetToolTip(this.lblADDesc, "Allow the use of arrow keys to partition and dock windows.\r\n(Default: Shift+Tab t" +
        "o Toggle)");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Currently Viewing:";
            this.toolTips.SetToolTip(this.label1, "Current category name.");
            // 
            // lblADStatus
            // 
            this.lblADStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblADStatus.AutoSize = true;
            this.lblADStatus.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblADStatus.ForeColor = System.Drawing.Color.Red;
            this.lblADStatus.Location = new System.Drawing.Point(569, 539);
            this.lblADStatus.Name = "lblADStatus";
            this.lblADStatus.Size = new System.Drawing.Size(42, 25);
            this.lblADStatus.TabIndex = 15;
            this.lblADStatus.Text = "Off";
            this.toolTips.SetToolTip(this.lblADStatus, "Allow the use of arrow keys to partition and dock windows.\r\n(Default: Shift+Tab t" +
        "o Toggle)");
            // 
            // lblCurrentCat
            // 
            this.lblCurrentCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentCat.AutoSize = true;
            this.lblCurrentCat.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCat.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCurrentCat.Location = new System.Drawing.Point(204, 539);
            this.lblCurrentCat.Name = "lblCurrentCat";
            this.lblCurrentCat.Size = new System.Drawing.Size(67, 25);
            this.lblCurrentCat.TabIndex = 17;
            this.lblCurrentCat.Text = "None";
            this.toolTips.SetToolTip(this.lblCurrentCat, "Current category name.");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(719, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "RailKill © 2014";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentCat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblADStatus);
            this.Controls.Add(this.lblADDesc);
            this.Controls.Add(this.previewGrid);
            this.Controls.Add(this.btnKillAll);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.btnAutoArrange);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.panelCategory);
            this.Controls.Add(this.btnVisible);
            this.Controls.Add(this.btnHidden);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "Winyx - Window Management Tool";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.trayMenu.ResumeLayout(false);
            this.panelCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHidden;
        private System.Windows.Forms.Button btnVisible;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAutoArrange;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.Button btnKillAll;
        private System.Windows.Forms.TableLayoutPanel previewGrid;
        private System.Windows.Forms.Button btnArrangeCat;
        private System.Windows.Forms.Button btnCloseCat;
        private System.Windows.Forms.Button btnKillCat;
        private System.Windows.Forms.FlowLayoutPanel panelCategory;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label lblADDesc;
        private System.Windows.Forms.Label lblADStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentCat;
        private System.Windows.Forms.Label label2;
    }
}

