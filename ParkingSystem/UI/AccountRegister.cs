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
        Panel panel;
        SystemController system;

        public AccountRegister(Panel principalPanel, SystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
        }

        private void AccountRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;

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
                if (system.ValidateLengthNumber(text))
                    ValidateNumberFormat(text);
                else
                    SetMessage("El número no coincide con el formato.");
            }
        }

       /* private void ValidateLengthNumber()
        {
            string text = txtNumberPhone.Text;
            text = text.Replace(" ", "");
            bool isEquals = false;
            if (text.Length == 9 && text[0].Equals('0') && text[1].Equals('9'))
            {
                ValidateNumberFormat(text, isEquals);
            }
            else if (text.Length == 8 && text[0].Equals('9'))
            {
                text = text.Insert(0, "0");
                ValidateNumberFormat(text, isEquals);
            }
            else
            {
                SetMessage("El número no coincide con el formato.");
            }
        }*/

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
                if (!system.ValidateRepeatNumber(text))
                {
                    AddAccount(text);
                }
                else
                    SetMessage("El número que ingresó ya está registrado.");
            }
            else
                AddAccount(text);
        }

        private void AddAccount(string text)
        {
            system.AddAccount(new Account(0, text));
            lblAnswer.ForeColor = Color.Green;
            SetMessage("La cuenta ha sido registrada correctamente.");
            txtNumberPhone.Clear();

        }

        public void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void timerOfError_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
