using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            // Write the log to a storage
            // ...

            OnErrorLogged(Guid.NewGuid());
        }

        protected virtual void OnErrorLogged(Guid errorId)
        {
            //Dont test private method
            //Changed the implementation by creating this method and moving the event
            //This doesn't break the public API and therefore the tests still pass
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}
