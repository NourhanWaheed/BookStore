using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.LoggerService
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
