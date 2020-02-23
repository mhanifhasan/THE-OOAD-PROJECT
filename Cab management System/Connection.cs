using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System
{
    public class Connection
    {
        public static SqlConnection sc;

        public static SqlConnection Get()
        {
            if (sc == null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = "workstation id=cabmanagementDBMS.mssql.somee.com;packet size=4096;user id=AGTxRED_SQLLogin_1;pwd=n9gnis4ozn;data source=cabmanagementDBMS.mssql.somee.com;persist security info=False;initial catalog=cabmanagementDBMS";
                //sc.ConnectionString = ConfigurationManager.ConnectionStrings[MyConnection].ToString();
                sc.Open();


            }
            return sc;
        }
    }
}