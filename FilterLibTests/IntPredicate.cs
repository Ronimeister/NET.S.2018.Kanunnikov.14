using System;

namespace FilterLibTests
{
    public class IntPredicate : IPredicate
    {
        int _neededFilter;

        public IntPredicate(int filterValue)
        {
            _neededFilter = filterValue;
        }

        public bool IsMatch(int value)
        {
            if (value < 0 && value != Int32.MinValue)
            {
                value *= -1;
            }
            else if (value == Int32.MinValue)
            {
                return true;
            }

            while (value != 0)
            {
                if (value % 10 == _neededFilter)
                {
                    return true;
                }

                value /= 10;
            }

            return false;
        }
        
    }
}
