using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;
using hms2.Models;


namespace hms2.Manager
{
    public class patientmanager
    {
        public int addpatient(AddpatientModel ad)
        {
            int adID;
            using (hms2Entities hm = new hms2Entities())
            {
                patient tblpatient = new patient();
                tblpatient.FirstName = ad.firstName;
                tblpatient.LastName = ad.lastName;
                tblpatient.Disease = ad.Disease;
                tblpatient.Cellnum = ad.cellnum;
                tblpatient.CNIC = ad.cnic;
                tblpatient.Gender = ad.gender;
                tblpatient.Nationality = ad.nationality;

                hm.patients.Add(tblpatient);

                hm.SaveChanges();

                adID = tblpatient.ID;

            }
            return adID;
        }

        public List<AddpatientModel> readstudents()
        {
            using (hms2Entities he = new hms2Entities())
            {
                var request = he.patients.ToList();
                List<AddpatientModel> List = request.Select(x => new AddpatientModel { pID = x.ID, firstName = x.FirstName, lastName = x.LastName, Disease = x.Disease, cellnum = x.Cellnum, cnic = x.CNIC, gender = x.Gender, nationality = x.Nationality }).ToList();
                return List;
            }
        }
        public AddpatientModel Getupdatepat(int pID)
        {
            using (hms2Entities hm = new Manager.hms2Entities())
            {
                var request = hm.patients.Where(x => x.ID == pID).FirstOrDefault();
                AddpatientModel patnt = null;
                if (request != null)
                {
                    patnt = new AddpatientModel()
                    {
                        pID = request.ID,
                        firstName = request.FirstName,
                        lastName = request.LastName,
                        Disease = request.Disease,
                        cnic = request.CNIC,
                        cellnum = request.Cellnum,
                        gender = request.Gender,
                        nationality = request.Nationality

                    };

                    return patnt;
                }
                else
                {
                    return patnt;
                }



            }
        }

        public bool updatepat(AddpatientModel std)
        {
            using (hms2Entities db = new hms2Entities())
            {
                var data = db.patients.Where(x => x.ID == std.pID).FirstOrDefault();
                if (data != null)
                {
                    data.FirstName = std.firstName;
                    data.LastName = std.lastName;
                    data.Disease = std.Disease;
                    data.CNIC = std.cnic;
                    data.Cellnum = std.cellnum;
                    data.Gender = std.gender;
                    data.Nationality = std.nationality;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteStd(int id)
        {
            using (hms2Entities db = new hms2Entities())
            {
                var data = db.patients.Where(x => x.ID == id).FirstOrDefault();
                if (data != null)
                {
                    db.Entry(data).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //static string conString = @"Data Source=DESKTOP-TKJ1DUH;Initial Catalog=hms2;Integrated Security=True";
        //     SqlConnection con = new SqlConnection(conString);
        //     public int addpatient(AddpatientModel patientt)
        //     {


        //         string query = "insert into	patient(FirstName,LastName,Disease,CNIC,Cellnum,Gender,Nationality) values('" + patientt.firstName + "','" + patientt.lastName + "','" + patientt.Disease +  "','" + patientt.cnic + "','" + patientt.cellnum + "','" + patientt.gender + "','" + patientt.nationality + "')";
        //         //string query = "INSERT INTO hms2.dbo.patient(FirstName) values('a')";
        //         con.Open();
        //         SqlCommand cmd = new SqlCommand(query, con);
        //         int a = cmd.ExecuteNonQuery();
        //         con.Close();

        //         return a;

        //     }

        //     public List<AddpatientModel> readStudents()
        //     {
        //         string query = "Select * from patient";
        //         con.Open();
        //         SqlDataAdapter adp = new SqlDataAdapter(query, con);

        //         DataTable dt = new DataTable();
        //         adp.Fill(dt);
        //         con.Close();

        //         List<AddpatientModel> patientData = new List<AddpatientModel>();
        //         foreach (DataRow item in dt.Rows)
        //         {
        //             AddpatientModel cst = new AddpatientModel()
        //             {
        //                 firstName = item["FirstName"].ToString(),
        //                 lastName = item["LastName"].ToString(),

        //                Disease = item["Disease"].ToString(),
        //                 cellnum = item["Cellnum"].ToString(),
        //                 cnic = item["CNIC"].ToString(),
        //                 gender = item["Gender"].ToString(),
        //                 nationality = item["Nationality"].ToString()




        //             };

        //             patientData.Add(cst);

        //         }

        //         return patientData;
    }
}




