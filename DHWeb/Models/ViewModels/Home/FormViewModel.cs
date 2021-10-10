using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DHWeb.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DHWeb.Models.ViewModels.Home
{

    public class FormViewModel
    {
        public FormViewModel()
        {
            UserTypes = ViewMethod.GetEnumSelectList<EUserType>();
            UserTypes = ViewMethod.GetEnumSelectList<EUserType>();
        }

        [Display(Name = "이름", Description = "홍길동")]
        public string Name { get; set; }

        [Display(Name = "사용자 유형")]
        public EUserType UserType { get; set; }

        public List<SelectListItem> UserTypes { get; set; }

        public List<SelectListItem> UserTypeCheckBoxies{get; set;}

        public bool IsAllow { get; set; }

    }

}