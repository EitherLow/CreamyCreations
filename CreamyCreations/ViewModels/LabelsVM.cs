using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Models;

namespace CreamyCreations.ViewModels
{
    public class LabelsVM
    {
        public int Id { get; set; }
        public List<Label> Labels { get; set; }
    }
}
