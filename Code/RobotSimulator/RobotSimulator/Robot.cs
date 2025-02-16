using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace RobotSimulator
{
    internal class Robot
    {
        public Robot() { }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public DirectionFacing DirectionFacing { get; set; }

        public void PositionRobotOnGrid(Rectangle robotRectangle, Robot robot)
        {
            Grid.SetColumn(robotRectangle, robot.XPosition);
            Grid.SetRow(robotRectangle, robot.YPosition);
        }
    }
}
