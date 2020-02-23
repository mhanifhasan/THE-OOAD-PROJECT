using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class staff_phones
    {
        public int staff_id { get; set; }
        public string phone_no { get; set; }
        
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


  //staff_id int foreign key references staff(staff_id) not null
//   , phone_no varchar(255) CHECK (LEN(phone_no)>0 and LEN(phone_no)=11) not null unique, admin_id int , admin_action_time datetime 

        public void Add()
        {

            string a = "insert into staff_phones values(" + staff_id + ",'" + phone_no + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<staff_phones> ShowAll()
        {
            string a = " select * from staff_phones";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<staff_phones> lst = new List<staff_phones>();

            while (sdr.Read())
            {
                staff_phones c = new staff_phones()
                {
                    staff_id = (int)sdr["staff_id"],
                    phone_no = (string)sdr["phone_no"],
                   
                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public staff_phones Search()
        {
            string a = " select * from staff_phones where staff_id = " + staff_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<staff_phones> lst = new List<staff_phones>();

            staff_phones c = new staff_phones();

            while (sdr.Read())
            {
               c.staff_id = (int)sdr["staff_id"];
               c.phone_no = (string)sdr["phone_no"];

               c.admin_id = (int)sdr["admin_id"];
               c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  staff_phones set staff_id=" + staff_id + ",phone_no='" + phone_no + "',admin_id=" + admin_id + ",admin_action_time = GETDATE()  where staff_id = " + staff_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  staff_phones where staff_id = " + staff_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}