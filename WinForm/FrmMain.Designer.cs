namespace WinForm
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuSys = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAccessory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAccessoryOut = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSys,
            this.MenuMain,
            this.MenuAccessory,
            this.MenuWindow});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.MenuWindow;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1007, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuSys
            // 
            this.MenuSys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuExit});
            this.MenuSys.Name = "MenuSys";
            this.MenuSys.Size = new System.Drawing.Size(43, 20);
            this.MenuSys.Text = "程式";
            // 
            // TSMenuExit
            // 
            this.TSMenuExit.Name = "TSMenuExit";
            this.TSMenuExit.Size = new System.Drawing.Size(98, 22);
            this.TSMenuExit.Text = "退出";
            this.TSMenuExit.Click += new System.EventHandler(this.TSMenuExit_Click);
            // 
            // MenuMain
            // 
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(43, 20);
            this.MenuMain.Text = "主料";
            // 
            // MenuAccessory
            // 
            this.MenuAccessory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAccessoryOut});
            this.MenuAccessory.Name = "MenuAccessory";
            this.MenuAccessory.Size = new System.Drawing.Size(43, 20);
            this.MenuAccessory.Text = "辅料";
            // 
            // MenuAccessoryOut
            // 
            this.MenuAccessoryOut.Name = "MenuAccessoryOut";
            this.MenuAccessoryOut.Size = new System.Drawing.Size(180, 22);
            this.MenuAccessoryOut.Text = "辅料发料";
            this.MenuAccessoryOut.Click += new System.EventHandler(this.MenuAccessoryOut_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MenuWindow
            // 
            this.MenuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.MenuCloseAll});
            this.MenuWindow.Name = "MenuWindow";
            this.MenuWindow.Size = new System.Drawing.Size(43, 20);
            this.MenuWindow.Text = "窗口";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuCloseAll
            // 
            this.MenuCloseAll.Name = "MenuCloseAll";
            this.MenuCloseAll.Size = new System.Drawing.Size(180, 22);
            this.MenuCloseAll.Text = "关闭所有窗口";
            this.MenuCloseAll.Click += new System.EventHandler(this.MenuCloseAll_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1007, 758);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "Warehouse Management Assist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem MenuSys;
        private System.Windows.Forms.ToolStripMenuItem TSMenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuAccessory;
        private System.Windows.Forms.ToolStripMenuItem MenuAccessoryOut;
        private System.Windows.Forms.ToolStripMenuItem MenuWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuCloseAll;
    }
}

