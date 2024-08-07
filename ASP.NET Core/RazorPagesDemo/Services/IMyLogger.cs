namespace RazorPagesDemo.Services
{
    public interface IMyLogger
    {
        void Log(string message);//5
        void Error(string message);//1
        void Fatal(string message);//0
        void Info(string message);//4
        void Warn(string message);//3
        void Debug(string message);//2

    }
}
