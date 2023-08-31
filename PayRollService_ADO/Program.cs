using System;

namespace PayRollService_ADO

{
    class Program
    {
        static void Main()
        {
            //Payroll employee Stored Proceudre

            Payroll_Operation payroll = new Payroll_Operation();
            payroll.CreateTable();
            payroll.GetAllEmployeeDetails();
        }

    }
}   