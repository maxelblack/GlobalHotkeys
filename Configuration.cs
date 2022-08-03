using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotkeys
{

    internal class Configuration
    {
        public bool modernNotifyIcon;

        internal static Configuration DefaultConfig()
        {
            return new()
            {
                modernNotifyIcon = true,
            };
        }
    }
}
