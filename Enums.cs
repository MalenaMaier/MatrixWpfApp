using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Matrix.Enums
{

    public enum OperationEnum
    {
        [Description("+")]
        addition,
        [Description("-")]
        substraction,
        [Description("*")]
        multiplication,
        [Description("/")]
        division
    }

    public class EnumValueConverter : IValueConverter
    {
        public string[] OperationEnumFrienlyNames => GetStrings<OperationEnum>();
        public static string[] GetStrings<T>() where T : Enum
        {
            List<string> list = new List<string>();
            foreach (T format in Enum.GetValues(typeof(T)))
            {
                list.Add(GetFriendlyName(format));
            }

            return list.ToArray();
        }

        private static string GetFriendlyName<T>(T format) where T : Enum
        {
            return format.GetType().GetMember(format.ToString())[0].GetCustomAttribute<DescriptionAttribute>().Description;

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is OperationEnum format)
            {
                return GetFriendlyName(format);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                switch (targetType)
                {
                    case Type opType when opType == typeof(OperationEnum): 
                        return GetValueFromDescription<OperationEnum>(s);                        
                }
            }
            return null;
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
    }


    }
