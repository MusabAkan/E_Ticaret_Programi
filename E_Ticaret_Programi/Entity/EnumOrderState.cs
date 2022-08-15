using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Ticaret_Programi.Entity
{

    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekliyor")] Waitting,
        [Display(Name = "Tamamlandı")] Success
    }
}