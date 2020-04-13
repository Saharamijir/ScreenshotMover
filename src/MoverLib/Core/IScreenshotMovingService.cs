using System.Collections.Generic;
using MoverLib.Models;

namespace MoverLib.Core
{
    public interface IScreenshotMovingService
    {
        Result MoveScreenshotsToSeriesDirectories(IEnumerable<ScreenshotFile> screenshotFiles);
    }
}