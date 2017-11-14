using System.Collections.Generic;
using System.Linq;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Book : Entity
    {
        public override string EntityType => nameof(Book);

        public IList<Chapter> Chapters { get; } = new List<Chapter>();
        public IList<Character> Cast { get; } = new List<Character>();
        public IList<Organization> Organizations { get; } = new List<Organization>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return Chapters.Combine<Entity>(Cast, Organizations).SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return Chapters.Combine<Entity>(Cast, Organizations).SelectTemporalEntities();
            }
        }
    }
}