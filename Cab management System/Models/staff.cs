using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class staff
    {
        public int staff_id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public int job_id { get; set; }
        public int department_id { get; set; }
        public string username { get; set; }
        public string pword { get; set; }
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


// staff (staff_id int primary key identity not null , name varchar(255) not null,city varchar(255) not null,job_id int foreign key references job_titles(job_id)  not null,
//staff_id int foreign key references staff(staff_id) not null,username varchar(255) not null,pword varchar(255) not null, admin_id int  , admin_action_time datetime 

        public void Add()
        {

            string a = "insert into staff values('" + name + "','" + city + "'," + job_id + "," + department_id + ",'" + username + "','" + pword + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<staff> ShowAll()
        {
            string a = " select * from staff";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<staff> lst = new List<staff>();

            while (sdr.Read())
            {
                staff c = new staff()
                {
                    staff_id = (int)sdr["staff_id"],
                    name = (string)sdr["name"],
                    city = (string)sdr["city"],
                    job_id = (int)sdr["job_id"],
                    department_id = (int)sdr["department_id"],
                    username = (string)sdr["username"],
                    pword = (string)sdr["pword"],
                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public staff Search()
        {
            string a = " select * from staff where staff_id = " + staff_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<staff> lst = new List<staff>();

            staff c = new staff();

            while (sdr.Read())
            {
               c.staff_id = (int)sdr["staff_id"];
               c.name = (string)sdr["name"];
               c.city = (string)sdr["city"];
               c.job_id = (int)sdr["job_id"];
               c.department_id = (int)sdr["department_id"];
               c.username = (string)sdr["username"];
               c.pword = (string)sdr["pword"];
               c.admin_id = (int)sdr["admin_id"];
               c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  staff set name='" + name + "',city='" + city + "',job_id=" + job_id + ",department_id=" + department_id + ",username='" + username + "',pword='" + pword + "',admin_id=" + admin_id + ",admin_action_time = getdate()  where staff_id = " + staff_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  staff where staff_id = " + staff_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}