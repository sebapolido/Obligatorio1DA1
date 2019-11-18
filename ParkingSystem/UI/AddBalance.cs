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
    public partial class AddBalance : UserControl
    {
        private Panel Panel;
        private IParkingRepository Repository;
        private CountryHandler CountryHandler;

        public AddBalance(Panel PrincipalPanel, IParkingRepository ParkingRepository, CountryHandler ActualCountry)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmptyNumber();
        }

        private void ValidateEmptyNumber()
        {
            if (CountryHandler.ValidateIsEmptyByCountry(txtNumberPhone.Text))
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string TextOfPhone = txtNumberPhone.Text;
                TextOfPhone = TextOfPhone.Replace(" ", "");
                ValidateNumberFormat(TextOfPhone);
            }
        }

        private void ValidateNumberFormat(string TextOfPhone)
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
            if (Repository.IsRepeatedNumber(TextOfPhone))
                ValidateEmptyBalance(TextOfPhone);
            else
                SetMessage("El número que ingresó no está registrado.");
        }

        private void ValidateEmptyBalance(string TextOfPhone)
        {
            if (!CountryHandler.ValidateIsEmptyByCountry(TextOfPhone))
                ValidateBalance(TextOfPhone);
            else
                SetMessage("Debe ingresar un saldo.");
        }

        private void ValidateBalance(string TextOfPhone)
        {
            const int MIN_BALANCE_TO_ADD = 1;
            if (Int32.TryParse(txtBalanceToAdd.Text, out int balance))
                if (balance >= MIN_BALANCE_TO_ADD)
                   AddBalanceToAccount(TextOfPhone, balance);
                else
                   SetMessage("Debe ingresar un saldo válido.");
            else
                SetMessage("Debe ingresar un saldo númerico.");
        }

        private void AddBalanceToAccount(string TextOfPhone, int BalanceToAdd)
        {
            Account Account = Repository.GetAnAccount(TextOfPhone);
            Repository.AddBalanceToAccount(Account, BalanceToAdd);
            MessageBalanceAdded();
        }

        private void MessageBalanceAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Saldo de la cuenta actualizado.");
            txtBalanceToAdd.Clear();
            txtNumberPhone.Clear();
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

        private void AddBalance_Load(object sender, EventArgs e)
        {

        }
    }
}