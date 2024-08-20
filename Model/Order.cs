using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session3.Model
{
    internal class Order
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
