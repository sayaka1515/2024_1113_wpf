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

namespace _2024_1030_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Point start = new Point {X=0,Y=0 };
        Point dest = new Point { X = 0, Y = 0 };
        Color strokeColor = Colors.Black;
        int IComponentConnector = 1;
        string shapeType = "";

        public int strokeThickness { get; private set; }

        private void myCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            myCanvas.Cursor = Cursors.Pen;
        }

        private void myCanvas_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Cursor = Cursors.Cross;
            start = e.GetPosition(myCanvas);
            DisplayStatus(start, dest);
        }

        private void DisplayStatus(Point start, Point dest)
        {
            pointLabel.Content = $"( {Convert.ToInt32 (start.X)},{Convert.ToInt32 (start.Y)} - ({Convert.ToInt32(dest.X)}, {Convert.ToInt32(dest.Y)})";
        }

        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = strokeColor;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            DisplayStatus(start, dest);
        }

        private void myCanvas_LeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Brush brush = new SolidColorBrush(strokeColor);
            Line line = new Line
            {
                Stroke = brush,

                StrokeThickness = strokeThickness,
                X1 = start.X,
                Y1 = start.Y,
                X2 = dest.X,
                Y2 = dest.Y
            };
            myCanvas.Children.Add(line);
        }

        private void strokeThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = Convert.ToInt32(strokeThicknessSlider.Value);
        }

        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            var targetRadioButton = sender as RadioButton;
            shapeType = targetRadioButton.Tag.ToString();
            shapeLabel.Content = shapeType;
        }


    }
}