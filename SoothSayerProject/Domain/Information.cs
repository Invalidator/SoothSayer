using SoothSayer.Base;

namespace SoothSayer.Domain
{
    public sealed class Information : Entity
    {
        public override string EntityType => nameof(Information);
        public bool IsClue { get; set; }
        public bool IsFactual { get; set; }
    }
}