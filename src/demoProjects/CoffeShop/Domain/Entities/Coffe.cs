using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Coffe:Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Coffe()
        {
        }
        public Coffe(int id , string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

    }
}
