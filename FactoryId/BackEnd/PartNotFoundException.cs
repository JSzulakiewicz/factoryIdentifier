using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class PartNotFoundException : Exception
    {
        private ErrorNumber error;
        public override string Message
        {
            get
            {
                switch (error)
                {
                    case ErrorNumber.PartNotFound: return "Part not found";
                    case ErrorNumber.WrongFormat: return "Part ID provided has wrong format";
                    default: return error.ToString();
                }
            }
        }
        public PartNotFoundException(ErrorNumber _error)
        {
            this.error = _error;
        }

        public enum ErrorNumber
        {
            WrongFormat,
            PartNotFound
        }
    }
}
