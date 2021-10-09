using Finlex.Quiz1.Models;
using System;

namespace Finlex.Quiz1
{
    public class NestedArrayService
    {
        public NestedArray GetNumberAndSum(object[] nestedArray)
        {
            if (nestedArray == null)
            {
                return new NestedArray();
            }

            var length = 0;
            var sum = 0;

            foreach (var item in nestedArray)
            {
                if (item is int @int)
                {
                    length++;
                    sum += @int;
                }
                else if (item is object[])
                {
                    var array = GetNumberAndSum((object[])item);
                    length += array.Length;
                    sum += array.Sum;
                    continue;
                } 
                else
                {
                    throw new Exception("The array can not contains " + item.GetType().ToString());
                }
            }

            return new NestedArray { Length = length, Sum = sum };
        }
    }
}
