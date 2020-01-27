using System;

namespace MoverLib.Models
{
    public class Filename
    {
        private bool Equals(Filename other)
        {
            return Value == other.Value;
        }

        public static implicit operator string(Filename filename)
        {
            return filename.Value;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Filename) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Filename? left, Filename? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Filename? left, Filename? right)
        {
            return !Equals(left, right);
        }

        internal Filename(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"Filename: {Value}";
        }
    }
}