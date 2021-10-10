using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DHWeb.Helpers
{


    public static class ViewMethod
    {
        public static List<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : Enum
        {

            var enum_values = Enum.GetValues(typeof(TEnum));

            List<SelectListItem> results = new List<SelectListItem>();

            foreach (TEnum value in enum_values)
            {
                MemberInfo member_info = value.GetType().GetMember(value.ToString())
                                            .FirstOrDefault();
                var display =  member_info.GetCustomAttribute<DisplayAttribute>();

                results.Add(new SelectListItem()
                {
                    Value = value.ToString(),
                    Text = display != null ? display.Name : value.ToString()
                });
            }


            return results;
        }


        public static string GetDisplayName<TEnum>(TEnum enumValue) where TEnum : Enum{


            MemberInfo member_info = enumValue.GetType().GetMember(enumValue.ToString())
                                            .FirstOrDefault();
                                            
            var display =  member_info.GetCustomAttribute<DisplayAttribute>();

            if(display != null){
                
                return display.Name;
            }else{
                return string.Empty;
            }
        }


          public static string GetDisplayName<TEnum>(string enumValue) where TEnum : Enum{
            

            MemberInfo member_info = typeof(TEnum).GetMember(enumValue.ToString())
                                            .FirstOrDefault();
                                            
            var display =  member_info.GetCustomAttribute<DisplayAttribute>();

            if(display != null){
                
                return display.Name;
            }else{
                return string.Empty;
            }
        }


    }
}