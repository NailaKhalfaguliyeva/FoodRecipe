namespace Core.Results.Abstract
{
    public interface IDataResult<T> : IResullt
    {
        T Data { get; }
    }
}
