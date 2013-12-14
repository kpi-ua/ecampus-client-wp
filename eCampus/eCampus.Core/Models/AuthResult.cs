using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCampus.Core.Helpers
{
    public class AuthResult
    {
        public int StatusCode { get; set; }
        public string TimeStamp { get; set; }
        public string Guid { get; set; }
        public object Paging { get; set; }
        public string Data { get; set; }
    }
}
