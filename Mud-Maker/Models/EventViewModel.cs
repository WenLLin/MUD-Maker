using Mud_Maker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mud_Maker.Models
{
    public class EventViewModel
    {
        public Mud MUD { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
