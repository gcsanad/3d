using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelixToolkit;
using HelixToolkit.Wpf;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Gyongy> gyongyok = File.ReadAllLines("gyongyok.txt").Skip(1).Select(x => new Gyongy(x)).ToList();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var gyongy in gyongyok)
            {
                LinearGradientBrush szines = new LinearGradientBrush();
                szines.StartPoint = new Point(0, 0);
                szines.EndPoint = new Point(1, 1);
                szines.GradientStops.Add(
                    new GradientStop(Colors.Red, 0.0));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Green, 0.1));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Blue, 0.2));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Blue, 0.3));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Green, 0.4));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Red, 0.5));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Red, 0.6));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Green, 0.7));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Blue, 0.8));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Blue, 0.9));
                szines.GradientStops.Add(
                    new GradientStop(Colors.Green, 1.0));
                EllipsoidVisual3D gyongy3D = new EllipsoidVisual3D();
                Random rnd = new Random();
                gyongy3D.RadiusX = (byte)rnd.Next(0, 3000);
                gyongy3D.RadiusY = (byte)rnd.Next(0, 500);
                gyongy3D.RadiusZ = (byte)rnd.Next(0, 500);
                gyongy3D.Center = new Point3D(gyongy.X, gyongy.Y, gyongy.Z);
                gyongy3D.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
                
                ter.Children.Add(gyongy3D);

            }
        }
    }
}