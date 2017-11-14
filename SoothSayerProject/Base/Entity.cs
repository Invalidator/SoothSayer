using System;
using System.Collections.Generic;
using System.Linq;

namespace SoothSayer.Base
{
    public abstract class Entity
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract string EntityType { get; }

        public virtual IEnumerable<Entity> ChildEntities => Enumerable.Empty<Entity>();
        public virtual IEnumerable<ITemporal<Entity>> ChildTemporalEntities => Enumerable.Empty<ITemporal<Entity>>();
    }
}
