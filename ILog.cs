using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Automation.Helper
{
    public interface ILog
    {
       void LogException(string message);
        void LogInfo(string message);
    }
}
