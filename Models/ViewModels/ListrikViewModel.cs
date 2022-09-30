using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Models.ViewModels
{
    public class ListrikViewModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Biaya { get; set; }
        public string Token { get; set; }
    }
}
