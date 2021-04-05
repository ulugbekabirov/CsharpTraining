using System;
using System.Text.Json;

namespace ConcurencyTask
{
    public static class StringExtensions
    {
        public static string ToJson<T>(this string str, T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
        
        public static int ToInt32(this string str)
        {
            var result = new Int32();
            if(Int32.TryParse(str, out result))
            {
                return result;
            }

            return -1;
        }
    }
}
