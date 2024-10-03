namespace Core.Results.Abstract
{
    public interface IResullt
    {
        string Message { get; }
        bool IsSuccess { get; }
    }
}
