using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEx.Lib
{
    public class VectorException : Exception
    {
        int _codenumber;
        public VectorException(int codenumber, string msg) : base(msg)
        {
            _codenumber = codenumber;
        }

        public override string Message
        {
            get
            {
                return $"Code  {_codenumber}: {base.Message} ";
            }
        }
    }
}
