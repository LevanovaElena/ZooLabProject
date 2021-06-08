using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Common
{
    public interface IConsole
    {
        public void WriteLine(string message);
    }

    public class ZooConsole : IConsole
    {
        public List<string> Messages { get; set; } = new List<string>();
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            Messages.Add(message);
        }
    }
}
