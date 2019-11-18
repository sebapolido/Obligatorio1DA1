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
        private Panel Panel;
        private IParkingRepository Repository;
        private CountryHandler CountryHandler;

        public AccountRegister(Panel PrincipalPanel, IParkingRepository ParkingRepository, CountryHandler ActualCountry)
        {
            InitializeComponent();
            Panel = PrincipalPanel;
            Repository = ParkingRepository;
            CountryHandler = ActualCountry;
        }     

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Panel.Visible = true;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmpty();
        }

        private void ValidateEmpty()
        {
            if(CountryHandler.ValidateIsEmptyByCountry(txtNumberPhone.Text))
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string TextOfPhone = txtNumberPhone.Text;
                TextOfPhone = TextOfPhone.Replace(" ", "");
                ValidateFormatNumber(TextOfPhone);
            }
        }

        private void ValidateFormatNumber(string TextOfPhone)
        {
            if (CountryHandler.ValidateFormatNumberByCountry(ref TextOfPhone))
                if (CountryHandler.ValidateIsNumericByCountry(TextOfPhone))
                    ValidateRepeatNumber(TextOfPhone);
                else
                    SetMessage("El número que ingresó no es númerico.");
            else
                SetMessage("El número no coincide con el formato.");
        }

        private void ValidateRepeatNumber(string TextOfPhone)
        {
            if (Repository.GetAccounts().ToArray().Length > 0)
                if (!Repository.IsRepeatedNumber(TextOfPhone))
                    AddAccount(TextOfPhone);
                else
                    SetMessage("El número que ingresó ya está registrado.");
            else
                AddAccount(TextOfPhone);
        }

        private void AddAccount(string TextOfPhone)
        {
            Account NewAccount = new Account(0, TextOfPhone, CountryHandler);
            Repository.AddAccount(NewAccount);
            MessageAccountAdded();
        }

        private void MessageAccountAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            txtNumberPhone.Clear();
            SetMessage("La cuenta ha sido registrada correctamente.");           
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
