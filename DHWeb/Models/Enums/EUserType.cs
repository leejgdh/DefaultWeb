using System;
using System.ComponentModel.DataAnnotations;

namespace DHWeb.Models
{
    [Flags]
    public enum EUserType
    {
        [Display(Name = "설정되지 않음")]
        NONE = 0,

        [Display(Name = "관리자")]
        ADMIN = 1 << 1,

        [Display(Name = "사용자")]
        USER = 1 << 2
    }
}