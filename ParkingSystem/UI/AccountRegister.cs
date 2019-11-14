using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem;

namespace UI
{
    public partial class AccountRegister : UserControl
    {
        private Panel panel;
        private IParkingRepository repository;
        private CountryHandler countryHandler;

        public AccountRegister(Panel principalPanel, IParkingRepository parkingRepository, CountryHandler actualCountry)
        {
            InitializeComponent();
            panel = principalPanel;
            repository = parkingRepository;
            countryHandler = actualCountry;
        }     

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmpty();
        }

        private void ValidateEmpty()
        {
            if(countryHandler.ValidateIsEmptyByCountry(txtNumberPhone.Text))
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string textOfPhone = txtNumberPhone.Text;
                textOfPhone = textOfPhone.Replace(" ", "");
                ValidateFormatNumber(textOfPhone);
            }
        }

        private void ValidateFormatNumber(string textOfPhone)
        {
            if (countryHandler.ValidateFormatNumberByCountry(ref textOfPhone))
                if (countryHandler.ValidateIsNumericByCountry(textOfPhone))
                    ValidateRepeatNumber(textOfPhone);
                else
                    SetMessage("El número que ingresó no es númerico.");
            else
                SetMessage("El número no coincide con el formato.");
        }

        private void ValidateRepeatNumber(string textOfPhone)
        {
            if (repository.GetAccounts().ToArray().Length > 0)
                if (!repository.IsRepeatedNumber(textOfPhone))
                    AddAccount(textOfPhone);
                else
                    SetMessage("El número que ingresó ya está registrado.");
            else
                AddAccount(textOfPhone);
        }

        private void AddAccount(string textOfPhone)
        {
            Account newAccount = new Account(0, textOfPhone, countryHandler);
            repository.AddAccount(newAccount);
            MessageAccountAdded();
        }

        private void MessageAccountAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            txtNumberPhone.Clear();
            SetMessage("La cuenta ha sido registrada correctamente.");           
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
