using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFKostService
{
    [DataContract]
    public class MonthPaidInfo
    {
        string id, kamar, tgl, info;
        int total;

        [DataMember]
        public string IDTransaction
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string KamarMonthPaid
        {
            get { return kamar; }
            set { kamar = value; }
        }
        [DataMember]
        public string TglMonthPaid
        {
            get { return tgl; }
            set { tgl = value; }
        }
        [DataMember]
        public int TotalMonthPaid
        {
            get { return total; }
            set { total = value; }
        }

        [DataMember]
        public string InfoMonthPaid
        {
            get { return info; }
            set { info = value; }
        }
    }
}