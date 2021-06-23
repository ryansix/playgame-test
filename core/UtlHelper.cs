using System;
using System.Collections.Generic;
using System.Linq;
namespace playgameNetcore
{
    public static class UtlHelper
    {
        public static int[] ConvertToIntArr(string input)
        {
            var arrStr = input.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var arrInt = arrStr.Select(u => Int32.Parse(u) ).ToArray();
            arrInt[0] = arrInt[0] - 1;
            return arrInt;
        }
        public static int[] EatConvertToIntArr(string input)
        {
            try
            {
              return  UtlHelper.ConvertToIntArr(input);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
