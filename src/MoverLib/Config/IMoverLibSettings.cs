namespace MoverLib.Config
{
    public interface IMoverLibSettings
    {
        bool IsRelativePath { get; }
        string InputPath { get; }
        string? OutputPath { get; }
    }
}