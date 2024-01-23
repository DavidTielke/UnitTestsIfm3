using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class RangeChecker
    {
        public bool IsInRange(int min, int max, int x)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException(nameof(min), "min can't be greater than max");
            }

            return min <= x && x <= max;
        }
    }
}
