namespace PersonsDataWebApi.Interface
{
    interface IErrorHandling
    {
        void LogInfo(string message);

        void LogWarning(string message);

        void LogError(string message);
    }
}