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
        Color fillColor = Colors.Aqua;
        int IComponentConnector = 1;
        int strokeThickness = 1;
        string shapeType = "";

        //public int strokeThickness { get; private set; }

        private void MyCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            myCanvas.Cursor = Cursors.Pen;
        }

        private void MyCanvas_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Cursor = Cursors.Cross;
            start = e.GetPosition(myCanvas);
            DisplayStatus();
        }

        private void DisplayStatus()
        {
            pointLabel.Content = $"( {Convert.ToInt32 (start.X)},{Convert.ToInt32 (start.Y)} - ({Convert.ToInt32(dest.X)}, {Convert.ToInt32(dest.Y)})";
            shapeLabel.Content = shapeType;
        }

        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = strokeColor;
            fillColorPicker.SelectedColor = fillColor;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            DisplayStatus();
        }

        private void MyCanvas_LeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private void StrokeThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = Convert.ToInt32(strokeThicknessSlider.Value);
        }

        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            var targetRadioButton = sender as RadioButton;
            shapeType = targetRadioButton.Tag.ToString();
            DisplayStatus();
        }


    }
}