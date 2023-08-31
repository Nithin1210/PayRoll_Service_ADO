using System;

namespace PayRollService_ADO

{
    class Program
    {
        static void Main()
        {
            //Payroll employee Stored Proceudre
            PayrollEmployee employee = new PayrollEmployee()
            {
                id = 6,
                name = "Teressa",
                salary = "2000",
                start_date = "2018/01/01",
                gender = 'F',
                phone = "9898789898",
                address = "chennai",
                department = "Marketing",
                basic_pay = 300,
                deductions = 300,
                taxable_pay = 30,
                income_tax = 300,
                net_pay = 300,
            };


            Payroll_Operation payroll = new Payroll_Operation();
            payroll.CreateTable();
            payroll.UpdateEmployee(employee);
            payroll.GetAllEmployeeDetails();

            
        }

    }
}