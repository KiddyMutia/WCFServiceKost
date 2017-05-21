using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFKostService
{
    public class User
    {
        string id, name, address, birthdate, card_type, card_number;

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

    }
}