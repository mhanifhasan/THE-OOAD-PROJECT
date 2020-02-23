using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class employ_salaries
    {
        public int employ_id { get; set; }

        public int amount { get; set; }
        public DateTime date_of_paying { get; set; }
        public string month_pf_salary { get; set; }


        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


        //employ_id int foreign key references staff(staff_id)  , amount int ,date_of_paying datetime,month_pf_salary varchar(255) , admin_id int, admin_action_time datetime

        public void Add()
        {

            string a = "insert into employ_salaries values("+employ_id+"," + amount + ",'" + date_of_paying + "','" + month_pf_salary + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<employ_salaries> ShowAll()
        {
            string a = " select * from employ_salaries";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<employ_salaries> lst = new List<employ_salaries>();

            while (sdr.Read())
            {
                employ_salaries c = new employ_salaries()
                {
                    employ_id = (int)sdr["employ_id"],
                    amount = (int)sdr["amount"],
                    date_of_paying = (DateTime)sdr["date_of_paying"],
                    month_pf_salary = (string)sdr["month_pf_salary"],


                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public employ_salaries Search()
        {
            string a = " select * from employ_salaries where employ_id = " + employ_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<employ_salaries> lst = new List<employ_salaries>();

            employ_salaries c = new employ_salaries();

            while (sdr.Read())
            {
                 c.employ_id = (int)sdr["employ_id"];
                 c.amount = (int)sdr["amount"];
                 c.date_of_paying = (DateTime)sdr["date_of_paying"];
                 c.month_pf_salary = (string)sdr["month_pf_salary"];


                 c.admin_id = (int)sdr["admin_id"];
                 c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  employ_salaries set amount=" + amount + ",date_of_paying='" + date_of_paying + "',month_pf_salary='" + month_pf_salary + "',admin_id=" + admin_id + ",admin_action_time= GETDATE()  where employ_id = " + employ_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  employ_salaries where employ_id = " + employ_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}