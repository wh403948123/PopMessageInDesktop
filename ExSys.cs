using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace popmsg
{
    public class ExSys : Exception
    {
        public ExSys(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }
    }
    public class ExFNP_UP : Exception // File not prepared for uploader processor
    {
        public ExFNP_UP(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }
    }
}
