using System.Collections.Generic;
using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Series : Entity
    {
        public override string EntityType => nameof(Series);
        public IList<Book> Books {get;} = new List<Book>();

        public override IEnumerable<Entity> ChildEntities
        {
            get
            {
                return Books.SelectEntities();
            }
        }

        public override IEnumerable<ITemporal<Entity>> ChildTemporalEntities
        {
            get
            {
                return Books.SelectTemporalEntities();
            }
        }
    }
}