using System.Collections.Generic;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Chapter : Entity
    {
        public override string EntityType => nameof(Chapter);
        public Character PointOfViewCharacter { get; set; }
        public IList<Information> SuppliedInformation { get; } = new List<Information>();
        public IList<Character> FeaturedCharacters { get; } = new List<Character>();
        public IList<Event> Happenings { get; } = new List<Event>();
        public IList<Location> FeaturedLocations { get; } = new List<Location>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return PointOfViewCharacter
                .Combine<Entity>(
                    SuppliedInformation, 
                    FeaturedCharacters,
                    Happenings,
                    FeaturedLocations)
                    .SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return PointOfViewCharacter
                .Combine<Entity>(
                    SuppliedInformation, 
                    FeaturedCharacters,
                    Happenings,
                    FeaturedLocations)
                    .SelectTemporalEntities();
            }
        }
    }
}