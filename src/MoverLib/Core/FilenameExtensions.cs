using System.Text.RegularExpressions;
using MoverLib.Models;

namespace MoverLib.Core
{
    public static class FilenameExtensions
    {
        public static BaseFilename GetBaseFilename(this Filename filename) => 
            new BaseFilename(
                CompiledRegex.BaseFilenameRegex
                .Match(filename)
                .Groups[2]
                .Value);
    }

    internal static class CompiledRegex
    {
        internal static Regex BaseFilenameRegex =>
            new Regex(
                @"(\[.*\]|\(.*\))*(.+)((?=(\[.*\]|\(\d*\))\d{2}-\d{2}_\d{2}_\d{2}\#\d{2})|(?=\s-\s\d{2}-\d{2}_\d{2}_\d{2}\#\d{2})|(?=\s-\s\d{2}\s)|(?=\.S\d{2}E\d{2})|(?=\s-\s\d\s+\[)|(?=\s\d+\s\d+p)|(?=(?<!\d{2})\s\[BD)|(?=(?<!\d{2})\s\[\d+p\])|(?=\s\[\d+p\]\s\[.*\])|(?=\s\d{2}\s\[BDRip\s.+\]))",
                RegexOptions.Compiled);
    }
}