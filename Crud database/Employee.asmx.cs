using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;


namespace Crud_database
{
    /// <summary>
    /// Summary description for Employee1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Employee1 : System.Web.Services.WebService
    {

        [WebMethod]
       
        public List<string> GetGenderList()
        {
            List<string> genderList = new List<string>();
            string constr = ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Gender FROM GenderTable";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            genderList.Add(sdr["Gender"].ToString());
                        }
                    }
                    con.Close();
                }
            }
            return genderList;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public bool SaveEmployee(string Empid, string Firstname, string Middlename, string Lastname, string Gender, string DateOfBirth, int Age)
        {
            bool result = false;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO EmpDetails (Empid, Firstname, Middlename, Lastname, Gender, DateOfBirth, Age) VALUES (@Empid, @Firstname, @Middlename, @Lastname, @Gender, @DateOfBirth, @Age)", connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Empid", Empid);
                        cmd.Parameters.AddWithValue("@Firstname", Firstname);
                        cmd.Parameters.AddWithValue("@Middlename", Middlename);
                        cmd.Parameters.AddWithValue("@Lastname", Lastname);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        cmd.Parameters.AddWithValue("@Age", Age);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                //log the exception
                result = false;
            }
            return result;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetEmployee()
        {
            List<Employee> emplist = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from EmpDetails ORDER BY ModifiedDate DESC", con);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.Empid = rdr["Empid"].ToString();
                    emp.Firstname = rdr["Firstname"].ToString();
                    emp.Middlename = rdr["Middlename"].ToString();
                    emp.Lastname = rdr["Lastname"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.DateOfBirth = rdr["DateOfBirth"].ToString();
                    emp.Age = Convert.ToInt32(rdr["Age"]);

                    emplist.Add(emp);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(emplist));
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string DeleteData(string Empid)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM EmpDetails WHERE Empid = @Empid", connection))
                    {
                        command.Parameters.AddWithValue("@Empid", Empid);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "{\"status\":\"success\",\"message\":\"Record Deleted Successfully\"}";
                        }
                        else
                        {
                            return "{\"status\":\"failure\",\"message\":\"No Record found with the specified ID\"}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "{\"status\":\"error\",\"message\":\"" + ex.Message + "\"}";
            }
        }



        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public bool UpdateEmployee(string Empid, string Firstname, string Middlename, string Lastname, string Gender, string DateOfBirth, int Age)
        {
            bool result = false;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["CRUD"].ConnectionString;
                using (SqlConnection con1 = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE EmpDetails SET Empid = @Empid, Firstname = @Firstname, Middlename = @Middlename, Lastname = @Lastname, Gender = @Gender, DateOfBirth = @DateOfBirth, Age = @Age WHERE Empid = @Empid", con1))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Empid", Empid);
                        cmd.Parameters.AddWithValue("@Firstname", Firstname);
                        cmd.Parameters.AddWithValue("@Middlename", Middlename);
                        cmd.Parameters.AddWithValue("@Lastname", Lastname);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        cmd.Parameters.AddWithValue("@Age", Age);
                        con1.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                //log the exception
                result = false;
            }
            return result;
        }
    }
}
