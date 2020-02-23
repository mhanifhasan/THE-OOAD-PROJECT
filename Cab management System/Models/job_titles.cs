using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class job_titles
    {
        public int job_id { get; set; }
        public string job_title { get; set; }
        public int salary { get; set; }
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }
        

        //job_id int primary key identity not null,job_title varchar(255) not null
        //,salary int CHECK (salary>=0) not null, admin_id int , admin_action_time datetime

        public void Add()
        {

            string a = "insert into job_titles values('" + job_title + "'," + salary + "," + admin_id + ",getdate())";
            SqlCommand sc = new SqlCommand(a,Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<job_titles> ShowAll()
        {
            string a = " select * from job_titles";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<job_titles> lst = new List<job_titles>();

            while (sdr.Read())
            {
                job_titles c = new job_titles()
                {
                    job_id =(int)sdr["job_id"],
                    job_title = (string)sdr["job_title"],
                    salary = (int)sdr["salary"],
                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public job_titles Search()
        {
            string a = " select * from job_titles where job_id = " + job_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<job_titles> lst = new List<job_titles>();
            
                job_titles c = new job_titles();
             
            while (sdr.Read())
            {
                    c.job_id =(int)sdr["job_id"];
                    c.job_title = (string)sdr["job_title"];
                    c.salary = (int)sdr["salary"];
                    c.admin_id = (int)sdr["admin_id"];
                    c.admin_action_time = (DateTime)sdr["admin_action_time"];
                
                
            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  job_titles set job_title='" + job_title + "',salary=" + salary + ",admin_id=" + admin_id + ",admin_action_time = getdate()  where job_id = " + job_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  job_titles where job_id = " + job_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
    }
