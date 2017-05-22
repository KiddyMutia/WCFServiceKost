using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    public class UserService : IUserService
    {
        public List<UserInfo> getUser()
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<UserInfo> objList = new List<UserInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from tb_customer";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        UserInfo obj = new UserInfo();
                        obj.IDUser = dr.GetString(1);
                        obj.NameUser = dr.GetString(2);
                        
                        //Convert Date Time to String.
                        DateTime dt = Convert.ToDateTime(dr.GetDateTime(3));

                        obj.BirthdateUser = dt.ToString("dd-MM-yyyy");
                        obj.AddressUser = dr.GetString(4);
                        obj.PhoneNumberUser = dr.GetString(5);
                        obj.Card_typeUser = dr.GetString(6);
                        obj.Card_numberUser = dr.GetString(7);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }

        public List<UserInfo> getUserID(string nama)
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<UserInfo> objList = new List<UserInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from tb_customer where name like @nama ";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@nama", '%'+nama+'%');
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        UserInfo obj = new UserInfo();
                        obj.IDUser = dr.GetString(1);
                        obj.NameUser = dr.GetString(2);
                        //Convert Date Time to String.
                        DateTime dt = Convert.ToDateTime(dr.GetDateTime(3));

                        obj.BirthdateUser = dt.ToString("dd-MM-yyyy");
                        obj.AddressUser = dr.GetString(4);
                        obj.PhoneNumberUser = dr.GetString(5);
                        obj.Card_typeUser = dr.GetString(6);
                        obj.Card_numberUser = dr.GetString(7);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }

        public List<UserInfo> loginUser(string email,string password)
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<UserInfo> objList = new List<UserInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from tb_customer where email =  @email and password = @password ";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@email", email);
                    sqlcom.Parameters.AddWithValue("@password", password);
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        UserInfo obj = new UserInfo();
                        obj.IDUser = dr.GetString(1);
                        obj.NameUser = dr.GetString(2);
                        //Convert Date Time to String.
                        DateTime dt = Convert.ToDateTime(dr.GetDateTime(3));

                        obj.BirthdateUser = dt.ToString("dd-MM-yyyy");
                        obj.AddressUser = dr.GetString(4);
                        obj.PhoneNumberUser = dr.GetString(5);
                        obj.Card_typeUser = dr.GetString(6);
                        obj.Card_numberUser = dr.GetString(7);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }

        





        public string insertUser(UserInfo data)
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            string msg = string.Empty;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "insert tb_customer (name,birthdate,address,phonenumber,card_type,card_number,email,password) values(@nama, @birthdate, @alamat, @nohp, @cardtype, @cardnumber, @email, @password)";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@nama", data.NameUser);
                    sqlcom.Parameters.AddWithValue("@birthdate", data.BirthdateUser);
                    sqlcom.Parameters.AddWithValue("@alamat", data.AddressUser);
                    sqlcom.Parameters.AddWithValue("@nohp", data.PhoneNumberUser);
                    sqlcom.Parameters.AddWithValue("@cardtype", data.Card_typeUser);
                    sqlcom.Parameters.AddWithValue("@cardnumber", data.Card_numberUser);
                    sqlcom.Parameters.AddWithValue("@email", data.EmailUser);
                    sqlcom.Parameters.AddWithValue("@password", data.PasswordUser);
                    int res = sqlcom.ExecuteNonQuery();
                    msg = (res != 0 ? "Data has been saved." : "Oops, something went wrong.");
                }
                sqlcon.Close();
            }
            return msg;
        }
        public string updateUser(UserInfo data)
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            string msg = string.Empty;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "update tb_customer set name = @nama, alamat = @alamat, card_type = @cardtype, card_number = @cardnumber where id_customer = @id";
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
