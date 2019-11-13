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
        Panel panel;
        IParkingRepository repository;
        CountryHandler country;
        ValidatorOfEnrollment validatorOfEnrollment;

        public Reports(Panel principalPanel, IParkingRepository parkingRepository, CountryHandler actualCountry)
        {
            InitializeComponent();
            panel = principalPanel;
            repository = parkingRepository;
            country = actualCountry;
            rbtnEnrollments.Checked = true;
            AgregateItemsToComboBoxs();
            validatorOfEnrollment = new ValidatorOfEnrollment();
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
                for (int i = 0; i < repository.GetCountries().ToArray().Length; i++)
                    cboCountry.Items.Add(repository.GetCountries().ElementAt(i).NameOfCountry);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
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
                    InsertPurchaseOfEnrollmentToDataGridView(enrollmentOfPurchase);
                }
                else
                    SetMessage("No hay ninguna compra con esa matrícula.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void InsertPurchaseOfEnrollmentToDataGridView(Enrollment enrollmentOfPurchase)
        {
            //List<Purchase> purchaseToAdd =
            dgvReports.DataSource = repository.InsertPurchaseOfEnrollmentToDataGridView(enrollmentOfPurchase); /*purchaseToAdd;//terminar*/
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
            int initialHourOfPurchases = int.Parse(cboInitialHour.Text);
            int initialMinutesOfPurchase = int.Parse(cboInitialMinutes.Text);
            DateTime initialDateOfPurchase = new DateTime(lblInitialDateTime.Value.Year, lblInitialDateTime.Value.Month,
                lblInitialDateTime.Value.Day, initialHourOfPurchases, initialMinutesOfPurchase, 0);
            int finalHourOfPurchases = int.Parse(cboFinalHour.Text);
            int finalMinutesOfPurchase = int.Parse(cboFinalMinutes.Text);
            DateTime finalDateOfPurchase = new DateTime(lblFinalDateTime.Value.Year, lblFinalDateTime.Value.Month,
                lblFinalDateTime.Value.Day, finalHourOfPurchases, finalMinutesOfPurchase, 0);
            ArePurchasesOnThatDate(initialDateOfPurchase, finalDateOfPurchase);
        }

        private void ArePurchasesOnThatDate(DateTime initialDateOfPurchase, DateTime finalDateOfPurchase)
        {
            List<Purchase> purchasesOnThatDate = repository.InsertPurchaseOnThatDate(initialDateOfPurchase, finalDateOfPurchase);
            if (!cboCountry.Text.Equals(""))
                purchasesOnThatDate = repository.EliminatePurchasesFromAnoterCountry(purchasesOnThatDate, repository.GetACountry(cboCountry.Text));
            dgvReports.DataSource = purchasesOnThatDate;
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
