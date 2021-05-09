using log4net;
using System;
using System.Collections.Generic;
using SRC.LIB;

namespace SRC.MySQL.Logic
{
    public abstract class MySQLBaseLogic
    {
        protected readonly IMySQLUnitOfWork _unitOfWork;
        private static readonly IDictionary<Type, ILog> _logs = new Dictionary<Type, ILog>();

        private static readonly object _lock = new object();

        protected ILog Log
        {
            get
            {
                var type = GetType();
                var result = _logs.GetOrDefault(type);
                lock (_lock)
                {
                    if (result == null)
                    {
                        result = LogManager.GetLogger(type);
                        _logs.AddOrReplace(type, result);
                    }
                }
                return result;
            }
        }

        protected MySQLBaseLogic(IMySQLUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
