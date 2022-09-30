using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Models
{
    public class Air
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Biaya { get; set; }
        public string Token { get; set; }
    }
}
