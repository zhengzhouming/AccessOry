using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmMain : Form
    {

      
        public FrmMain()
        {
            InitializeComponent();
            menuStrip.MdiWindowListItem = this.MenuWindow;
        }

        private void MenuAccessoryOut_Click(object sender, EventArgs e)
        {
            FrmaccessoryOut frm = FrmaccessoryOut.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void TSMenuExit_Click(object sender, EventArgs e)
        {
            const string message ="Are you sure that you would like to close the system?";
            const string caption = "system Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                // cancel the closure of the form.
                Application.Exit();
            }
          
        }

        private void MenuCloseAll_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)   //当子窗体个数大于0的时候遍历所有子窗体
            {
                foreach (Form myForm in this.MdiChildren)// 遍历所有子窗体
                    myForm.Close(); //关闭子窗体
            }
        }

        private void MenuSizeRun_Click(object sender, EventArgs e)
        {
            FrmSizeRun frm = FrmSizeRun.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void MenuOutgoing_Click(object sender, EventArgs e)
        {
            FrmOutgoing frm = FrmOutgoing.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void MenuPropertyNumber_Click(object sender, EventArgs e)
        {
            FrmFactoryplanning frm = FrmFactoryplanning.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void MenuPOTrading_Click(object sender, EventArgs e)
        {
            FrmPoTradingComanyPO frm = FrmPoTradingComanyPO.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void pONikeConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNikeConnect frm = FrmNikeConnect.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void MenuDeliveryCompare_Click(object sender, EventArgs e)
        {
            FrmDeliveryCompare frm = FrmDeliveryCompare.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void MenuReceipt_Click(object sender, EventArgs e)
        {
            FrmNoBraCodeReceipt frm = FrmNoBraCodeReceipt.GetSingleton();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();

        }
    }
}
