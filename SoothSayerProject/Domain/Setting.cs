using System.Collections.Generic;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Setting : Entity
    {
        public override string EntityType => nameof(Setting);
        public IList<Series> Series { get; } = new List<Series>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return Series.SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return Series.SelectTemporalEntities();
            }
        }
    }
}