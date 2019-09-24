using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ParkingSystem;

namespace UI
{
    public partial class PrincipalForm : Form
    {

        SystemController system;

        public PrincipalForm()
        {
            InitializeComponent();
            this.SecundaryPanel.Visible = false;
            this.principalPanel.Visible = true;
            lblAnswer.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeStatus();
            this.SecundaryPanel.Controls.Add(new AccountRegister(principalPanel, system));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            {
                ChangeStatus();
                this.SecundaryPanel.Controls.Add(new AddBalance(principalPanel, system));
            }
            else
                IfNotAreAccount();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            {
                ChangeStatus();
                this.SecundaryPanel.Controls.Add(new ProcessPurchase(principalPanel, system));
            }
            else
                IfNotAreAccount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            { 
                ChangeStatus();
                this.SecundaryPanel.Controls.Add(new CheckPurchase(principalPanel, system));
            }
            else
                IfNotAreAccount();
        }

        private void ChangeStatus()
        {
            this.principalPanel.Visible = false;
            this.SecundaryPanel.Visible = true;
            lblAnswer.Visible = false;
        }

        private void IfNotAreAccount()
        {
            lblAnswer.Visible = true;
            timerOfAnswer.Start();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
        
        }

        private void PrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void TimerOfError_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Account account = new Account();
            account.balance = 25;
            account.mobile = "99366931";
            system.AddAccount(account);
         }
    }
}
