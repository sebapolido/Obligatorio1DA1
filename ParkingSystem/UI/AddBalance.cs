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
        private SystemController system;
        private ValidatorOfPhone validatorOfPhone;

        public AddBalance(Panel principalPanel, SystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
            validatorOfPhone = new ValidatorOfPhone();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmpty();
        }

        private void ValidateEmpty()
        {
            if (validatorOfPhone.IsEmpty(txtNumberPhone.Text))
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
            if (system.IsRepeatedNumber(textOfPhone))
                ValidateBalance(textOfPhone);
            else
                SetMessage("El número que ingresó no está registrado.");
        }

        private void ValidateBalance(string textOfPhone)
        {
            if (txtBalanceToAdd.Text.Length > 0)
                if (Int32.TryParse(txtBalanceToAdd.Text, out int balance))
                    if (balance > 0)
                        AddBalanceToAccount(textOfPhone, balance);
                    else
                        SetMessage("Debe ingresar un saldo valido.");
                else
                    SetMessage("Debe ingresar un saldo númerico.");
            else
                SetMessage("Debe ingresar un saldo.");
        }

        private void AddBalanceToAccount(string textOfPhone, int balanceToAdd)
        {
            Account account = system.GetAnAccount(textOfPhone);
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
