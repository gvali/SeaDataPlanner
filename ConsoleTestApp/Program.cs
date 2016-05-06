using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interface;
using NLog;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
         IUserNameResolver userNameResolver;
         NLog.ILogger logger;

        //var ctx = new DataBaseContext(userNameResolver ,logger);
        //var p = ctx.Persons.ToList();

        }
    }
}
