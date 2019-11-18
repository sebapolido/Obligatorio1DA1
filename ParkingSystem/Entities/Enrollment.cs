namespace ParkingSystem
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string LettersOfEnrollment { get; set; }
        public int NumbersOfEnrollment { get; set; }

        public Enrollment()
        {
            this.LettersOfEnrollment = "";
            this.NumbersOfEnrollment = 0;
        }

        public Enrollment(string NewLetter, int NewNumbers)
        {
            LettersOfEnrollment = NewLetter;
            NumbersOfEnrollment = NewNumbers;
        }

        public override string ToString()
        {
            return LettersOfEnrollment.ToUpper() + NumbersOfEnrollment;
        }
    }
}
