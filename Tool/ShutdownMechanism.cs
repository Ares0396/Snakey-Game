using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey_Game.Tool
{
    public class ShutdownMechanism
    {
        public static void ShutdownComputer()
        {
            Process.Start("shutdown", "/s /t 0");
            Environment.Exit(0); // Ensure the application exits after initiating shutdown
        }
    }
}
