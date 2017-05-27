using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFKostService
{
    [DataContract]
    public class RoomTypeInfo
    {
        string id, tipe, info;
        int price, total;

        [DataMember]
        public string IDRoomType
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string TipeRoomType
        {
            get { return tipe; }
            set { tipe = value; }
        }
        [DataMember]
        public string InfoRoomType
        {
            get { return info; }
            set { info = value; }
        }

        [DataMember]
        public int TotalRoomType
        {
            get { return total; }
            set { total = value; }
        }

        [DataMember]
        public int PriceRoomType
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public string InfoMonthPaid
        {
            get { return info; }
            set { info = value; }
        }
    }
}