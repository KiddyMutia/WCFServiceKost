using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFKostService
{
    [DataContract]
    public class UserInfo
    {
        string id, name, address, birthdate, nohp, card_type, card_number, email, password;

        [DataMember]
        public string IDUser
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string NameUser
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string AddressUser
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string PhoneNumberUser
        {
            get { return nohp; }
            set { nohp = value; }
        }

        [DataMember]
        public string BirthdateUser
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        [DataMember]
        public string Card_typeUser
        {
            get { return card_type; }
            set { card_type = value; }
        }
        [DataMember]
        public string Card_numberUser
        {
            get { return card_number; }
            set { card_number = value; }
        }
        [DataMember]
        public string EmailUser
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public string PasswordUser
        {
            get { return password; }
            set { password = value; }
        }

    }
}