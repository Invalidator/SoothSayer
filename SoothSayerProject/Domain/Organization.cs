using System.Collections.Generic;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Organization : Entity
    {
        public override string EntityType => nameof(Organization);
        public IList<Temporal<Character>> Membership { get; } = new List<Temporal<Character>>();
        public IList<Temporal<Item>> Property { get; } = new List<Temporal<Item>>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return Membership.Combine<ITemporal<Entity>>(Property).SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return Membership.Combine<ITemporal<Entity>>(Property).SelectTemporalEntities();
            }
        }
    }
}