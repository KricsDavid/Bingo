using System.IO;
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

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        public List<BingoJatekos> Beolvasas()
        {
            List<BingoJatekos> jatekosok = new List<BingoJatekos>();

            string[] files = Directory.GetFiles("forras", "*.txt");
            foreach (string file in files)
            {
                string nev = System.IO.Path.GetFileNameWithoutExtension(file);
                int[,] kartya = BeolvasKartya(file);
                BingoJatekos jatekos = new BingoJatekos(nev, kartya);
                jatekosok.Add(jatekos);
            }

            return jatekosok;
        }

        private int[,] BeolvasKartya(string file)
        {
            int[,] kartya = new int[5, 5];
            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i < 5; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < 5; j++)
                {
                    kartya[i, j] = int.Parse(values[j]);
                }
            }
            return kartya;
        }


        public int JatekosokSzama(List<BingoJatekos> jatekosok)
        {
            return jatekosok.Count;
        }



        public List<int> Szamhuzasok()
        {
            List<int> szamhuzasok = new List<int>();
            Random random = new Random();

            while (true)
            {
                int szam = random.Next(1, 76);
                if (!szamhuzasok.Contains(szam))
                {
                    szamhuzasok.Add(szam);
                    Console.WriteLine("Kihúzott szám: " + szam);
                    foreach (BingoJatekos jatekos in jatekosok)
                    {
                        jatekos.SorsoltSzamotJelol(szam);
                        if (jatekos.BingoEll())
                        {
                            Console.WriteLine("BINGÓ! A nyertes: " + jatekos.Nev);
                            return szamhuzasok;
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid.Children.Clear();
            int[,] kartya = GeneraltKartya();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = 30;
                    textBox.Height = 30;
                    textBox.HorizontalAlignment = HorizontalAlignment.Center;
                    textBox.VerticalAlignment = VerticalAlignment.Center;
                    textBox.Text = kartya[i, j].ToString();
                    uniformGrid.Children.Add(textBox);
                }
            }
        }
    }



}