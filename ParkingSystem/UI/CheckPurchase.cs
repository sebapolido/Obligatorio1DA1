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
    public partial class CheckPurchase : UserControl
    {
        Panel panel;
        SystemController system;
        ValidatorOfEnrollment validatorOfEnrollment;
        
        public CheckPurchase(Panel principalPanel, SystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
            validatorOfEnrollment = new ValidatorOfEnrollment();
            AgregateItemsToComboBoxs();
        }

        private void AgregateItemsToComboBoxs()
        {
            if (cboHour.Items.Count == 0)
                for (int i = 10; i < 18; i++)
                    cboHour.Items.Add(i);
            if (cboMinutes.Items.Count == 0)
                for (int i = 0; i < 60; i++)
                    cboMinutes.Items.Add(i);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        private void BtnConsult_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateFormatEnrollment();
        }

        private void ValidateFormatEnrollment()
        {
            if (txtEnrollment.Text.Length > 0 && txtEnrollment.Text.Length < 9)
            {
                string[] line = txtEnrollment.Text.Split(' ');
                ValidateFormatOfEnrollmentWithSpace(line);
            }
            else
                SetMessage("Debe ingresar una matrícula.");
        }

        private void ValidateFormatOfEnrollmentWithSpace(string[] line)
        {
            if (line.Length == 2 && validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithSpace(line))
            {
                if (validatorOfEnrollment.ValidateFormatOfEnrollment(line[0] + line[1]))
                    ValidateRepeatEnrollment(line[0], line[1]);
                else
                    SetMessage("El formato de la matrícula no es valido.");
            }
            else
                ValidateFormatOfEnrollmentWithOutSpace(line);
        }

        private void ValidateFormatOfEnrollmentWithOutSpace(string[] line)
        {
            if (validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line))
                if (validatorOfEnrollment.ValidateFormatOfEnrollment(line[0]))
                    ValidateRepeatEnrollment(line[0].Substring(0, 3), line[0].Substring(3));
                else
                    SetMessage("El formato de la matrícula no es valido.");
            else
                SetMessage("El formato de la matrícula no es valido.");
        }

        private void ValidateRepeatEnrollment(string letters, string numbers)
        {
            if (validatorOfEnrollment.ValidateIsNumeric(numbers))
                if (system.IsRepeatedEnrollment(letters, int.Parse(numbers)))
                {
                    Enrollment enrollment = system.GetAnEnrollment(letters, int.Parse(numbers));
                    ValidateDate(enrollment);
                }
                else
                    SetMessage("No hay ninguna compra con esa matrícula.");
            else
                SetMessage("El formato de la matrícula no es valido.");
        }

        private void ValidateDate(Enrollment enrollment)
        {
            if (cboHour.Text != null)
            {
                if (cboMinutes.Text != null)
                {
                    int hour = int.Parse(cboHour.Text);
                    int minutes = int.Parse(cboMinutes.Text);
                    DateTime date = new DateTime(lblDateTime.Value.Year, lblDateTime.Value.Month,
                        lblDateTime.Value.Day, hour, minutes, 0);
                    ArePurchasesOnThatDate(date, enrollment);
                }
                else
                    SetMessage("Debe ingresar un minuto.");
            }
            else
                SetMessage("Debe ingresar una hora.");
        }

        private void ArePurchasesOnThatDate(DateTime date, Enrollment enrollment)
        {
            if (system.ArePurchaseOnThatDate(date, enrollment))
                MessageCorrectCheck();
            else
                SetMessage("No hay ninguna compra con esa matrícula en ese horario.");

        }

        private void MessageCorrectCheck()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Existe una compra activa para esa matrícula en ese horario.");
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
