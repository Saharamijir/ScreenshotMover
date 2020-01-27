using System.Collections.Generic;
using System.Linq;
using MoverLib.Models;

namespace MoverLib.Core
{
    public static class ScreenshotFileExtensions
    {
        public static Dictionary<BaseFilename, IEnumerable<ScreenshotFile>> GroupFiles(this IEnumerable<ScreenshotFile> files) =>
            files.GroupBy(f => f.BaseFilename)
                .ToDictionary(
                    x => x.Key, 
                    x => x.Select(y => y)
                );
    }
}