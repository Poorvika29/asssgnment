using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoctorEntity;

namespace AssignmentWebApi.Controllers
{
    public class Doctor1Controller : ApiController
    {
        string constring = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public IEnumerable<DoctorModel> Get()
        {
            List<DoctorModel> Docs = new List<DoctorModel>();
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("spgetalldoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DoctorModel doctor = new DoctorModel();
                    doctor.Id = Convert.ToInt32(rdr["Id"]);
                    doctor.DocName = rdr["DocName"].ToString();
                    doctor.Fee = Convert.ToInt32(rdr["Fee"]);
                    doctor.Location = rdr["Location"].ToString();
                    doctor.WorkEx = Convert.ToInt32(rdr["WorkEx"]);
                    doctor.Category = rdr["Category"].ToString();

                    Docs.Add(doctor);
                }
            }
           // Docs.ToList();
            return Docs;
        }


        // GET: api/Doctor1
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Doctor1/5
        public string Get(int id)
        {
            return "value";
        }



        public void Post([FromBody] DoctorModel doctor)
        {
                
            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("spadddoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParaName = new SqlParameter();
                ParaName.ParameterName = "@DocName";
                ParaName.Value = doctor.DocName;
                cmd.Parameters.Add(ParaName);

                SqlParameter ParaCatg = new SqlParameter();
                ParaCatg.ParameterName = "@Category";
                ParaCatg.Value = doctor.Category;
                cmd.Parameters.Add(ParaCatg);

                SqlParameter ParaFee = new SqlParameter();
                ParaFee.ParameterName = "@Fee";
                ParaFee.Value = doctor.Fee;
                cmd.Parameters.Add(ParaFee);

                SqlParameter ParaEx = new SqlParameter();
                ParaEx.ParameterName = "@WorkEx";
                ParaEx.Value = doctor.WorkEx;
                cmd.Parameters.Add(ParaEx);

                SqlParameter ParaLoc = new SqlParameter();
                ParaLoc.ParameterName = "@Location";
                ParaLoc.Value = doctor.Location;
                cmd.Parameters.Add(ParaLoc);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }


        //// POST: api/Doctor1
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Doctor1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Doctor1/5
        public void Delete(int id)
        {
        }
    }
}
