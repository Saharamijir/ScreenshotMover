using System;

namespace MoverLib.Models
{
    public class Path
    {
        private bool Equals(Path other)
        {
            return Value == other.Value;
        }

        public static bool operator ==(Path? left, Path? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Path? left, Path? right)
        {
            return !Equals(left, right);
        }

        public string Value { get; }

        internal Path(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Path) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"Path: {Value}";
        }
    }
}