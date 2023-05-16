using DeliciousPieShop.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliciousPieShop.Pages.App
{
    public partial class PieCard 
    {
        [Parameter]
        public Pie Pie { get; set; }    
    }
}
