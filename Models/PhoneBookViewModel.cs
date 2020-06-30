using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ABSA_CIB_Digital_Tech___Assessment.Models
{
    public class PhoneBookViewModel
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public int PhoneNumber { get; set; }
    }
    public class PhonebookDetails
    {
        public List<PhoneBook> Search(List<string>info)
        {

            StringBuilder buildSql = new StringBuilder();
            buildSql.Append("SELECT * FROM PhoneBook WHERE ");
            foreach(string value in info)
            {
                buildSql.AppendFormat("Name = '{0}'", value); 
            }
            string datasql = buildSql.ToString();
            return QueryList(datasql);
        }

        protected List<PhoneBook> QueryList(string name)
        {
            List<PhoneBook> lst = new List<PhoneBook>();
            SqlCommand cmd = GenerateSqlcommand(name);
            using (cmd.Connection)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        lst.Add(ReadValue(reader));
                    }
                }
            }
            return lst;
        }

        private PhoneBook ReadValue(SqlDataReader reader)
        {
            PhoneBook dt = new PhoneBook();
            dt.Name = (String)reader["Name"];
            dt.PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]);
            return dt;
        }

        private SqlCommand GenerateSqlcommand(string cmdTest)
        { 
            string constring = ConfigurationManager.ConnectionStrings["ABSAEntitie"].ToString();
            SqlConnection con = new  SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(cmdTest,con);
            cmd.Connection.Open();
            return cmd;
        }
    }

}