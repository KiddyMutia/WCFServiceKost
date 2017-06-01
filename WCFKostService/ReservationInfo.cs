using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFKostService
{
    [DataContract]
    public class ReservationInfo
    {
        string id, idroom, idcustomer, tipe, namecustomer, date_time, info, status ;

        [DataMember]
        public string IDReservation
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string IDRoomReservation
        {
            get { return idroom; }
            set { idroom = value; }
        }

        [DataMember]
        public string IDCustomerReservation
        {
            get { return idcustomer; }
            set { idcustomer = value; }
        }

        [DataMember]
        public string TipeRoomTypeReservation
        {
            get { return tipe; }
            set { tipe = value; }
        }
        [DataMember]
        public string InfoReservation
        {
            get { return info; }
            set { info = value; }
        }

        [DataMember]
        public string NameCustomerReservation
        {
            get { return namecustomer; }
            set { namecustomer = value; }
        }

        [DataMember]
        public string StatusReservation
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public string DateTimeReservation
        {
            get { return date_time; }
            set { date_time = value; }
        }
    }
}