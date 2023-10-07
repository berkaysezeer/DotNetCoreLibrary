using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.OCPGood2
{
    /*Delegate kullanıcı*/

    public class LowSalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 2;
        }
    }

    public class MediumSalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 4;
        }
    }

    public class HighSalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 6;
        }
    }

    public class SalaryCalculator
    {
        public decimal Calculate(decimal salary, Func<decimal, decimal> calculateDelegate)
        {
            return calculateDelegate(salary);
        }
    }
}
