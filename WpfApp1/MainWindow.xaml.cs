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
        int tavolsag = 10;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var gyongy in gyongyok)
            {
                
                EllipsoidVisual3D gyongy3D = new EllipsoidVisual3D();
                gyongy3D.RadiusX = gyongy.Ertek;
                gyongy3D.RadiusY = gyongy.Ertek;
                gyongy3D.RadiusZ = gyongy.Ertek;
                gyongy3D.Center = new Point3D(gyongy.X*tavolsag, gyongy.Y*tavolsag, gyongy.Z*tavolsag);
                gyongy3D.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));                
                ter.Children.Add(gyongy3D);

            }

            


        }

        private LinesVisual3D Vonalak(Gyongy elso, Gyongy masodik)
        {
            LinesVisual3D lines = new()
            {
                Points = new PointCollection(new Point3D[] {elso.X,elso.Y,elso.Z})
            };

            lines.Thickness = 10;

            ter.Children.Add(lines);
        }
    }
}