using CreamyCreations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class CoversVM
    {
        public int Id { get; set; }
        public List<Cover> Covers { get; set; }
    }
}
