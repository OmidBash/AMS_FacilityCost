using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AMS.WebUI.Infrastructure
{
    public static class Utilities
    {
        public static string GetEnumDisplayName(Enum enumValue)
        {
            return enumValue.GetType()?
                .GetMember(enumValue.ToString())?[0]?
                .GetCustomAttribute<DisplayAttribute>()?
                .Name;
        }
    }

}
