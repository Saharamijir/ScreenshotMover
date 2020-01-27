using System.Collections.Generic;
using MoverLib.Models;
namespace MoverLib.Core
{
    public interface IFileProvider
    {
        IEnumerable<ScreenshotFile> GetScreenshotFiles();
    }
}