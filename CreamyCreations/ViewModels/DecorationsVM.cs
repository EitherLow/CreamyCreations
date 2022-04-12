using CreamyCreations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class DecorationsVM
    {
        public int Id { get; set; }
        public List<Decoration> Decorations { get; set; }
    }
}
