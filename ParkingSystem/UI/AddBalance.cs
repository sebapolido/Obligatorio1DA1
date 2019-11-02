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
        private Panel panel;
        private IParkingRepository repository;
        private CountryHandler countryHandler;

        public AddBalance(Panel principalPanel, IParkingRepository parkingRepository, CountryHandler actualCountry)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmptyNumber();
        }

        private void ValidateEmptyNumber()
        {
            if (countryHandler.ValidateIsEmptyByCountry(txtNumberPhone.Text))
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string textOfPhone = txtNumberPhone.Text;
                textOfPhone = textOfPhone.Replace(" ", "");
                ValidateNumberFormat(textOfPhone);
            }
        }

        private void ValidateNumberFormat(string textOfPhone)
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
            if (repository.IsRepeatedNumber(textOfPhone))
                ValidateEmptyBalance(textOfPhone);
            else
                SetMessage("El número que ingresó no está registrado.");
        }

        private void ValidateEmptyBalance(string textOfPhone)
        {
            if (!countryHandler.ValidateIsEmptyByCountry(textOfPhone))
                ValidateBalance(textOfPhone);
            else
                SetMessage("Debe ingresar un saldo.");
        }

        private void ValidateBalance(string textOfPhone)
        {
            const int MIN_BALANCE_TO_ADD = 1;
            if (Int32.TryParse(txtBalanceToAdd.Text, out int balance))
                if (balance >= MIN_BALANCE_TO_ADD)
                   AddBalanceToAccount(textOfPhone, balance);
                else
                   SetMessage("Debe ingresar un saldo válido.");
            else
                SetMessage("Debe ingresar un saldo númerico.");
        }

        private void AddBalanceToAccount(string textOfPhone, int balanceToAdd)
        {
            Account account = repository.GetAnAccount(textOfPhone);
            account.AddBalance(balanceToAdd);
            MessageBalanceAdded();
        }

        private void MessageBalanceAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Saldo de la cuenta actualizado.");
            txtBalanceToAdd.Clear();
            txtNumberPhone.Clear();
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

        private void AddBalance_Load(object sender, EventArgs e)
        {

        }
    }
}