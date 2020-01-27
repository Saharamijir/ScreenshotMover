using System;

namespace MoverLib.Models
{
    public class Extension
    {
        private bool Equals(Extension other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Extension) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Extension? left, Extension? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Extension? left, Extension? right)
        {
            return !Equals(left, right);
        }

        public string Value { get; }
        internal Extension(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString()
        {
            return $"Extension: {Value}";
        }
    }
}