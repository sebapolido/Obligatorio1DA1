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
        private int costForMinutes = 1;
        private Settings settings;

        public PrincipalForm()
        {
            InitializeComponent();
            this.SecundaryPanel.Visible = false;
            this.principalPanel.Visible = true;
            lblAnswer.Visible = false;
            repository = new ParkingRepository();
            addCountries();
        }

        private void addCountries()
        {
            Country Argentina = new Country("Argentina", 1);
            Country Uruguay = new Country("Uruguay", 1);
            repository.AddCountry(Argentina);
            repository.AddCountry(Uruguay);
            settings = new Settings(principalPanel, repository, Uruguay);
        }

        private void BtnAccountRegister_Click(object sender, EventArgs e)
        {
            StartRegisteringAccount();
        }

        private void StartRegisteringAccount()
        {
            ChangeStatus();
            Country country = settings.country;
            AddToPanel(new AccountRegister(principalPanel, repository, country));
        }

        private void BtnAddBalance_Click(object sender, EventArgs e)
        {
            StartAddingBalance();
        }

        private void StartAddingBalance()
        {
            if (repository.GetAccounts().ToArray().Length > 0)
            {
                ChangeStatus();
                Country country = settings.country;
                AddToPanel(new AddBalance(principalPanel, repository, country));
            }
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void BtnProcessPurchase_Click(object sender, EventArgs e)
        {
            StartProcessingPurchase();
        }

        private void StartProcessingPurchase()
        {
            if (repository.GetAccounts().ToArray().Length > 0)
                if (DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 18)
                {                    
                    ChangeStatus();
                    Country country = settings.country;
                    costForMinutes = country.costForMinutes;
                    AddToPanel(new ProcessPurchase(principalPanel, repository, costForMinutes, country));
                }
                else
                    SetMessage("Esta función solo está disponible de 10 a 18 horas.");
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");

        }

        private void BtnCheckPurchase_Click(object sender, EventArgs e)
        {
            StartCheckingPurchase();
        }

        private void StartCheckingPurchase()
        {
            if (repository.GetAccounts().ToArray().Length > 0)
            {
                ChangeStatus();
                AddToPanel(new CheckPurchase(principalPanel, repository));
            }
            else
                SetMessage("Primero debe haber al menos una cuenta regitrada.");
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ChangeStatus();
            Country country = settings.country;
            costForMinutes = country.costForMinutes;
            Settings newSettings = new Settings(principalPanel, repository, country);
            AddToPanel(newSettings);
            settings = newSettings;
        }

        private void AddToPanel(System.Windows.Forms.Control newControl)
        {
            this.SecundaryPanel.Controls.Clear();
            this.SecundaryPanel.Controls.Add(newControl);
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
