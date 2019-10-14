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
        IParkingRepository repository;
        ValidatorOfEnrollment validatorOfEnrollment;
        
        public CheckPurchase(Panel principalPanel, IParkingRepository parkingRepository)
        {
            InitializeComponent();
            panel = principalPanel;
            repository = parkingRepository;
            validatorOfEnrollment = new ValidatorOfEnrollment();
            AgregateItemsToComboBoxs();
        }

        private void AgregateItemsToComboBoxs()
        {
            const int MIN_HOUR = 10;
            const int MAX_HOUR = 17;
            const int MIN_MINUTES = 0;
            const int MAX_MINUTES = 59;
            if (cboHour.Items.Count == 0)
                for (int i = MIN_HOUR; i <= MAX_HOUR; i++)
                    cboHour.Items.Add(i);
            if (cboMinutes.Items.Count == 0)
                for (int i = MIN_MINUTES; i <= MAX_MINUTES; i++)
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
            const int MAX_LENGTH_OF_ENROLLMENT = 8;
            if (!validatorOfEnrollment.ValidateIsEmpty(txtEnrollment.Text))
                if (txtEnrollment.Text.Length <= MAX_LENGTH_OF_ENROLLMENT)
                    ValidateFormatOfEnrollmentWithSpace();
                else
                    SetMessage("Debe ingresar una matrícula valida.");
            else
                SetMessage("Debe ingresar una matrícula.");
        }

        private void ValidateFormatOfEnrollmentWithSpace()
        {
            string[] line = txtEnrollment.Text.Split(' ');
            if (line.Length == 2 && validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithSpace(line))
                if (validatorOfEnrollment.ValidateFormatOfEnrollment(line[0] + line[1]))
                    ValidateRepeatEnrollment(line[0], line[1]);
                else
                    SetMessage("El formato de la matrícula no es válido.");
            else
                ValidateFormatOfEnrollmentWithoutSpace(line);
        }

        private void ValidateFormatOfEnrollmentWithoutSpace(string[] line)
        {
            if (validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line))
                if (validatorOfEnrollment.ValidateFormatOfEnrollment(line[0]))
                    ValidateRepeatEnrollment(line[0].Substring(0, 3), line[0].Substring(3));
                else
                    SetMessage("El formato de la matrícula no es válido.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateRepeatEnrollment(string letters, string numbers)
        {
            if (validatorOfEnrollment.ValidateIsNumeric(numbers))
                if (repository.IsRepeatedEnrollment(letters, int.Parse(numbers)))
                {
                    Enrollment enrollmentOfPurchase = repository.GetAnEnrollment(letters, int.Parse(numbers));
                    ValidateDate(enrollmentOfPurchase);
                }
                else
                    SetMessage("No hay ninguna compra con esa matrícula.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateDate(Enrollment enrollmentOfPurchase)
        {
            if (cboHour.Text != null)
                if (cboMinutes.Text != null)
                {
                    int hourOfPurchase = int.Parse(cboHour.Text);
                    int minutesOfPurchase = int.Parse(cboMinutes.Text);
                    DateTime dateOfPurchase = new DateTime(lblDateTime.Value.Year, lblDateTime.Value.Month,
                        lblDateTime.Value.Day, hourOfPurchase, minutesOfPurchase, 0);
                    ArePurchasesOnThatDate(dateOfPurchase, enrollmentOfPurchase);
                }
                else
                    SetMessage("Debe ingresar un minuto.");
            else
                SetMessage("Debe ingresar una hora.");
        }

        private void ArePurchasesOnThatDate(DateTime date, Enrollment enrollment)
        {
            if (repository.ArePurchaseOnThatDate(date, enrollment))
                MessageCorrectCheck();
            else
                SetMessage("No hay ninguna compra en ese horario.");

        }

        private void MessageCorrectCheck()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Existe una compra activa en ese horario.");
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
