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
        Panel panel;
        ISystemController system;

        public AddBalance(Panel principalPanel, ISystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            if (txtNumberPhone.Text.Length == 0)
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string text = txtNumberPhone.Text;
                text = text.Replace(" ", "");
                if (system.ValidateLengthNumber(ref text))
                    ValidateNumberFormat(text);
                else
                    SetMessage("El número no coincide con el formato.");
            }
        }

        private void ValidateNumberFormat(string text)
        {
            if (system.ValidateIsNumeric(text))
                ValidateRepeatNumber(text);
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string text)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            {
                if (system.ValidateRepeatNumber(text))
                {
                    ValidateBalance(system.getAnAccount(text));
                }
                else
                    SetMessage("El número que ingresó no está registrado.");
            }
        }

        private void ValidateBalance(IAccount account)
        {
            if (txtBalanceToAdd.Text.Length > 0)
            {
                int balance = 0;
                if (Int32.TryParse(txtBalanceToAdd.Text, out balance))
                    if (balance > 0)
                        AddBalanceToAccount(account, balance);
                    else
                        SetMessage("Debe ingresar un saldo valido.");
                else
                    SetMessage("Debe ingresar un saldo númerico.");
            }
            else
                SetMessage("Debe ingresar un saldo.");
        }

        private void AddBalanceToAccount(IAccount account, int balanceToAdd)
        {
            account.AddBalance(balanceToAdd);
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Saldo de la cuenta actualizado.");
            txtBalanceToAdd.Clear();
            txtNumberPhone.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        public void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void timerOfAnswer_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
