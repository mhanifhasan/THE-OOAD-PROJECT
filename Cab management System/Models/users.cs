using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class users
    {
        public int c_user_id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string father_name { get; set; }
       
        public string username { get; set; }
        public string pword { get; set; }
        
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


    //     c_user_id int primary key identity not null, name varchar(255) not null,age int check(age>0) not null,city varchar(255) not null
   //     ,father_name varchar(255) not null,username varchar(255) not null,pword varchar(255) not null,admin_id int  , admin_action_time datetime

        public void Add()
        {

            string a = "insert into users values('" + name + "'," + age + ",'" + city + "','" + father_name + "','" + username + "','" + pword + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<users> ShowAll()
        {
            string a = " select * from users";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<users> lst = new List<users>();

            while (sdr.Read())
            {
                users c = new users()
                {
                    c_user_id = (int)sdr["c_user_id"],
                    name = (string)sdr["name"],
                    age = (int)sdr["age"],
                    city = (string)sdr["city"],
                    father_name = (string)sdr["father_name"],
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

        public users Search()
        {
            string a = " select * from users where c_user_id = " + c_user_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<users> lst = new List<users>();

            users c = new users();

            while (sdr.Read())
            {
                c.c_user_id = (int)sdr["c_user_id"];
                c.name = (string)sdr["name"];
                c.age = (int)sdr["age"];
                c.city = (string)sdr["city"];
                c.father_name = (string)sdr["father_name"];
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

            string a = "update  users set name='" + name + "',age=" + age + ",city='" + city + "',father_name='" + father_name + "',username='" + username + "',pword='" + pword + "',admin_id=" + admin_id + ",admin_action_time= GETDATE()  where c_user_id = " + c_user_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  users where c_user_id = " + c_user_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}