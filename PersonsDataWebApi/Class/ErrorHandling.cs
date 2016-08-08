namespace PersonsDataWebApi.Class
{
    using System;

    using PersonsDataWebApi.Interface;

    public class ErrorHandling : IErrorHandling
    {
        private const string Prefix = "PersonsData: ";

        public void LogInfo(string message)
        {
            Console.WriteLine("{0} Info-{1}", Prefix, message);
        }

        public void LogWarning(string message)
        {
            Console.WriteLine("{0} Warning-{1}", Prefix, message);
        }

        public void LogError(string message)
        {
            Console.WriteLine("{0} Error-{1}", Prefix, message);
        }
    }
}