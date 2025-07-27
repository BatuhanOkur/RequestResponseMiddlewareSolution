namespace BO.RequestResponseMiddleware.Library.Interfaces
{
    public interface ILogWriter
    {
        ILogMessageCreator MessageCreator { get;}
        Task Write(RequestResponseContext context);
    }
}
