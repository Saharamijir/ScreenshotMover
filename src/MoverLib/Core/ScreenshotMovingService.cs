using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoverLib.Config;
using MoverLib.Models;

namespace MoverLib.Core
{
    public class ScreenshotMovingService : IScreenshotMovingService
    {
        private readonly IMoverLibSettings _settings;

        public ScreenshotMovingService(IMoverLibSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Result MoveScreenshotsToSeriesDirectories(IEnumerable<ScreenshotFile> screenshotFiles)
        {
            try
            {
                screenshotFiles.GroupFiles().AsParallel().WithDegreeOfParallelism(4).ForAll(x =>
                {
                    var basePath = _settings.IsRelativePath ? _settings.InputPath : _settings.OutputPath!;
                    var (key, value) = x;
                    var seriesPath = System.IO.Path.Combine(basePath, key.Value);
                    var directory = Directory.CreateDirectory(seriesPath);
                    foreach (var screenshotFile in value)
                    {
                        MoveFile(screenshotFile, directory);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        private void MoveFile(ScreenshotFile screenshotFile, DirectoryInfo directory)
        {
            var screenshotOriginalFilenameString =
                $"{screenshotFile.Filename.Value}.{screenshotFile.Extension.Value}";
            var screenshotOldPath =
                System.IO.Path.Combine(screenshotFile.Path.Value, screenshotOriginalFilenameString);
            var screenshotNewPath =
                System.IO.Path.Combine(directory.FullName, screenshotOriginalFilenameString);
            File.Move(
                screenshotOldPath,
                screenshotNewPath
            );
        }
    }
}