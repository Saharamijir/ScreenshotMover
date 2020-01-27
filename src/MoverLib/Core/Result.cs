namespace MoverLib.Core
{
    public struct Result
    {
        public bool IsError { get; }

        public Result(bool isError)
        {
            IsError = isError;
        }

        public static implicit operator Result(bool result)
        {
            return new Result(result);
        }
    }
}