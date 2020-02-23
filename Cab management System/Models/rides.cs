using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class rides
    {
        public int ride_id { get; set; }
        
        public int driver_id { get; set; }
        public int c_user_id { get; set; }
        public string starting_location { get; set; }
        public string ending_location { get; set; }
        public int price { get; set; }
        public DateTime time_of_ride { get; set; }
        
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


//ride_id int primary key identity not null ,driver_id int foreign key references drivers(driver_id) not null ,
//c_user_id int foreign key references users(c_user_id) not null, starting_location varchar(255) not null ,ending_location varchar(255) not null,price int check(price>=0) not null,
//time_of_ride datetime  not null, admin_id int , admin_action_time datetime)

        public void Add()
        {

            string a = "insert into rides values(" + driver_id + "," + c_user_id + ",'" + starting_location + "','" + ending_location + "'," + price + ",'" + time_of_ride + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<rides> ShowAll()
        {
            string a = " select * from rides";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<rides> lst = new List<rides>();

            while (sdr.Read())
            {
                rides c = new rides()
                {
                    ride_id = (int)sdr["ride_id"],
                    driver_id = (int)sdr["driver_id"],
                    c_user_id = (int)sdr["c_user_id"],
                    starting_location = (string)sdr["starting_location"],
                    ending_location = (string)sdr["ending_location"],
                    price = (int)sdr["price"],
                    time_of_ride = (DateTime)sdr["time_of_ride"],
                    
                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public rides Search()
        {
            string a = " select * from rides where ride_id = " + ride_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<rides> lst = new List<rides>();

            rides c = new rides();

            while (sdr.Read())
            {
                c.ride_id = (int)sdr["ride_id"];
                c.driver_id = (int)sdr["driver_id"];
                c.c_user_id = (int)sdr["c_user_id"];
                c.starting_location = (string)sdr["starting_location"];
                c.ending_location = (string)sdr["ending_location"];
                c.price = (int)sdr["price"];
                c.time_of_ride = (DateTime)sdr["time_of_ride"];

                c.admin_id = (int)sdr["admin_id"];
                c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  rides set driver_id= " + driver_id + ",c_user_id= " + c_user_id + ",starting_location='" + starting_location + "',ending_location= '" + ending_location + "',price=" + price + ",time_of_ride= '" + time_of_ride + "',admin_id=" + admin_id + ",admin_action_time= GETDATE()  where ride_id = " + ride_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  rides where ride_id = " + ride_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}