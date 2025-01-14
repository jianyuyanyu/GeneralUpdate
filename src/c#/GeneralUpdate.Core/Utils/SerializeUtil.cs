﻿using Newtonsoft.Json;
using System;
using System.Text;

namespace GeneralUpdate.Core.Utils
{
    /// <summary>
    /// Arbitrary object serialization.
    /// </summary>
    public class SerializeUtil
    {
        /// <summary>
        /// Convert object to base64 string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            if (obj == null) return string.Empty;
            var json = JsonConvert.SerializeObject(obj);
            var bytes = Encoding.Default.GetBytes(json);
            var base64str = Convert.ToBase64String(bytes);
            return base64str;
        }

        /// <summary>
        /// Convert base64 object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string str)
        {
            var obj = default(T);
            if (string.IsNullOrEmpty(str)) return obj;
            byte[] bytes = Convert.FromBase64String(str);
            var json = Encoding.Default.GetString(bytes);
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}