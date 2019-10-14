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
        private ValidatorOfPhone validatorOfPhone;

        public AddBalance(Panel principalPanel, IParkingRepository parkingRepository)
        {
            InitializeComponent();
            panel = principalPanel;
            repository = parkingRepository;
            validatorOfPhone = new ValidatorOfPhone();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmptyNumber();
        }

        private void ValidateEmptyNumber()
        {
            if (validatorOfPhone.ValidateIsEmpty(txtNumberPhone.Text))
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
            if (validatorOfPhone.ValidateIsNumeric(textOfPhone))
                if (validatorOfPhone.ValidateFormatNumber(ref textOfPhone))
                    ValidateRepeatNumber(textOfPhone);
                else
                    SetMessage("El número no coincide con el formato.");
            else
                SetMessage("El número que ingresó no es númerico.");
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
            if (!validatorOfPhone.ValidateIsEmpty(textOfPhone))
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
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