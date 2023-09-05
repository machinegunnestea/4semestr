using System;
using System.Globalization;

namespace lab2
{
    public enum Diseases
    {
        Flu = 12,
        Angina = 32,
        Pneumonia = 145,
        Gastritis = 98,
        Bronchitis = 67,
        Hypertension = 34,
        Covid = 777
    }
    struct Patient : IComparable<Patient>
    {
        private string lastName;
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        private int yearOfBirth;
        public int YearOfBirth
        {
            get => yearOfBirth;
            set => yearOfBirth = value;
        }

        private DateTime dateOfAdmission;
        public DateTime DateOfAdmission
        {
            get => dateOfAdmission;
            set => dateOfAdmission = value;

        }

        private int lengthOfTreatment;
        public int LengthOfTreatment
        {
            get => lengthOfTreatment;
            set => lengthOfTreatment = value;
        }

        private Diseases diagnosis;
        public Diseases Diagnosis
        {
            get => diagnosis;
            set => diagnosis = value;
        }

        private DateTime DurationOfHospitalStay => dateOfAdmission.AddDays(lengthOfTreatment);

        public int Age() => DateTime.Now.Year - DateTime.ParseExact(Convert.ToString(yearOfBirth), "yyyy", CultureInfo.InvariantCulture).Year;

        public override string ToString() => $"{lastName,-18} │ {DurationOfHospitalStay,-31} │ {Age(),-14}";

        public int CompareTo(Patient obj)
        {
            if (this.LengthOfTreatment > obj.LengthOfTreatment)
                return -1;
            if (this.LengthOfTreatment < obj.LengthOfTreatment)
                return 1;
            return 0;
        }
    }
}
