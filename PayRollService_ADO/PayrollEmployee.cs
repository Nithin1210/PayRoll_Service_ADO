using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollService_ADO
{
    class PayrollEmployee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
        public string start_date { get; set; }
        public DateTime StartDate { get; set; }
        public char gender { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public long basic_pay { get; set; }
        public long deductions { get; set; }
        public long taxable_pay { get; set; }
        public long income_tax { get; set; }
        public long net_pay { get; set; }
    }
}
