// ReSharper disable UnusedAutoPropertyAccessor.Global

using MoverLib.Config;

namespace MoverConsole.Config
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class ApplicationSettings: IApplicationSettings
    {
        public bool IsRelativePath { get; set; } = false;
        public string InputPath { get; set; } = "";
        public string? OutputPath { get; set; }
    }
}