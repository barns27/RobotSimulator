using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator
{
    class CommonHelper
    {
        public int SetYPositionMessage(int yPosition)
        {
            int returnValue;
            switch (yPosition)
            {
                case 4:
                    returnValue = 1; break;
                case 3:
                    returnValue = 2; break;
                case 2:
                    returnValue = 3; break;
                case 1:
                    returnValue = 4; break;
                case 0:
                    returnValue = 5; break;
                default:
                    throw new ArgumentOutOfRangeException("yPosition", "Invalid yPosition value: " + yPosition);
            }
            return returnValue;
        }

        public int SetYComboboxSelectionValue(int yPosition)
        {
            int returnValue;
            switch (yPosition)
            {
                case 1:
                    returnValue = 4; break;
                case 2:
                    returnValue = 3; break;
                case 3:
                    returnValue = 2; break;
                case 4:
                    returnValue = 1; break;
                case 5:
                    returnValue = 0; break;
                default:
                    throw new ArgumentOutOfRangeException("yPosition", "Invalid yPosition value: " + yPosition);
            }
            return returnValue;
        }

        public bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < 5 && y >= 0 && y < 5;
        }
    }
}
