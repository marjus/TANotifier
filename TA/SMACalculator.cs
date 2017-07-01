using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA
{
    public class SMACalculator
    {
        private List<int> periodCloseValues;

        public SMACalculator(List<int> values)
        {
            periodCloseValues = values;
           
        }

        public double CalculateSMA50()
        {

            if (periodCloseValues is null)
                return 0;

            if (periodCloseValues.Count < 50)
                return 0;

            return periodCloseValues.Average();
        }
    }
}
