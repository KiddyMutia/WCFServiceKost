using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "User" in code, svc and config file together.
    public class User : IUser
    {
        public List<User> getUser()
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<User> objList = new List<User>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from tb_user";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        User obj = new User();
                        obj.IDUser = dr.GetString(1);
                        obj.NameUser = dr.GetString(2);
                        obj.AddressUser = dr.GetString(3);
                        obj.BirthdateUser = dr.GetString(4);
                        obj.Card_typeUser = dr.GetString(5);
                        obj.Card_numberUser = dr.GetString(6);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }
       
        
        public string insertUser(User data)
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            string msg = string.Empty;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "insert tb_user (name,address,birthdate,card_type,card_number) values(@nama, @alamat, @birthdate, @cardtype, @cardnumber)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@nama", data.NameUser);
                    sqlcom.Parameters.AddWithValue("@alamat", data.AddressUser);
                    sqlcom.Parameters.AddWithValue("@birthdate", data.BirthdateUser);
                    sqlcom.Parameters.AddWithValue("@cardtype", data.Card_typeUser);
                    sqlcom.Parameters.AddWithValue("@cardnumber", data.Card_numberUser);
                    int res = sqlcom.ExecuteNonQuery();
                    msg = (res != 0 ? "Data has been saved." : "Oops, something went wrong.");
                }
                sqlcon.Close();
            }
            return msg;
        }
        public string updateUser(User data)
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            string msg = string.Empty;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "update tb_user set name = @nama, alamat = @alamat, card_type = @cardtype, card_number = @cardnumber where id_customer = @id";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@id", data.IDUser);
                    sqlcom.Parameters.AddWithValue("@nama", data.NameUser);
                    sqlcom.Parameters.AddWithValue("@alamat", data.AddressUser);
                    sqlcom.Parameters.AddWithValue("@cardtype", data.Card_typeUser);
                    sqlcom.Parameters.AddWithValue("@cardnumber", data.Card_numberUser);
                    int res = sqlcom.ExecuteNonQuery();
                    msg = (res != 0 ? "Data has been updated." : "Oops, something went wrong.");
                }
                sqlcon.Close();
            }
            return msg;
        }
        
    }
}
