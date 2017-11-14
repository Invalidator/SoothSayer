using SoothSayer.Domain;

namespace SoothSayer.Base
{

    public sealed class Temporal<T> : ITemporal<T>
    {
        public NarrativePointInTime Start { get; set;}
        public NarrativePointInTime End { get; set;}
        public T Item { get; set; }
    }
}