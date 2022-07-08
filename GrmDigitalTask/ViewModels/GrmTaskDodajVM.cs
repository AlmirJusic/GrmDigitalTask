using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrmDigitalTask.ViewModels
{
    public class GrmTaskDodajVM
    {
        
        public int ID1 { get; set; }
        public int ID2 { get; set; }
        public List<SelectListItem> GrmTaskList1 { get; set; }
        public List<SelectListItem> GrmTaskList2 { get; set; }
        
        [Required(ErrorMessage = "Unesite broj.")]
        public int Prvi { get; set; }
        
        [Required]
        public int Drugi { get; set; }
        
    }
}
