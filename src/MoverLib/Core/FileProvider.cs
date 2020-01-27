using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoverLib.Config;
using MoverLib.Models;

namespace MoverLib.Core
{
    public class FileProvider : IFileProvider
    {
        private readonly IApplicationSettings _settings;

        public FileProvider(IApplicationSettings settings)
        {
            _settings = settings;
        }
        public IEnumerable<ScreenshotFile> GetScreenshotFiles() =>
            Directory.EnumerateFiles(_settings.InputPath).Select(ScreenshotFile.Create);
        
    }
}