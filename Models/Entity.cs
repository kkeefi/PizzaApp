using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Entity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
