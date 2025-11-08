using Common.RestApi.Constants;
using Serilog;
using Serilog.Events;
namespace Omni.Services.Logging
{
    public class Seriloger
    {
        public Seriloger(string name)
        {
            Log.ForContext(LoggerConstant.Actor, name);
        }

        public static Seriloger GetInstant(string name)
        {
            return new Seriloger(name);
        }

        public static Seriloger GetInstant(Type type)
        {
            return new Seriloger(type.FullName);
        }

        public void Debug(string message)
        {
            WriteTo(message, LogEventLevel.Debug);
        }

        public void Error(string message, Exception exception)
        {
            WriteTo(message, LogEventLevel.Error, exception);
        }

        public void Fatal(string message, Exception exception)
        {
            WriteTo(message, LogEventLevel.Fatal, exception);
        }

        public void Info(string message)
        {
            WriteTo(message, LogEventLevel.Information);
        }

        public void Warn(string message)
        {
            WriteTo(message, LogEventLevel.Warning);
        }

        private void WriteTo(string message, LogEventLevel level, Exception exception = null)
        {
            Log.Logger.Write(level, message, exception);
        }
    }
}
