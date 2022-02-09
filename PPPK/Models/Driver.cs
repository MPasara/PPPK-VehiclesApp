using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK.Models
{
    public class Driver
    {
        public int IDDriver { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public override string ToString() => $"ID: {IDDriver}, First name: {Firstname}, Surname: {Surname}";

        public Driver()
        {
        }

        public Driver(int iDDriver, string firstname, string surname, string phoneNumber, string drivingLicenceNumber)
            :this(firstname, surname, phoneNumber, drivingLicenceNumber)
        {
            IDDriver = iDDriver;
        }

        public Driver(string firstname, string surname, string phoneNumber, string drivingLicenceNumber)
        {
            Firstname = firstname;
            Surname = surname;
            PhoneNumber = phoneNumber;
            DrivingLicenceNumber = drivingLicenceNumber;
        }
    }
}
