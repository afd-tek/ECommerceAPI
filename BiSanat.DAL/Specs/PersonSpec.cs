using System;
using System.Collections.Generic;
using System.Text;

namespace BiSanat.DAL.Specs
{
    public class PersonSpec
    {
        public int? Id;
        public string FullName;
        public string Phone;
        public string Email;
        public string Password;
        public string Address;
        public string DeviceToken;
        public DateTime? BirthDate;
        public bool? Gender;
    }
}
