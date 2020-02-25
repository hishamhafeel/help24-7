using AutoMapper;
using Help247.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Help247.Common.Utility
{
    public static class Extension
    {

        //public static List<EnumMember> GetList<T>() where T : IConvertible
        //{
        //    var type = typeof(T);

        //    if (!type.GetTypeInfo().IsEnum)
        //    {
        //        throw new ArgumentException("T must be of type enumeration.");
        //    }

        //    return Enum.GetValues(typeof(T))
        //        .Cast<T>()
        //        .Select(e => new EnumMember()
        //        {
        //            Value = e.ToString(),
        //            Key = ((IConvertible)e).ToInt32(null),
        //            Description = e.GetDescription()
        //        }).ToList();
        //}

        public static string GetDescription(this Enum value)
        {

            var x = value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                    ?? value.ToString();
            return x;
        }

            //public static string GetDescription(this Enum value)
            //{
            //    return
            //        value
            //            .GetType()
            //            .GetMember(value.ToString())
            //            .FirstOrDefault()
            //            ?.GetCustomAttribute<DescriptionAttribute>()
            //            ?.Description;
            //}


            //public static string GetDescription<T>(this T source)
            //{
            //    FieldInfo fi = source.GetType().GetField(source.ToString());

            //    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            //        typeof(DescriptionAttribute), false);

            //    if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            //    else return source.ToString();
            //}

            //public static string GetDescription(this object value)
            //{
            //    // get attributes  
            //    var field = value.GetType().GetField(value.ToString());
            //    var attributes = field.GetCustomAttributes(false);

            //    // Description is in a hidden Attribute class called DisplayAttribute
            //    // Not to be confused with DisplayNameAttribute
            //    dynamic displayAttribute = null;

            //    if (attributes.Any())
            //    {
            //        displayAttribute = attributes.ElementAt(0);
            //    }

            //    // return description
            //    return displayAttribute?.Description ?? "Description Not Found";
            //}

            public static List<KeyValuePair<string, int>> GetEnumList<T>()
        {
            var list = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
            }
            return list;
        }

    }
}
