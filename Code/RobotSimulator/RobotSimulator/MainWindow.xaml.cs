using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace RobotSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Robot robot = new Robot();
        private Rectangle robotRectangle = new Rectangle();
        private CommonHelper helper = new CommonHelper();
        public MainWindow()
        {
            InitializeComponent();
            InitializeRobot();
            // Bind the ComboBox directly to the enum values.
            DirectionFacingCombobox.ItemsSource = Enum.GetValues(typeof(DirectionFacing));
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PositionOutputLabel.Content = $"{(robot.XPosition + 1)},{helper.SetYPositionMessage(robot.YPosition)}";
                DirectionFacingOutputLabel.Content = $"{robot.DirectionFacing}";
                ChangeLabelContent();
                MessageBox.Show("Position: " + (robot.XPosition + 1).ToString() + "," + helper.SetYPositionMessage(robot.YPosition).ToString() + "\nDirection Facing: " + robot.DirectionFacing);
            }
            catch (ArgumentOutOfRangeException a)
            {
                MessageBox.Show(a.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PlaceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (XCombobox.Text.Equals("-") ||
                        YCombobox.Text.Equals("-"))
                {
                    MessageBox.Show("Please input values on X, Y and Direction Facing to place robot on table.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    robot.XPosition = int.Parse(XCombobox.Text) - 1;
                    robot.YPosition = helper.SetYComboboxSelectionValue(int.Parse(YCombobox.Text));
                    robot.DirectionFacing = (DirectionFacing)DirectionFacingCombobox.SelectedItem;
                    robot.PositionRobotOnGrid(robotRectangle, robot);
                    ChangeLabelContent();
                }
            }
            catch(ArgumentOutOfRangeException a)
            {
                MessageBox.Show(a.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                robot.DirectionFacing = (DirectionFacing)(((int)robot.DirectionFacing - 1 + 4) % 4);
                robot.PositionRobotOnGrid(robotRectangle, robot);
                ChangeLabelContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                robot.DirectionFacing = (DirectionFacing)(((int)robot.DirectionFacing + 1 + 4) % 4);
                robot.PositionRobotOnGrid(robotRectangle, robot);
                ChangeLabelContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nextXValue = robot.XPosition;
                int nextYValue = robot.YPosition;

                switch (robot.DirectionFacing)
                {
                    case DirectionFacing.North: nextYValue--; break;
                    case DirectionFacing.East: nextXValue++; break;
                    case DirectionFacing.South: nextYValue++; break;
                    case DirectionFacing.West: nextXValue--; break;
                }

                if (helper.IsValidMove(nextXValue, nextYValue))
                {
                    robot.XPosition = nextXValue;
                    robot.YPosition = nextYValue;
                    robot.PositionRobotOnGrid(robotRectangle, robot);
                    ChangeLabelContent();
                }
                else
                {
                    MessageBox.Show("Robot cannot be moved beyond the table.", "Stop!", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region Internal Methods
        private void InitializeRobot()
        {
            try
            {
                robotRectangle = new Rectangle { Width = 40, Height = 40, Fill = Brushes.Blue };
                this.TableGrid.Children.Add(robotRectangle);
                robot.XPosition = 0;
                robot.YPosition = 4;
                robot.DirectionFacing = DirectionFacing.East;
                robot.PositionRobotOnGrid(robotRectangle, robot);
                ChangeLabelContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeLabelContent()
        {
            PositionOutputLabel.Content = $"{(robot.XPosition + 1)},{helper.SetYPositionMessage(robot.YPosition)}";
            DirectionFacingOutputLabel.Content = $"{robot.DirectionFacing}";
        }


        #endregion

        
    }
}