using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ResultObject<T>
    {
        public T Result;
        public string Code = "200";
        public string Description;
        public bool Success = true;
        public Exception Ex;

        private ResultObject(T result, string code, bool success, string description, Exception ex)
        {
            Result = result;
            Code = code;
            Description = description;
            Success = success;
            Ex = ex;
        }

        public static ResultObject<T> Succeed(T result)
        {
            return new ResultObject<T>(result, "200", true, string.Empty, null);
        }

        public static ResultObject<T> Failure(string errorMessage, Exception ex)
        {
            return new ResultObject<T>(default, "400", false, errorMessage, ex);
        }
    }
}
