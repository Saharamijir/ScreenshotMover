using System;
using MoverLib.Core;

namespace MoverLib.Models
{
    public class ScreenshotFile
    {
        protected bool Equals(ScreenshotFile other)
        {
            return Path.Equals(other.Path) && Filename.Equals(other.Filename) && Extension.Equals(other.Extension);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ScreenshotFile) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Path.GetHashCode();
                hashCode = (hashCode * 397) ^ Filename.GetHashCode();
                hashCode = (hashCode * 397) ^ Extension.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ScreenshotFile? left, ScreenshotFile? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScreenshotFile? left, ScreenshotFile? right)
        {
            return !Equals(left, right);
        }

        public Path Path { get; }
        public Filename Filename { get; }
        public Extension Extension { get; }
        public BaseFilename BaseFilename { get; }
        private ScreenshotFile(Path path, Filename filename, Extension extension)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Filename = filename ?? throw new ArgumentNullException(nameof(filename));
            Extension = extension ?? throw new ArgumentNullException(nameof(extension));
            BaseFilename = Filename.GetBaseFilename();
        }

        public static ScreenshotFile Create(string file)
        {
            var path = new Path(System.IO.Path.GetDirectoryName(file)!);
            var filename = new Filename(System.IO.Path.GetFileNameWithoutExtension(file));
            var extension = new Extension(System.IO.Path.GetExtension(file).TrimStart('.'));
            return new ScreenshotFile(path, filename, extension);
        }

        public override string ToString()
        {
            return $@"
{{
    {Path},
    {Filename},
    {Extension},
    {BaseFilename}
}}
";
        }
    }
}