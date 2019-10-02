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

        ISystemController system;

        public PrincipalForm()
        {
            InitializeComponent();
            this.SecundaryPanel.Visible = false;
            this.principalPanel.Visible = true;
            lblAnswer.Visible = false;
            system = new SystemController();
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
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            {
                if (DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 18 && DateTime.Now.Minute >= 0 &&
                DateTime.Now.Minute < 60)
                {
                    ChangeStatus();
                    this.SecundaryPanel.Controls.Add(new ProcessPurchase(principalPanel, system));
                }
                else
                    SetMessage("Esta función solo está disponible de 10 a 18 horas.");
            }
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            { 
                ChangeStatus();
                this.SecundaryPanel.Controls.Add(new CheckPurchase(principalPanel, system));
            }
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void ChangeStatus()
        {
            this.principalPanel.Visible = false;
            this.SecundaryPanel.Visible = true;
            lblAnswer.Visible = false;
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

        public void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }
    }
}
