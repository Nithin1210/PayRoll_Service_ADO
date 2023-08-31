using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollService_ADO
{
    class Payroll_Operation
    {
        private SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = Payroll_service; integrated security = true");
        private void Connection()
        {
            string connectionstr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = payroll_service; integrated security = true";
            con = new SqlConnection(connectionstr);
        }
        public void CreateTable()
        {
            try
            {
                Connection();
                string query = "create Table payroll_employee(Id int primary key identity(1,1),Name varchar(max) not null,Salary varchar(max) not null,Start_date DATETIME not null,Gender varchar(max) not null,Phone varchar(max) not null,Address varchar(max) not null,Department varchar(max) not null,Basic_pay varchar(max) not null,Deductions varchar(max) not null,Taxable_pay varchar(max) not null,Income_tax varchar(max) not null,Net_pay varchar(max) not null,)";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("!!DataBase Created Sucessfully !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!! database creation Failed !! ");
            }
            finally
            {
                con.Close();
            }
        }
        public void AddEmployeeDetails(PayrollEmployee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("AddEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", employee.name);
                com.Parameters.AddWithValue("@salary", employee.salary);
                com.Parameters.AddWithValue("@start_date", employee.start_date);
                com.Parameters.AddWithValue("@Gender", employee.gender);
                com.Parameters.AddWithValue("@phone", employee.phone);
                com.Parameters.AddWithValue("@Address", employee.address);
                com.Parameters.AddWithValue("@department", employee.department);
                com.Parameters.AddWithValue("@basic_pay", employee.basic_pay);
                com.Parameters.AddWithValue("@deductions", employee.deductions);
                com.Parameters.AddWithValue("@taxable_pay", employee.taxable_pay);
                com.Parameters.AddWithValue("@income_tax", employee.income_tax);
                com.Parameters.AddWithValue("@net_pay", employee.net_pay);
                con.Open();
                com.ExecuteNonQuery();
                Console.WriteLine("Database Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deletemployeeeDetails(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("Database Deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateEmployee(PayrollEmployee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("UpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", employee.id);
                com.Parameters.AddWithValue("@name", employee.name);
                com.Parameters.AddWithValue("@salary", employee.salary);
                com.Parameters.AddWithValue("@start_date", employee.start_date);
                com.Parameters.AddWithValue("@Gender", employee.gender);
                com.Parameters.AddWithValue("@phone", employee.phone);
                com.Parameters.AddWithValue("@Address", employee.address);
                com.Parameters.AddWithValue("@department", employee.department);
                com.Parameters.AddWithValue("@basic_pay", employee.basic_pay);
                com.Parameters.AddWithValue("@deductions", employee.deductions);
                com.Parameters.AddWithValue("@taxable_pay", employee.taxable_pay);
                com.Parameters.AddWithValue("@income_tax", employee.income_tax);
                com.Parameters.AddWithValue("@net_pay", employee.net_pay);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllEmployeeDetails()
        {
            List<PayrollEmployee> emplist = new List<PayrollEmployee>();
            SqlCommand com = new SqlCommand("GetEmployeeDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(
                   new PayrollEmployee
                   {
                       id = Convert.ToInt32(dr["id"]),
                       name = Convert.ToString(dr["name"]),
                       salary = Convert.ToString(dr["salary"]),
                       StartDate = Convert.ToDateTime(dr["start_date"]),
                       gender = Convert.ToChar(dr["Gender"]),
                       phone = Convert.ToString(dr["phonenumber"]),
                       address = Convert.ToString(dr["Address"]),
                       department = Convert.ToString(dr["department"]),
                       basic_pay = Convert.ToInt64(dr["basic_pay"]),
                       deductions = Convert.ToInt64(dr["deductions"]),
                       taxable_pay = Convert.ToInt64(dr["taxable_pay"]),
                       income_tax = Convert.ToInt64(dr["income_tax"]),
                       net_pay = Convert.ToInt64(dr["net_pay"]),
                   }
                   );
            }
            foreach (var data in emplist)
            {
                Console.WriteLine(data.name + " ," + data.salary + " ," + data.phone + " ," + data.address + " ," + data.department + " ," + data.StartDate.ToLongDateString());
            }
        }
        public void RetreivedatainaParticularPeriod(string Date)
        {
            try
            {
                List<PayrollEmployee> emplist = new List<PayrollEmployee>();
                SqlCommand com = new SqlCommand("ParticularPeriod", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@start_date", Date);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    emplist.Add(
                       new PayrollEmployee
                       {
                           id = Convert.ToInt32(dr["id"]),
                           name = Convert.ToString(dr["name"]),
                           salary = Convert.ToString(dr["salary"]),
                           StartDate = Convert.ToDateTime(dr["start_date"]),
                           gender = Convert.ToChar(dr["Gender"]),
                           phone = Convert.ToString(dr["phone"]),
                           address = Convert.ToString(dr["Address"]),
                           department = Convert.ToString(dr["department"]),
                           basic_pay = Convert.ToInt64(dr["basic_pay"]),
                           deductions = Convert.ToInt64(dr["deductions"]),
                           taxable_pay = Convert.ToInt64(dr["taxable_pay"]),
                           income_tax = Convert.ToInt64(dr["income_tax"]),
                           net_pay = Convert.ToInt64(dr["net_pay"]),
                       }
                       );
                }
                foreach (var data in emplist)
                {
                    Console.WriteLine(data.name + " " + data.salary + " " + data.phone + " " + data.address + " " + data.department + " " + data.StartDate.ToLongDateString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void SumAvgMinMax()
        {
            try
            {
                SqlCommand com = new SqlCommand("SumAvgMinMax", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine("Sum =" + Convert.ToString(dr["sum"]));
                    Console.WriteLine("Avg =" + Convert.ToString(dr["avg"]));
                    Console.WriteLine("Min =" + Convert.ToString(dr["min"]));
                    Console.WriteLine("Max =" + Convert.ToString(dr["max"]));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
