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
    public partial class Reports : UserControl
    {
        Panel Panel;
        IParkingRepository Repository;
        CountryHandler Country;
        ValidatorOfEnrollment ValidatorOfEnrollment;

        public Reports(Panel PrincipalPanel, IParkingRepository ParkingRepository, CountryHandler ActualCountry)
        {
            InitializeComponent();
            Panel = PrincipalPanel;
            Repository = ParkingRepository;
            Country = ActualCountry;
            rbtnEnrollments.Checked = true;
            AgregateItemsToComboBoxs();
            ValidatorOfEnrollment = new ValidatorOfEnrollment();
        }

        private void AgregateItemsToComboBoxs()
        {
            const int MIN_HOUR = 10;
            const int MAX_HOUR = 17;
            const int MIN_MINUTES = 0;
            const int MAX_MINUTES = 59;
            if (cboInitialHour.Items.Count == 0)
                for (int i = MIN_HOUR; i <= MAX_HOUR; i++)
                {
                    cboInitialHour.Items.Add(i);
                    cboFinalHour.Items.Add(i);
                }
            if (cboInitialMinutes.Items.Count == 0)
                for (int i = MIN_MINUTES; i <= MAX_MINUTES; i++)
                {
                    cboInitialMinutes.Items.Add(i);
                    cboFinalMinutes.Items.Add(i);
                }
            if (cboCountry.Items.Count == 0)
                for (int i = 0; i < Repository.GetCountries().ToArray().Length; i++)
                    cboCountry.Items.Add(Repository.GetCountries().ElementAt(i).NameOfCountry);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Panel.Visible = true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            if (rbtnEnrollments.Checked)
                ValidateFormatEnrollment();
            else
                ValidateDatesOfPurchases();
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
                    InsertPurchaseOfEnrollmentToDataGridView(EnrollmentOfPurchase);
                }
                else
                    SetMessage("No hay ninguna compra con esa matrícula.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void InsertPurchaseOfEnrollmentToDataGridView(Enrollment EnrollmentOfPurchase)
        {
            dgvReports.DataSource = Repository.InsertPurchaseOfEnrollmentToDataGridView(EnrollmentOfPurchase); /*PurchaseToAdd;//terminar*/
        }

        private void ValidateDatesOfPurchases()
        {
            if (!cboInitialHour.Text.Equals("") && !cboFinalHour.Text.Equals(""))
                if (!cboInitialMinutes.Text.Equals("") && !cboFinalMinutes.Text.Equals(""))
                    AssignDateTimes();                    
                else
                    SetMessage("Debe ingresar minutos de inicio y fin.");
            else
                SetMessage("Debe ingresar una hora de inicio y fin.");
        }

        private void AssignDateTimes()
        {
            int InitialHourOfPurchases = int.Parse(cboInitialHour.Text);
            int InitialMinutesOfPurchase = int.Parse(cboInitialMinutes.Text);
            DateTime InitialDateOfPurchase = new DateTime(lblInitialDateTime.Value.Year, lblInitialDateTime.Value.Month,
                lblInitialDateTime.Value.Day, InitialHourOfPurchases, InitialMinutesOfPurchase, 0);
            int FinalHourOfPurchases = int.Parse(cboFinalHour.Text);
            int FinalMinutesOfPurchase = int.Parse(cboFinalMinutes.Text);
            DateTime FinalDateOfPurchase = new DateTime(lblFinalDateTime.Value.Year, lblFinalDateTime.Value.Month,
                lblFinalDateTime.Value.Day, FinalHourOfPurchases, FinalMinutesOfPurchase, 0);
            ArePurchasesOnThatDate(InitialDateOfPurchase, FinalDateOfPurchase);
        }

        private void ArePurchasesOnThatDate(DateTime InitialDateOfPurchase, DateTime FinalDateOfPurchase)
        {
            List<Purchase> PurchasesOnThatDate = Repository.InsertPurchaseOnThatDate(InitialDateOfPurchase, FinalDateOfPurchase);
            if (!cboCountry.Text.Equals(""))
                PurchasesOnThatDate = Repository.EliminatePurchasesFromAnoterCountry(PurchasesOnThatDate, Repository.GetACountry(cboCountry.Text));
            dgvReports.DataSource = PurchasesOnThatDate;
        }

        private void RbtnEnrollments_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEnrollments.Checked)
            {
                pnlEnrollments.Visible = true;
                pnlPurchase.Visible = false;
            }
            else
            {
                pnlEnrollments.Visible = false;
                pnlPurchase.Visible = true;
            }
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
