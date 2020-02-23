using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class user_phones
    {
        public int c_user_id { get; set; }
        public string phone_no { get; set; }

        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


        //c_user_id int foreign key references users(c_user_id) not null
        //, phone_no varchar(255) CHECK (LEN(phone_no)>0 and LEN(phone_no)=11) not null unique, admin_id int  , admin_action_time datetime 

        public void Add()
        {

            string a = "insert into user_phones values(" + c_user_id + ",'" + phone_no + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<user_phones> ShowAll()
        {
            string a = " select * from user_phones";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<user_phones> lst = new List<user_phones>();

            while (sdr.Read())
            {
                user_phones c = new user_phones()
                {
                    c_user_id = (int)sdr["c_user_id"],
                    phone_no = (string)sdr["phone_no"],

                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public user_phones Search()
        {
            string a = " select * from user_phones where c_user_id = " + c_user_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<user_phones> lst = new List<user_phones>();

            user_phones c = new user_phones();

            while (sdr.Read())
            {
                c.c_user_id = (int)sdr["c_user_id"];
                c.phone_no = (string)sdr["phone_no"];

                c.admin_id = (int)sdr["admin_id"];
                c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  user_phones set c_user_id=" + c_user_id + ",phone_no='" + phone_no + "',admin_id=" + admin_id + ",admin_action_time = GETDATE()  where c_user_id = " + c_user_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  user_phones where c_user_id = " + c_user_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}