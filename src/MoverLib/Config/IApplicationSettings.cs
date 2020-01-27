namespace MoverLib.Config
{
    public interface IApplicationSettings
    {
        bool IsRelativePath { get; }
        string InputPath { get; }
        string? OutputPath { get; }
    }
}