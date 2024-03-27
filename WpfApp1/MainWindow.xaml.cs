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
        int index = 1;
        public MainWindow()
        {
            InitializeComponent();
            foreach (var gyongy in gyongyok)
            {
                
                EllipsoidVisual3D gyongy3D = new EllipsoidVisual3D();
                Random rnd = new Random();
                gyongy3D.RadiusX = 2;
                gyongy3D.RadiusY = 2;
                gyongy3D.RadiusZ = 3;
                gyongy3D.Center = new Point3D(gyongy.X, gyongy.Y, gyongy.Z);
                gyongy3D.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));                
                ter.Children.Add(gyongy3D);

            }
        }
    }
}