using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tea:Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Tea()
        {
        }

        public Tea(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
