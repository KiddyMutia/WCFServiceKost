using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomTypeService" in code, svc and config file together.
    public class RoomTypeService : IRoomTypeService
    {
        public List<RoomTypeInfo> getTotalRoomType()
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<RoomTypeInfo> objList = new List<RoomTypeInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select b.name,COUNT(b.name) as jumlah from tb_room a inner join tb_room_type b on a.id_room_type = b.id_room_type where a.status = 'Available' group by b.name";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        RoomTypeInfo obj = new RoomTypeInfo();
                        obj.TipeRoomType = dr.GetString(0);
                        obj.TotalRoomType = (int) dr.GetInt32(1);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }

        public List<RoomTypeInfo> getRoomType()
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<RoomTypeInfo> objList = new List<RoomTypeInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from tb_room_type";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        RoomTypeInfo obj = new RoomTypeInfo();
                        obj.IDRoomType = dr.GetString(1);
                        obj.TipeRoomType = dr.GetString(2);
                        obj.PriceRoomType = (int)dr.GetInt64(3);
                        obj.InfoRoomType = dr.GetString(4);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }


    }
}
