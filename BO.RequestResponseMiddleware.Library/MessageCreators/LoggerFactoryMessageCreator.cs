namespace BO.RequestResponseMiddleware.Library.MessageCreators
{
    internal class LoggerFactoryMessageCreator : BaseLogMessageCreator, ILogMessageCreator
    {
        private readonly LoggingOptions loggingOptions;

        public LoggerFactoryMessageCreator(LoggingOptions loggingOptions)
        {
            this.loggingOptions = loggingOptions;
        }
        public string Create(RequestResponseContext context)
        {
            var sb = new StringBuilder();

            foreach(var field in loggingOptions.LoggingFields)
            {
                var value = GetValueByField(context, field);

                sb.AppendFormat("{0}: {1}\n", field, value);
            }

            return sb.ToString();
        }        
    }
}
