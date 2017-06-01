using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservationService" in code, svc and config file together.
    public class ReservationService : IReservationService
    {
        public List<ReservationInfo> getReservationFromID(string id)
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<ReservationInfo> objList = new List<ReservationInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select a.id_reservation,b.name,c.name as customer,a.date_time,a.status,a.info from tb_reservation a inner join tb_room_type b on b.id_room_type = a.id_room inner join tb_customer c on c.id_customer = a.id_customer where a.id_customer = @id";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        ReservationInfo obj = new ReservationInfo();
                        obj.IDReservation = dr.GetString(0);
                        obj.TipeRoomTypeReservation = dr.GetString(1);
                        obj.NameCustomerReservation = dr.GetString(2);
                        obj.DateTimeReservation = (string) dr.GetDateTime(3).ToString();
                        obj.StatusReservation = dr.GetString(4);
                        obj.InfoReservation = dr.GetString(5);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }

        public string insertData(ReservationInfo data)
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            string msg = string.Empty;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "insert into tb_reservation (id_room,id_customer,info) values (@idroom,@idcustomer,@info);";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@idroom", data.IDRoomReservation);
                    sqlcom.Parameters.AddWithValue("@idcustomer", data.IDCustomerReservation);
                    sqlcom.Parameters.AddWithValue("@info", data.InfoReservation);
                    int res = sqlcom.ExecuteNonQuery();
                    msg = (res != 0 ? "Data has been saved." : "Oops, something went wrong.");
                }
                sqlcon.Close();
            }
            return msg;
        }
    }
}
