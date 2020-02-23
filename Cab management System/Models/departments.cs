using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class departments
    {
        public int department_id { get; set; }
        public string department_name { get; set; }
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


       // department_id int primary key identity not null,department_name varchar(255) not null, admin_id int  , admin_action_time datetime)

        public void Add()
        {

            string a = "insert into departments values('" + department_name + "'," + admin_id + ",getdate())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<departments> ShowAll()
        {
            string a = " select * from departments";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<departments> lst = new List<departments>();

            while (sdr.Read())
            {
                departments c = new departments()
                {
                    department_id = (int)sdr["department_id"],
                    department_name = (string)sdr["department_name"],
                    
                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public departments Search()
        {
            string a = " select * from departments where department_id = " + department_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<departments> lst = new List<departments>();

            departments c = new departments();

            while (sdr.Read())
            {
                c.department_id = (int)sdr["department_id"];
                c.department_name = (string)sdr["department_name"];
                
                c.admin_id = (int)sdr["admin_id"];
                c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  departments set department_name='" + department_name + "',admin_id=" + admin_id + ",admin_action_time = getdate()  where department_id = " + department_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  departments where department_id = " + department_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}