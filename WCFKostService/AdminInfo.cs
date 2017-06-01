using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFKostService
{
    [DataContract]
    public class AdminInfo
    {
        string id, name, address, nohp, type, username, password;

        [DataMember]
        public string IDAdmin
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string NameAdmin
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string AddressAdmin
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string PhoneNumberAdmin
        {
            get { return nohp; }
            set { nohp = value; }
        }

        [DataMember]
        public string TypeAdmin
        {
            get { return type; }
            set { type = value; }
        }
       
        [DataMember]
        public string UsernameAdmin
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string PasswordAdmin
        {
            get { return password; }
            set { password = value; }
        }
    }
}