using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabApplication.Common;

namespace ZooLabApplication
{
    public class ZooApp
    {
       // private List<Zoo> _zoos=new List<Zoo>();
        public List<Zoo> Zoos { get; }=new List<Zoo>();
        public ZooConsole myConsole { get; set; }

        public ZooApp(ZooConsole console=null)
        {
            myConsole = console;
        }
        public void AddZoo(Zoo zoo)
        {
            Zoos.Add(zoo);
            myConsole?.WriteLine("Added new zoo located in " + zoo.Location);
        }
    }
}
