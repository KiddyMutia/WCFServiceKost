using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFKostService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MonthPaidService" in code, svc and config file together.
    public class MonthPaidService : IMonthPaidService
    {
        public List<MonthPaidInfo> getMonthPaidByIDUser(string id)
        {
            // kode get data from sql server..
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            List<MonthPaidInfo> objList = new List<MonthPaidInfo>();
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "select c.id_transaction,b.name,a.date_time,a.total,a.info from tb_monthpaid a inner join tb_transaction c on c.id_transaction = a.id_transaction inner join tb_room b on c.id_room = b.id_room where c.id_transaction = @id";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcom)
                {
                    sqlcom.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    while (dr.Read())
                    {
                        MonthPaidInfo obj = new MonthPaidInfo();
                        obj.IDTransaction = dr.GetString(0);
                        obj.KamarMonthPaid = dr.GetString(1);
                        //Convert Date Time to String.
                        DateTime dt = Convert.ToDateTime(dr.GetDateTime(2));
                        obj.TglMonthPaid = dt.ToString("dd-MM-yyyy");
                        obj.TotalMonthPaid = (int) dr.GetInt32(3);
                        obj.InfoMonthPaid = dr.GetString(4);
                        objList.Add(obj);
                    }
                }
                sqlcon.Close();
            }
            return objList;
        }
    }
}
