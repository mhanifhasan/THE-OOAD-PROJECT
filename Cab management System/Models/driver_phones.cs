using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class driver_phones
    {
        public int driver_id { get; set; }
        public string phone_no { get; set; }

        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


        //driver_id int foreign key references staff(driver_id) not null
        //   , phone_no varchar(255) CHECK (LEN(phone_no)>0 and LEN(phone_no)=11) not null unique, admin_id int , admin_action_time datetime 

        public void Add()
        {

            string a = "insert into driver_phones values(" + driver_id + ",'" + phone_no + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<driver_phones> ShowAll()
        {
            string a = " select * from driver_phones";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<driver_phones> lst = new List<driver_phones>();

            while (sdr.Read())
            {
                driver_phones c = new driver_phones()
                {
                    driver_id = (int)sdr["driver_id"],
                    phone_no = (string)sdr["phone_no"],

                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public driver_phones Search()
        {
            string a = " select * from driver_phones where driver_id = " + driver_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<driver_phones> lst = new List<driver_phones>();

            driver_phones c = new driver_phones();

            while (sdr.Read())
            {
                c.driver_id = (int)sdr["driver_id"];
                c.phone_no = (string)sdr["phone_no"];

                c.admin_id = (int)sdr["admin_id"];
                c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  driver_phones set driver_id=" + driver_id + ",phone_no='" + phone_no + "',admin_id=" + admin_id + ",admin_action_time = GETDATE()  where driver_id = " + driver_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  driver_phones where driver_id = " + driver_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}