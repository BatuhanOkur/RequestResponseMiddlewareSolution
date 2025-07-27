namespace BO.RequestResponseMiddleware.Library.Interfaces
{
    public interface ILogMessageCreator
    {
        string Create(RequestResponseContext context);
    }
}
