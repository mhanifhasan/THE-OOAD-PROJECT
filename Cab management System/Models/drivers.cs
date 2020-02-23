using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cab_management_System.Models
{
    public class drivers
    {
        public int driver_id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string cnic { get; set; }
        public string car_name { get; set; }
        public string car_model { get; set; }
        public string car_brand { get; set; }
        public string car_number_plate { get; set; }
        public string username { get; set; }
        public string pword { get; set; }
        public string online_stat { get; set; }
        public int admin_id { get; set; }
        public DateTime admin_action_time { get; set; }


//driver_id int primary key identity  not null, name varchar(255) not null,age int check(age>0) not null,cnic varchar(255) not null ,car_name varchar(255) not null,
//car_model varchar(255) not null,car_brand varchar(255) not null,car_number_plate varchar(255) unique  not null
//,username varchar(255) not null,pword varchar(255) not null,online_stat varchar(255) not null,admin_id int ,admin_action_time datetime)

        public void Add()
        {

            string a = "insert into drivers values('" + name + "'," + age + ",'" + cnic + "','" + car_name + "','" + car_model + "','" + car_brand + "','" + car_number_plate + "','" + username + "','" + pword + "','" + online_stat + "'," + admin_id + ",GETDATE())";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public List<drivers> ShowAll()
        {
            string a = " select * from drivers";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<drivers> lst = new List<drivers>();

            while (sdr.Read())
            {
                drivers c = new drivers()
                {
                    driver_id = (int)sdr["driver_id"],
                    name = (string)sdr["name"],
                    age = (int)sdr["age"],
                    cnic = (string)sdr["cnic"],
                    car_name = (string)sdr["car_name"],
                    car_model = (string)sdr["car_model"],
                    car_brand = (string)sdr["car_brand"],
                    car_number_plate = (string)sdr["car_number_plate"],
                    username = (string)sdr["username"],
                    pword = (string)sdr["pword"],
                    online_stat = (string)sdr["online_stat"],

                    admin_id = (int)sdr["admin_id"],
                    admin_action_time = (DateTime)sdr["admin_action_time"]
                };
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }

        public drivers Search()
        {
            string a = " select * from drivers where driver_id = " + driver_id + "";

            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<drivers> lst = new List<drivers>();

            drivers c = new drivers();

            while (sdr.Read())
            {
                 c.driver_id = (int)sdr["driver_id"];
                 c.name = (string)sdr["name"];
                 c.age = (int)sdr["age"];
                 c.cnic = (string)sdr["cnic"];
                 c.car_name = (string)sdr["car_name"];
                 c.car_model = (string)sdr["car_model"];
                 c.car_brand = (string)sdr["car_brand"];
                 c.car_number_plate = (string)sdr["car_number_plate"];
                 c.username = (string)sdr["username"];
                 c.pword = (string)sdr["pword"];
                 c.online_stat = (string)sdr["online_stat"];

                 c.admin_id = (int)sdr["admin_id"];
                 c.admin_action_time = (DateTime)sdr["admin_action_time"];


            }
            sdr.Close();
            return c;
        }

        public void Update()
        {

            string a = "update  drivers set name='" + name + "',age=" + age + ",cnic='" + cnic + "',car_name='" + car_name + "',car_model='" + car_model + "',car_brand='" + car_brand + "',car_number_plate='" + car_number_plate + "',username='" + username + "',pword='" + pword + "',online_stat='" + online_stat + "',admin_id=" + admin_id + ",admin_action_time= GETDATE()  where driver_id = " + driver_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }

        public void Delete()
        {

            string a = "Delete  drivers where driver_id = " + driver_id + "";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
    }
}