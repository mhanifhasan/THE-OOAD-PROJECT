using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;
using hms2.Models;


namespace hms2.Manager
{
    public class doctormanager
    {
        public int adddoctor(Adddoctormodel dd)
        {
            int ddID;
            using (hms2Entities mm = new hms2Entities())
            {
                doctor tbldoctor = new doctor();
                tbldoctor.FirstName = dd.firstName;
                tbldoctor.LastName = dd.lastName;
                tbldoctor.qualification = dd.qualification;
                tbldoctor.Cellnum = dd.cellnum;
                tbldoctor.CNIC = dd.cnic;
                tbldoctor.Gender = dd.gender;
                tbldoctor.Nationality = dd.nationality;

                mm.doctors.Add(tbldoctor);

                mm.SaveChanges();

                ddID = tbldoctor.ID;
            }
            return ddID;
        }

        public List<Adddoctormodel> readstudents()
        {
            using (hms2Entities mm = new hms2Entities())
            {
                var request = mm.doctors.ToList();
                List<Adddoctormodel> List = request.Select(x => new Adddoctormodel { SID = x.ID, firstName = x.FirstName, lastName = x.LastName, qualification = x.qualification, cellnum = x.Cellnum, cnic = x.CNIC, gender = x.Gender, nationality = x.Nationality }).ToList();
                return List;

            }

            }

        public Adddoctormodel Getupdatedoc(int SID)
        {
            using (hms2Entities mm = new hms2Entities())
            {
                var request = mm.doctors.Where(x => x.ID == SID).FirstOrDefault();
                Adddoctormodel dcctr = null;
                if (request != null)
                {
                    dcctr = new Adddoctormodel()
                    {
                        SID = request.ID,
                        firstName = request.FirstName,
                        lastName = request.LastName,
                        qualification = request.qualification,
                        cellnum = request.Cellnum,
                        cnic = request.CNIC,
                        gender = request.Gender,
                        nationality = request.Nationality
                    };
                    return dcctr;
                }
                else
                {
                    return dcctr;
                }

            }
        }
        public bool updatedoc(Adddoctormodel std)
        {
            using (hms2Entities mm = new hms2Entities())
            {
                var data = mm.doctors.Where(x => x.ID == std.SID).FirstOrDefault();
                if (data != null)
                {
                    data.FirstName = std.firstName;
                    data.LastName = std.lastName;
                    data.qualification = std.qualification;
                    data.Cellnum = std.cellnum;
                    data.CNIC = std.cnic;
                    data.Gender = std.gender;
                    data.Nationality = std.nationality;
                    mm.Entry(data).State = EntityState.Modified;
                    mm.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool Deletedctr(int id)
        {
            using (hms2Entities mm = new hms2Entities())
            {
                var data = mm.doctors.Where(x => x.ID == id).FirstOrDefault();
                if (data != null)
                {
                    mm.Entry(data).State = EntityState.Deleted;
                    mm.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

                //static string conString = @"Data Source=DESKTOP-TKJ1DUH;Initial Catalog=hms2;Integrated Security=True";
                //SqlConnection con = new SqlConnection(conString);

        //public int adddoctor(Adddoctormodel doctorr)
        //{
        //    string query = "insert into	doctor(FirstName,LastName,qualification,,CNIC,Cellnum,Gender,Nationality) values('" + doctorr.firstName + "','" + doctorr.lastName + "','" + doctorr.qualification + "','" + doctorr.cnic + "','" + doctorr.cellnum + "','" + doctorr.gender + "','" + doctorr.nationality + "')";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    int a = cmd.ExecuteNonQuery();
        //    con.Close();

        //    return a;
        //}
        //public List<Adddoctormodel> readstudents()
        //{
        //    string query = "select * from doctor";
        //    con.Open();
        //    SqlDataAdapter adp = new SqlDataAdapter(query, con);

        //    DataTable ddt = new DataTable();
        //    adp.Fill(ddt);
        //    con.Close();


        //    List<Adddoctormodel> doctordata = new List<Adddoctormodel>();
        //    foreach (DataRow item in ddt.Rows)
        //    {
        //        Adddoctormodel adm = new Adddoctormodel()
        //        {
        //            firstName = item["FirstName"].ToString(),
        //            lastName = item["LastName"].ToString(),
        //            qualification = item["qualification"].ToString(),
        //            cellnum = item["Cellnum"].ToString(),
        //            cnic = item["CNIC"].ToString(),
        //            gender = item["Gender"].ToString(),
        //            nationality = item["Nationality"].ToString()




        //        };

        //        doctordata.Add(adm);

        //    }

        //    return doctordata;
    }
    }
            


        