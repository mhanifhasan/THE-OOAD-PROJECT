using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class expenses
    {
        public int expense_id { get; set; }

        public string expence_discription { get; set; }
        public int cost { get; set; }
        public string expence_state { get; set; }
        

        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


        //(expense_id int primary key identity , expence_discription varchar(255) , cost int ,expence_state varchar(255) , admin_id int , admin_action_time datetime)

        public void Add()
        {

            string a = "insert into expenses values('" + expence_discription + "'," + cost + ",'" + expence_state + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<expenses> ShowAll()
        {
            string a = " select * from expenses";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<expenses> lst = new List<expenses>();

            while (sdr.Read())
            {
                expenses c = new expenses()
                {
                    expense_id = (int)sdr["expense_id"],
                    expence_discription = (string)sdr["expence_discription"],
                    cost = (int)sdr["cost"],
                    expence_state = (string)sdr["expence_state"],
                    

                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public expenses Search()
        {
            string a = " select * from expenses where expense_id = " + expense_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<expenses> lst = new List<expenses>();

            expenses c = new expenses();

            while (sdr.Read())
            {
                c.expense_id = (int)sdr["expense_id"];
                c.expence_discription = (string)sdr["expence_discription"];
                c.cost = (int)sdr["cost"];
                c.expence_state = (string)sdr["expence_state"];


                c.admin_id = (int)sdr["admin_id"];
                c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  expenses set expence_discription='" + expence_discription + "',cost=" + cost + ",expence_state='" + expence_state + "',admin_id=" + admin_id + ",admin_action_time= GETDATE()  where expense_id = " + expense_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  expenses where expense_id = " + expense_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}