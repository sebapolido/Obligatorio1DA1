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

        private IParkingRepository repository;
        private Settings settings;

        public PrincipalForm()
        {
            InitializeComponent();
            this.SecundaryPanel.Visible = false;
            this.principalPanel.Visible = true;
            lblAnswer.Visible = false;
            repository = new ParkingRepository();
            AddCountries();
        }

        private void AddCountries()
        {
            Country Argentina = new Country("Argentina", 1);
            Country Uruguay = new Country("Uruguay", 1);
            repository.AddCountry(Argentina);
            repository.AddCountry(Uruguay);
            settings = new Settings(principalPanel, repository, Uruguay);
        }

        private void BtnAccountRegister_Click(object sender, EventArgs e)
        {
            AddToPanel(new AccountRegister(principalPanel, repository, settings.country));
        }

        private void BtnAddBalance_Click(object sender, EventArgs e)
        {
            AddToPanelCheckingAreAccounts(new AddBalance(principalPanel, repository, settings.country));
        }

        private void BtnProcessPurchase_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 18)
               AddToPanelCheckingAreAccounts(new ProcessPurchase(principalPanel, repository, settings.country));
            else
                SetMessage("Esta función solo está disponible de 10 a 18 horas.");
        }

        private void BtnCheckPurchase_Click(object sender, EventArgs e)
        {
            AddToPanelCheckingAreAccounts(new CheckPurchase(principalPanel, repository));            
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            Settings newSettings = new Settings(principalPanel, repository, settings.country);
            AddToPanel(newSettings);
            settings = newSettings;
        }

        private void AddToPanelCheckingAreAccounts(System.Windows.Forms.Control newControl)
        {
            if (repository.GetAccounts().ToArray().Length > 0)
                AddToPanel(newControl);
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void AddToPanel(System.Windows.Forms.Control newControl)
        {
            this.SecundaryPanel.Controls.Clear();
            this.SecundaryPanel.Controls.Add(newControl);
            ChangeStatus();
        }

        private void ChangeStatus()
        {
            principalPanel.Visible = false;
            SecundaryPanel.Visible = true;
            lblAnswer.Visible = false;
        }

        private void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void TimerOfAnswer_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
