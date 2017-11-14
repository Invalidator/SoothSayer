using System;
using System.Collections.Generic;
using System.Linq;

namespace SoothSayer.Base
{
    public static class Extensions
    {
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector)
        {
            return enumerable.GroupBy(keySelector).Select(group => group.First());
        }

        public static IEnumerable<Entity> SelectEntities(this IEnumerable<Entity> entities)
        {
            return entities.SelectMany(entity => entity.ChildEntities);
        }

        public static IEnumerable<Entity> SelectEntities(this IEnumerable<ITemporal<Entity>> temporalEntities)
        {
            return temporalEntities.SelectMany(temporalEntity => temporalEntity.Item.ChildEntities);
        }

        public static IEnumerable<ITemporal<Entity>> SelectTemporalEntities(this IEnumerable<ITemporal<Entity>> temporalEntities)
        {
            return temporalEntities.SelectMany(temporalEntity => temporalEntity.Item.ChildTemporalEntities);
        }

        public static IEnumerable<ITemporal<Entity>> SelectTemporalEntities(this IEnumerable<Entity> entities)
        {
            return entities.SelectMany(temporalEntity => temporalEntity.ChildTemporalEntities);
        }

        public static IEnumerable<T> Combine<T>(this IEnumerable<T> enumerable, params IEnumerable<T>[] otherEnumerables)
        {
            return enumerable.Concat(otherEnumerables.SelectMany(array => array));
        }

        public static IEnumerable<T> Combine<T>(this T first, params T[] others)
        {
            return new []{first}.Concat(others);
        }

        public static IEnumerable<T> Combine<T>(this T first, params IEnumerable<T>[] otherEnumerables)
        {
            return new [] {first}.Concat(otherEnumerables.SelectMany(array => array));
        }
    }
}