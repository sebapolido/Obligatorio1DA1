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
        Panel Panel;
        IParkingRepository Repository;
        ValidatorOfEnrollment ValidatorOfEnrollment;
        
        public CheckPurchase(Panel PrincipalPanel, IParkingRepository ParkingRepository)
        {
            InitializeComponent();
            Panel = PrincipalPanel;
            Repository = ParkingRepository;
            ValidatorOfEnrollment = new ValidatorOfEnrollment();
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
            Panel.Visible = true;
        }

        private void BtnConsult_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateFormatEnrollment();
        }

        private void ValidateFormatEnrollment()
        {
            const int MAX_LENGTH_OF_Enrollment = 8;
            if (!ValidatorOfEnrollment.ValidateIsEmpty(txtEnrollment.Text))
                if (txtEnrollment.Text.Length <= MAX_LENGTH_OF_Enrollment)
                    ValidateFormatOfEnrollmentWithSpace();
                else
                    SetMessage("Debe ingresar una matrícula valida.");
            else
                SetMessage("Debe ingresar una matrícula.");
        }

        private void ValidateFormatOfEnrollmentWithSpace()
        {
            string[] Line = txtEnrollment.Text.Split(' ');
            if (Line.Length == 2 && ValidatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line))
                if (ValidatorOfEnrollment.ValidateFormatOfEnrollment(Line[0] + Line[1]))
                    ValidateRepeatEnrollment(Line[0], Line[1]);
                else
                    SetMessage("El formato de la matrícula no es válido.");
            else
                ValidateFormatOfEnrollmentWithoutSpace(Line);
        }

        private void ValidateFormatOfEnrollmentWithoutSpace(string[] Line)
        {
            if (ValidatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(Line))
                if (ValidatorOfEnrollment.ValidateFormatOfEnrollment(Line[0]))
                    ValidateRepeatEnrollment(Line[0].Substring(0, 3), Line[0].Substring(3));
                else
                    SetMessage("El formato de la matrícula no es válido.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateRepeatEnrollment(string Letters, string Numbers)
        {
            if (ValidatorOfEnrollment.ValidateIsNumeric(Numbers))
                if (Repository.IsRepeatedEnrollment(Letters, int.Parse(Numbers)))
                {
                    Enrollment EnrollmentOfPurchase = Repository.GetAnEnrollment(Letters, int.Parse(Numbers));
                    ValidateDate(EnrollmentOfPurchase);
                }
                else
                    SetMessage("No hay ninguna compra con esa matrícula.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateDate(Enrollment EnrollmentOfPurchase)
        {
            if (cboHour.Text != null)
                if (cboMinutes.Text != null)
                {
                    int HourOfPurchase = int.Parse(cboHour.Text);
                    int MinutesOfPurchase = int.Parse(cboMinutes.Text);
                    DateTime DateOfPurchase = new DateTime(lblDateTime.Value.Year, lblDateTime.Value.Month,
                        lblDateTime.Value.Day, HourOfPurchase, MinutesOfPurchase, 0);
                    ArePurchasesOnThatDate(DateOfPurchase, EnrollmentOfPurchase);
                }
                else
                    SetMessage("Debe ingresar un minuto.");
            else
                SetMessage("Debe ingresar una hora.");
        }

        private void ArePurchasesOnThatDate(DateTime Date, Enrollment Enrollment)
        {
            if (Repository.ArePurchaseOnThatDate(Date, Enrollment))
                MessageCorrectCheck();
            else
                SetMessage("No hay ninguna compra en ese horario.");

        }

        private void MessageCorrectCheck()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Existe una compra activa en ese horario.");
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
