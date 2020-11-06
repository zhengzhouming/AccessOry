using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace DAL
{
    public class deliveryCompareService
    {
        public DataTable getSubinv(string org)
        {
            string sql = @"SELECT DISTINCT subinv from location WHERE ORG ='"+ org + "' AND subinv LIKE '%HD'";
            DataTable result = Mysqlfsg_SqlHelper.ExcuteTable(sql);
            return result;
        }

        public DataTable getLocations(string org, string  subinv)
        {
            string sql = @"SELECT DISTINCT location  from location WHERE ORG ='"+ org + @"' and subinv ='"+ subinv + "' AND location LIKE 'CF%D'";
            DataTable result = Mysqlfsg_SqlHelper.ExcuteTable(sql);
            return result;
        }

        public int writeCompareFileToDb(DataTable dt)
        {



			//先删除上次上传的资料 update  Create_pc =  Dns.HostName and isDel =0 为   isDel =1
			string upsql = @"
						UPDATE delivertb 
								SET isDel = 1 
								WHERE
									Create_Pc = '" + Dns.GetHostName() +@"' 
									AND isDel =0 ";
			Mysqlfsg_SqlHelper.ExecuteNonQuery(upsql);

			// 再更新这次上传的资料
			string sqlstr = "";
            string sqlValue = "";
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlValue = sqlValue +
                           "(\"" + dt.Rows[i]["lineName"].ToString() + "\",\""
                               + dt.Rows[i]["deliveryDate"].ToString() + "\",\""
                               + dt.Rows[i]["invoiceNo"].ToString() + "\",\""
                               + dt.Rows[i]["styleId"].ToString() + "\",\""
                               + dt.Rows[i]["gtnPO"].ToString() + "\",\""
                               + dt.Rows[i]["idNoName"].ToString() + "\",\""
                               + dt.Rows[i]["colorId"].ToString() + "\",\""
                               + dt.Rows[i]["sizeName"].ToString() + "\",\""
                               + dt.Rows[i]["qty"].ToString() + "\",\""
                               + Dns.GetHostName() + "\",\""
                               + 0 + "\",\""
                               + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" ),";
            }
            sqlValue = sqlValue.Substring(0, sqlValue.Length - 1) + ";";
            sqlstr = @"INSERT INTO delivertb (  lineName, deliveryDate, invoiceNo, styleId, gtnPO, idNoName, colorId, sizeName, qty,create_pc,isDel,createDate )  VALUES " + sqlValue;

            int result = Mysqlfsg_SqlHelper.ExecuteNonQuery(sqlstr);
            return result;
        }

        public DataTable getLocalHostDt(string starTime, string stopTime, string org, string subinv, List<string> location)
		{
			string locations = "";
            if (location.Count <= 0)
            {
				DataTable dt = new DataTable();
				return dt;
            }
			for( int i=0; i< location.Count; i++)
            {
				locations = locations + location[i] + "','";
            }
			locations =locations.Substring(0, locations.Length - 2);
			locations = "'"+ locations;

			string sql = @"SELECT

									DATE_FORMAT( a.ScanTime, '%Y-%m-%d' ) AS ScanTime,
									d.Buyer_Item,
									d.color_code,
									a.location,
									CASE		
											WHEN t.AFTER != NULL THEN
											t.AFTER ELSE d.Size1 
										END Size1 ,	
									d.qty  size_qty 
								FROM
									(
									SELECT
										A.id,
										a.TagNumber,
										a.cust_id,
										a.location,
										a.Update_Date,
										a.org,
										a.con_no,
										a.Create_Pc,
										a.kg,
										a.subinv,
										a.ScanTime 
									FROM
										inv A,
										(
										SELECT
											id,
											min( ScanTime ) min_time 
										FROM
											inv 
										WHERE
										  DATE_FORMAT(scantime , '%Y-%m-%d')       BETWEEN    STR_TO_DATE('" + starTime + @"','%Y-%m-%d') 
																		AND  STR_TO_DATE('" + stopTime + @"','%Y-%m-%d' )

											 
											AND org = '" + org + @"' 
											AND subinv = '" + subinv +@"'
											AND location in (" + locations + @")
										GROUP BY
											ScanTime,
											id 
										ORDER BY
											ScanTime 
										) B 
									WHERE
										A.id = B.id 
										AND A.ScanTime = B.min_time 
									) a
									LEFT JOIN con_ppr p ON a.con_no = p.Serial_From
									LEFT JOIN con_detail d ON a.con_no = d.Serial_From 
									AND p.PPrfNo = d.pprfno 
									LEFT JOIN transize t on d.Size1  = t.AFTER 
											 OR d.Size1 = t.BEFORE 
								GROUP BY
									DATE_FORMAT( a.ScanTime, '%Y-%m-%d' ) ,
									d.Buyer_Item,
									d.color_code,
									d.Size1	
								ORDER BY
									DATE_FORMAT( a.ScanTime, '%Y-%m-%d' ) ,
									a.con_no,
									d.Size1 + 0;";
            DataTable result = Mysqlfsg_SqlHelper.ExcuteTable(sql);
            return result;
        }

		public DataTable getFromWriteExcel(string createPC, string starTime, string stopTime)
		{
			string sql = @"SELECT
								d.lineName,
								d.DeliveryDate,
								d.styleId,
								d.colorId,
							CASE
								WHEN t.AFTER != NULL THEN
									t.AFTER ELSE d.sizeName 
								END sizeName,
								sum( d.Qty ) Qty 
							FROM
								delivertb d
								LEFT JOIN transize t ON d.sizeName = t.AFTER 
								OR d.sizeName = t.BEFORE 
							WHERE
								Create_Pc = '" + createPC + @"' 
								AND isdel = 0 
								AND deliveryDate    BETWEEN    STR_TO_DATE('" + starTime + @"','%Y-%m-%d') 
								AND  STR_TO_DATE('" + stopTime + @"','%Y-%m-%d' )
								AND isDel =0
							GROUP BY
								lineName,
								DeliveryDate,
								styleId,
								colorId,
								sizeName 
							ORDER BY
								d.deliveryDate,
								d.lineName,
								d.styleId,
								d.colorId,
								sizeName;";
			DataTable result = Mysqlfsg_SqlHelper.ExcuteTable(sql);
			return result;
		}
	}
}
