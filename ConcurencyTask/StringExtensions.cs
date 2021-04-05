using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConcurencyTask
{
    public static class StringExtensions
    {
        public static string ToJsonString<T>(this string str, T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
    }
}
