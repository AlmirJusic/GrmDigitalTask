using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrmDigitalTask.EntityModels
{
    public class GrmTask
    {
        [Key]
        public int ID { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
