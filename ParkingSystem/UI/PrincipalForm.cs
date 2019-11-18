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

        private IParkingRepository Repository;
        private Settings Settings;

        public PrincipalForm()
        {
            InitializeComponent();
            this.SecundaryPanel.Visible = false;
            this.PrincipalPanel.Visible = true;
            lblAnswer.Visible = false;
            Repository = new ParkingRepository();
            CountryHandler initialCountry = Repository.GetACountry("Uruguay");
            Settings = new Settings(PrincipalPanel, Repository, initialCountry);
        }

        private void BtnAccountRegister_Click(object sender, EventArgs e)
        {
            AddToPanel(new AccountRegister(PrincipalPanel, Repository, Settings.Country));
        }

        private void BtnAddBalance_Click(object sender, EventArgs e)
        {
            AddToPanelCheckingAreAccounts(new AddBalance(PrincipalPanel, Repository, Settings.Country));
        }

        private void BtnProcessPurchase_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 18)
                AddToPanelCheckingAreAccounts(new ProcessPurchase(PrincipalPanel, Repository, Settings.Country));
            else
                SetMessage("Esta función solo está disponible de 10 a 18 horas.");
        }

        private void BtnCheckPurchase_Click(object sender, EventArgs e)
        {
            AddToPanelCheckingAreAccounts(new CheckPurchase(PrincipalPanel, Repository));
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            AddToPanelCheckingAreAccounts(new Reports(PrincipalPanel, Repository, Settings.Country));
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Settings NewSettings = new Settings(PrincipalPanel, Repository, Settings.Country);
            AddToPanel(NewSettings);
            Settings = NewSettings;
        }

        private void AddToPanelCheckingAreAccounts(System.Windows.Forms.Control NewControl)
        {
            if (Repository.GetAccounts().ToArray().Length > 0)
                AddToPanel(NewControl);
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void AddToPanel(System.Windows.Forms.Control NewControl)
        {
            this.SecundaryPanel.Controls.Clear();
            this.SecundaryPanel.Controls.Add(NewControl);
            ChangeStatus();
        }

        private void ChangeStatus()
        {
            PrincipalPanel.Visible = false;
            SecundaryPanel.Visible = true;
            lblAnswer.Visible = false;
        }

        private void SetMessage(string TextToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = TextToShow;
            timerOfAnswer.Start();
        }

        private void TimerOfAnswer_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
