using SoothSayer.Domain;

namespace SoothSayer.Base
{
    public interface ITemporal
    {
        NarrativePointInTime Start { get; }
        NarrativePointInTime End { get; }
    }

    public interface ITemporal<out T>
    {
        T Item { get; }
    }
}