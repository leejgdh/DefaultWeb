using System;
using System.ComponentModel.DataAnnotations;

namespace DHWeb.Models{

    [Flags]
    public enum EService{
        
        [Display(Name ="설정되지 않음")]
        NONE = 0,

        [Display(Name ="웹")]
        WEB = 1 << 1,
        
        [Display(Name ="안드로이드")]
        ANDROID = 1 << 2,

        [Display(Name ="IOS")]
        IOS = 1 << 3
    }
}