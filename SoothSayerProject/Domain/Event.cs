using System.Collections.Generic;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Event : Entity
    {
        public override string EntityType => nameof(Event);
        public IList<Location> HappensAt { get; } = new List<Location>(); 
        public IList<Information> RevealedInformation { get; } = new List<Information>();
        public IList<Character> Participants { get; } = new List<Character>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return HappensAt.Combine<Entity>(RevealedInformation, Participants).SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return HappensAt.Combine<Entity>(RevealedInformation, Participants).SelectTemporalEntities();
            }
        }
    }
}