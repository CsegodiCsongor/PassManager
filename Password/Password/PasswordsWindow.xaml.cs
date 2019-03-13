using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography;

namespace Password
{
    public static class Engine
    {
        public static List<PasswordControll> controlls = new List<PasswordControll>();
        public static StackPanel sp;
        public static void Update()
        {
            sp.Children.Clear();
            for(int i=0;i<controlls.Count;i++)
            {
                sp.Children.Add(controlls[i]);
            }
        }
    }
    /// <summary>
    /// Interaction logic for PasswordsWindow.xaml
    /// </summary>
    public partial class PasswordsWindow : Window
    {
        public PasswordsWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            Read();
            Engine.sp = panel;
        }

        public void Read()
        {
            TextReader tx = new StreamReader(@"../../Passwords.txt");
            string aux;
            int i = 0;
            while ((aux = tx.ReadLine()) != null)
            {
                CesarCrypt cc = new CesarCrypt(aux.Split(' ')[2]);
               Engine.controlls.Add(new PasswordControll(aux.Split(' ')[1], cc.DeCrypt(3), aux.Split(' ')[0]));
                panel.Children.Add(Engine.controlls[i]);
                i++;
            }
        }

        private void AddPassButton_Click(object sender, RoutedEventArgs e)
        {
            Engine.controlls.Add(new PasswordControll("InsertUsername", "InsertPassword", "InsertDescription"));
            panel.Children.Add(Engine.controlls[Engine.controlls.Count - 1]);
        }

        private void SaveAllBtn_Click(object sender, RoutedEventArgs e)
        {
            TextWriter tw = new StreamWriter(@"../../Passwords.txt");
            for (int i = 0; i < Engine.controlls.Count; i++)
            {
                Engine.controlls[i].Password = Engine.controlls[i].PasswordBox.Text;
                Engine.controlls[i].Username = Engine.controlls[i].UsernameBox.Text;
                Engine.controlls[i].Description = Engine.controlls[i].DescriptionBox.Text;
                CesarCrypt cc = new CesarCrypt(Engine.controlls[i].Password);
                tw.Write(Engine.controlls[i].Description + " " + Engine.controlls[i].Username + " " + cc.EnCrypt(3));
                if (i != Engine.controlls.Count - 1)
                {
                    tw.Write("\n");
                }
            }
            tw.Flush();
            Close();
        }

    }
}
