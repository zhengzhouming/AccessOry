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
            this.MenuPP = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSizeRun = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFP = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPropertyNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMain = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAccessory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAccessoryOut = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOutgoing = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDeliveryCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPOTrading = new System.Windows.Forms.ToolStripMenuItem();
            this.pONikeConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pDA管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSys,
            this.MenuPP,
            this.MenuFP,
            this.MenuMain,
            this.MenuAccessory,
            this.MenuProduct,
            this.MenuWindow});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.MenuWindow;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1007, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuSys
            // 
            this.MenuSys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuExit});
            this.MenuSys.Name = "MenuSys";
            this.MenuSys.Size = new System.Drawing.Size(44, 21);
            this.MenuSys.Text = "程式";
            // 
            // TSMenuExit
            // 
            this.TSMenuExit.Name = "TSMenuExit";
            this.TSMenuExit.Size = new System.Drawing.Size(100, 22);
            this.TSMenuExit.Text = "退出";
            this.TSMenuExit.Click += new System.EventHandler(this.TSMenuExit_Click);
            // 
            // MenuPP
            // 
            this.MenuPP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSizeRun});
            this.MenuPP.Name = "MenuPP";
            this.MenuPP.Size = new System.Drawing.Size(68, 21);
            this.MenuPP.Text = "生产计划";
            // 
            // MenuSizeRun
            // 
            this.MenuSizeRun.Name = "MenuSizeRun";
            this.MenuSizeRun.Size = new System.Drawing.Size(121, 22);
            this.MenuSizeRun.Text = "SizeRun";
            this.MenuSizeRun.Click += new System.EventHandler(this.MenuSizeRun_Click);
            // 
            // MenuFP
            // 
            this.MenuFP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPropertyNumber,
            this.pDA管理ToolStripMenuItem});
            this.MenuFP.Name = "MenuFP";
            this.MenuFP.Size = new System.Drawing.Size(68, 21);
            this.MenuFP.Text = "厂务规划";
            // 
            // MenuPropertyNumber
            // 
            this.MenuPropertyNumber.Name = "MenuPropertyNumber";
            this.MenuPropertyNumber.Size = new System.Drawing.Size(180, 22);
            this.MenuPropertyNumber.Text = "财编打印";
            this.MenuPropertyNumber.Click += new System.EventHandler(this.MenuPropertyNumber_Click);
            // 
            // MenuMain
            // 
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(44, 21);
            this.MenuMain.Text = "主料";
            // 
            // MenuAccessory
            // 
            this.MenuAccessory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAccessoryOut});
            this.MenuAccessory.Name = "MenuAccessory";
            this.MenuAccessory.Size = new System.Drawing.Size(44, 21);
            this.MenuAccessory.Text = "辅料";
            // 
            // MenuAccessoryOut
            // 
            this.MenuAccessoryOut.Name = "MenuAccessoryOut";
            this.MenuAccessoryOut.Size = new System.Drawing.Size(124, 22);
            this.MenuAccessoryOut.Text = "辅料发料";
            this.MenuAccessoryOut.Click += new System.EventHandler(this.MenuAccessoryOut_Click);
            // 
            // MenuProduct
            // 
            this.MenuProduct.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReceipt,
            this.MenuOutgoing,
            this.MenuDeliveryCompare,
            this.MenuPOTrading,
            this.pONikeConnectToolStripMenuItem});
            this.MenuProduct.Name = "MenuProduct";
            this.MenuProduct.Size = new System.Drawing.Size(44, 21);
            this.MenuProduct.Text = "成品";
            // 
            // MenuReceipt
            // 
            this.MenuReceipt.Name = "MenuReceipt";
            this.MenuReceipt.Size = new System.Drawing.Size(230, 22);
            this.MenuReceipt.Text = "无条码收货入库";
            this.MenuReceipt.Click += new System.EventHandler(this.MenuReceipt_Click);
            // 
            // MenuOutgoing
            // 
            this.MenuOutgoing.Name = "MenuOutgoing";
            this.MenuOutgoing.Size = new System.Drawing.Size(230, 22);
            this.MenuOutgoing.Text = "入库查询";
            this.MenuOutgoing.Click += new System.EventHandler(this.MenuOutgoing_Click);
            // 
            // MenuDeliveryCompare
            // 
            this.MenuDeliveryCompare.Name = "MenuDeliveryCompare";
            this.MenuDeliveryCompare.Size = new System.Drawing.Size(230, 22);
            this.MenuDeliveryCompare.Text = "收货入库比对";
            this.MenuDeliveryCompare.Click += new System.EventHandler(this.MenuDeliveryCompare_Click);
            // 
            // MenuPOTrading
            // 
            this.MenuPOTrading.Enabled = false;
            this.MenuPOTrading.Name = "MenuPOTrading";
            this.MenuPOTrading.Size = new System.Drawing.Size(230, 22);
            this.MenuPOTrading.Text = "PO# Trading Company PO";
            this.MenuPOTrading.Click += new System.EventHandler(this.MenuPOTrading_Click);
            // 
            // pONikeConnectToolStripMenuItem
            // 
            this.pONikeConnectToolStripMenuItem.Name = "pONikeConnectToolStripMenuItem";
            this.pONikeConnectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.pONikeConnectToolStripMenuItem.Text = "PO# NikeConnect";
            this.pONikeConnectToolStripMenuItem.Click += new System.EventHandler(this.pONikeConnectToolStripMenuItem_Click);
            // 
            // MenuWindow
            // 
            this.MenuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.MenuCloseAll});
            this.MenuWindow.Name = "MenuWindow";
            this.MenuWindow.Size = new System.Drawing.Size(44, 21);
            this.MenuWindow.Text = "窗口";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuCloseAll
            // 
            this.MenuCloseAll.Name = "MenuCloseAll";
            this.MenuCloseAll.Size = new System.Drawing.Size(148, 22);
            this.MenuCloseAll.Text = "关闭所有窗口";
            this.MenuCloseAll.Click += new System.EventHandler(this.MenuCloseAll_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sabrina 仓库管理助手";
            this.notifyIcon1.Visible = true;
            // 
            // pDA管理ToolStripMenuItem
            // 
            this.pDA管理ToolStripMenuItem.Name = "pDA管理ToolStripMenuItem";
            this.pDA管理ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pDA管理ToolStripMenuItem.Text = "PDA管理";
            this.pDA管理ToolStripMenuItem.Click += new System.EventHandler(this.pDA管理ToolStripMenuItem_Click);
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
            this.Text = "仓库管理助手";
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
        private System.Windows.Forms.ToolStripMenuItem MenuPP;
        private System.Windows.Forms.ToolStripMenuItem MenuSizeRun;
        private System.Windows.Forms.ToolStripMenuItem MenuProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuOutgoing;
        private System.Windows.Forms.ToolStripMenuItem MenuFP;
        private System.Windows.Forms.ToolStripMenuItem MenuPropertyNumber;
        private System.Windows.Forms.ToolStripMenuItem MenuPOTrading;
        private System.Windows.Forms.ToolStripMenuItem pONikeConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuDeliveryCompare;
        private System.Windows.Forms.ToolStripMenuItem MenuReceipt;
        private System.Windows.Forms.ToolStripMenuItem pDA管理ToolStripMenuItem;
    }
}

