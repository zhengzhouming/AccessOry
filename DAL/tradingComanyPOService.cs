using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tradingComanyPOService
    {
        public int isHaveByTradingComanyPO(string Tpo)
        {
            string sql = @"SELECT GTN_PO FROM `gtn_po` WHERE GTN_PO ='"+ Tpo + "'";           
            DataTable result = Mysqlfsg_SqlHelper.ExcuteTable(sql);
            return result.Rows.Count;
        }
        public int writeGtnsToDb(DataTable dt)
        {
            string sqlstr = "";
            string sqlValue = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlValue = sqlValue +
                           "(\"" + dt.Rows[i]["PO"].ToString() + "\",\""
                               + dt.Rows[i]["GTN_PO"].ToString() + "\",\""
                               + dt.Rows[i]["create_pc"].ToString() + "\",\""
                               + dt.Rows[i]["update_date"].ToString() + "\" ),";
            }
            sqlValue = sqlValue.Substring(0, sqlValue.Length - 1) + ";";
            sqlstr = @"INSERT INTO gtn_po ( PO, GTN_PO, create_pc, update_date
                    )  VALUES " + sqlValue;

            int result = Mysqlfsg_SqlHelper.ExecuteNonQuery(sqlstr);
            return result;
        }


        public int delDoubleRows()
        {
            string sql = @"
                            DELETE 
                            FROM
	                            GTN_PO 
                            WHERE
	                            id IN (
	                            SELECT
		                            a.id 
	                            FROM
		                            (
		                            SELECT
			                            id 
		                            FROM
			                            gtn_po a 
		                            WHERE
			                            ( a.po, a.GTN_PO ) IN ( SELECT po, gtn_po FROM gtn_po GROUP BY po, gtn_po HAVING count(*) > 1 ) 
		                            ) a 
	                            ) 
	                            AND ID NOT IN ( select b.id from ( SELECT max( ID ) id FROM GTN_PO GROUP BY po, gtn_po HAVING count(*)> 1 ) b )

                            ";
            int result = Mysqlfsg_SqlHelper.ExecuteNonQuery(sql);
            return result;
        }
    }
}
