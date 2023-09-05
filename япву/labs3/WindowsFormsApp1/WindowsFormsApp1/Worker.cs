using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Worker
    {
        private string surname;
        private string firmName;
        private double payment;
        private DateTime birthDay;

        public Worker(string surname, string firmName, DateTime birthDay, double payment)
        {
            this.surname = surname;
            this.firmName = firmName;
            this.payment = payment;
            this.birthDay = birthDay;
        }

        public Worker() { }

        public string Surname
        {
            get { return surname; }
        }

        public string FirmName
        {
            get { return firmName; }
            set { firmName = value; }
        }
        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }
        public double Payment => payment;

        public double Age
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                int year = dateNow.Year - BirthDay.Year;
                if (dateNow.Month < BirthDay.Month || (dateNow.Month == BirthDay.Month &&
                    dateNow.Day < BirthDay.Day))
                {
                    year--;
                }
                return year;
            }
        }

    }
}
