//GBAKFramework 3.0.0
using System;
using System.Data.Linq;
using System.Collections.Generic;

namespace GBAK
{
    public partial class bb
    {

        public class EXEC
        {
            DataContext d;
            public EXEC(ref DataContext d)
            {
                this.d = d;
            }

            public SP.service_belgedogrulama_get service_belgedogrulama_get(byte? tip)
            {
                System.Data.SqlClient.SqlParameter[] param = new System.Data.SqlClient.SqlParameter[0];
                int i2 = 0;
                if ((tip) != null) { Array.Resize(ref param, i2 + 1); param[i2] = new System.Data.SqlClient.SqlParameter("@tip", tip); i2 = i2 + 1; }

                System.Data.DataSet ds = Engine.ExecutionModel.Exec("service_belgedogrulama_get", param);
                SP.service_belgedogrulama_get temp = new SP.service_belgedogrulama_get();
                List<SP.service_belgedogrulama_get_rtn> service_belgedogrulama_get_rtn = new List<SP.service_belgedogrulama_get_rtn>();
                if (ds.Tables.Count < 1)
                {
                    temp.rtn = null;
                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        service_belgedogrulama_get_rtn.Add(new SP.service_belgedogrulama_get_rtn
                        {
                            id = (ds.Tables[0].Rows[i]["id"] is DBNull ? null : (int?)Convert.ToInt32(ds.Tables[0].Rows[i]["id"])),
                            barkodno = (ds.Tables[0].Rows[i]["barkodno"] is DBNull ? null : (string)Convert.ToString(ds.Tables[0].Rows[i]["barkodno"])),
                            pid = (ds.Tables[0].Rows[i]["pid"] is DBNull ? null : (int?)Convert.ToInt32(ds.Tables[0].Rows[i]["pid"])),
                            tckimlikno = (ds.Tables[0].Rows[i]["tckimlikno"] is DBNull ? null : (string)Convert.ToString(ds.Tables[0].Rows[i]["tckimlikno"]))
                        });

                    }
                }
                temp.rtn = service_belgedogrulama_get_rtn;
                return temp;
            }

            public void service_belgedogrulama_set(int? serviceid, int? profilid, byte? belgedurum, DateTime? belgetarih, byte? tip)
            {
                System.Data.SqlClient.SqlParameter[] param = new System.Data.SqlClient.SqlParameter[0];
                int i2 = 0;
                if ((serviceid) != null) { Array.Resize(ref param, i2 + 1); param[i2] = new System.Data.SqlClient.SqlParameter("@serviceid", serviceid); i2 = i2 + 1; }
                if ((profilid) != null) { Array.Resize(ref param, i2 + 1); param[i2] = new System.Data.SqlClient.SqlParameter("@profilid", profilid); i2 = i2 + 1; }
                if ((belgedurum) != null) { Array.Resize(ref param, i2 + 1); param[i2] = new System.Data.SqlClient.SqlParameter("@belgedurum", belgedurum); i2 = i2 + 1; }
                if ((belgetarih) != null) { Array.Resize(ref param, i2 + 1); param[i2] = new System.Data.SqlClient.SqlParameter("@belgetarih", belgetarih); i2 = i2 + 1; }
                if ((tip) != null) { Array.Resize(ref param, i2 + 1); param[i2] = new System.Data.SqlClient.SqlParameter("@tip", tip); i2 = i2 + 1; }
                Engine.ExecutionModel.Exec("service_belgedogrulama_set", param);
            }

        }
    }
}
