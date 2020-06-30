using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using ABSA_CIB_Digital_Tech___Assessment.Models;

namespace ABSA_CIB_Digital_Tech___Assessment.Controllers.Api
{
    public class ApiPhoneBookController : ApiController
    {

        private ABSAEntities db = new ABSAEntities();
        // LIST OBJECT WILL HOLD AND RETURN A LIST OF PHONEBOOKS.
        List<PhoneBookViewModel> phonebook = new List<PhoneBookViewModel>();

        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ABSAEntitie"].ToString();
            con = new SqlConnection(constring);
        }
        // RETURN A LIST OF PHONEBOOKS MATCHING WITH THE REQUESTED ALPHANUMERIC VALUE(S).
        public IEnumerable<PhoneBookViewModel> Get(string sLookUpString)
        {
            //GetTheBooks(sLookUpString);
            GetAllPhoneBook(sLookUpString);
            return phonebook;
        }

        //// GET: Showroom  
        [System.Web.Http.HttpGet]
        public void GetAllPhonebook()
        {
            ABSAEntities Entities = new ABSAEntities();
            List<PhoneBook> phoneBooks = Entities.PhoneBooks.ToList();
        }



        public ApiPhoneBookController( )
        {
        }

        public void GetAllPhoneBook(string sFind)
        {

        }


        // POST: api/ApiPhoneBook

        //Get action methods of the previous section
        public IHttpActionResult PostNewPhonebook(PhoneBook PhoneNmb)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            int phoneNumber = Convert.ToInt32(PhoneNmb.PhoneNumber);
            connection();
            SqlCommand cmd = new SqlCommand("ProcPhonebook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", PhoneNmb.Name.ToString());
            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }   
            return Ok();
        }

        // PUT: api/ApiPhoneBook/5
        public IHttpActionResult Put(PhoneBookViewModel phonebook)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            using (var ctx = new ABSAEntities())
            {
                var existingphonenumber = ctx.PhoneBooks.Where(s => s.Name == phonebook.Name).FirstOrDefault<PhoneBook>();

                if (existingphonenumber == null)
                {
                    existingphonenumber.Name = phonebook.Name;
                    existingphonenumber.PhoneNumber = phonebook.PhoneNumber;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        // DELETE: api/ApiPhoneBook/5
        public IHttpActionResult Delete(string name)
        {
            if (name == "")
                return BadRequest("Not a valid Name");

            using (var ctx = new ABSAEntities())
            {
                var phonebook = ctx.PhoneBooks
                    .Where(s => s.Name == name)
                    .FirstOrDefault();
                ctx.Entry(phonebook).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}