using System;
using MoverLib.Core;

namespace MoverConsole.Core
{
    internal class ServiceRunner : IServiceRunner
    {
        private readonly IScreenshotMovingService _screenshotMovingService;
        private readonly IFileProvider _fileProvider;

        public ServiceRunner(
            IScreenshotMovingService screenshotMovingService,
            IFileProvider fileProvider)
        {
            _screenshotMovingService = screenshotMovingService ?? throw new ArgumentNullException(nameof(screenshotMovingService));
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }

        public Result Run()
        {
            return _screenshotMovingService.MoveScreenshotsToSeriesDirectories(_fileProvider.GetScreenshotFiles());
        }
    }
}