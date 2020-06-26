using System;

namespace Painter.Core
{
    public abstract class ResultBase
    {
        protected ResultBase(bool isSuccessful, string? error)
        {
            IsSuccessful = isSuccessful;
            Error = error;
        }

        public bool IsSuccessful { get; }
        public string? Error { get; }

        public void EnsureSuccess()
        {
            if (!IsSuccessful)
                throw new Exception("");
        }
    }
}