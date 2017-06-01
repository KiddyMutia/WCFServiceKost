using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    public class AdminService : IAdminService
    {
        public List<AdminInfo> loginAdmin(string username, string password)
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<AdminInfo> objList = new List<AdminInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select * from tb_admin where username =  @username and password = @password ";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@email", username);
                    sqlcom.Parameters.AddWithValue("@password", password);
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.Read())
                    {
                        AdminInfo obj = new AdminInfo();
                        obj.IDAdmin = dr.GetString(1);
                        obj.NameAdmin = dr.GetString(2);
                        obj.UsernameAdmin = dr.GetString(3);
                        obj.AddressAdmin = dr.GetString(5);
                        obj.PhoneNumberAdmin = dr.GetString(6);
                        obj.TypeAdmin = dr.GetString(7);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }
    }
}
