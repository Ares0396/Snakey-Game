using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey_Game.Tool
{
    public class Parser
    {
        public static string ParseNameFromRegData(string regData)
        {
            // Assuming the regData is in the format "PlayerName.snakedataX"
            int index = regData.LastIndexOf(".snakedata");
            if (index > 0)
            {
                return regData.Substring(0, index);
            }
            return regData; // Return the original string if the expected format is not found
        }
    }
}
