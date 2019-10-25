using Mud_Maker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mud_Maker.Models
{
    public class CreateEventViewModel
    {
        public int MUD { get; set; }
        public Event Event { get; set; }
        public IEnumerable<Fight> Fights { get; set; }
        public IEnumerable<Health> Healths { get; set; }
        public IEnumerable<Item> items { get; set; }
    }
}
