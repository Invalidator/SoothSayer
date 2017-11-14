using System.Collections.Generic;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Character : Entity
    {
        public override string EntityType => nameof(Character);
        public IList<Item> Inventory = new List<Item>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return ChildEntities.SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return ChildEntities.SelectTemporalEntities();
            }
        }
    }
}