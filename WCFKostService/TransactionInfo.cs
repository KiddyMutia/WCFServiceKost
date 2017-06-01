using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace WCFKostService
{
    [DataContract]
    public class TransactionInfo
    {
        string id, room, namecustomer, datein, dateout, status;

        [DataMember]
        public string IDTransaction
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string RoomTransaction
        {
            get { return room; }
            set { room = value; }
        }
        [DataMember]
        public string NameCustomerTransaction
        {
            get { return namecustomer; }
            set { namecustomer = value; }
        }

        [DataMember]
        public string StatusTransaction
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public string DateInTransaction
        {
            get { return datein; }
            set { datein = value; }
        }

        [DataMember]
        public string DateOutTransaction
        {
            get { return dateout; }
            set { dateout = value; }
        }
    }
}