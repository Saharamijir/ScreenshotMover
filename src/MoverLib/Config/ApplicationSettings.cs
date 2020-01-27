// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace MoverLib.Config
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ApplicationSettings: IApplicationSettings
    {
        public bool IsRelativePath { get; set; }
        public string InputPath { get; set; }
        public string? OutputPath { get; set; }
    }
}