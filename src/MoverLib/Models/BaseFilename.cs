using System;

namespace MoverLib.Models
{
    public class BaseFilename
    {
        protected bool Equals(BaseFilename other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseFilename) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(BaseFilename? left, BaseFilename? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseFilename? left, BaseFilename? right)
        {
            return !Equals(left, right);
        }

        public BaseFilename(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"BaseFilename: {Value}";
        }
    }
}