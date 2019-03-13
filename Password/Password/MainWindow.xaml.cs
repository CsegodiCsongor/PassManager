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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   

    public partial class MainWindow : Window
    {
        public PasswordGenerator p;
        public PasswordControll pc;

        public MainWindow(PasswordControll pc)
        {
            InitializeComponent();
            PasswordGenerator.Lowercase = new char[26];
            PasswordGenerator.Uppercase = new char[26];

            for (char x='a';x<='z';x++)
            {
                PasswordGenerator.Lowercase[x - 97] = x;
                PasswordGenerator.Uppercase[x - 97] =(char)(x-32);
            }
            this.pc = pc;

        }

        private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            int lenght;
            if(LengthTextBox.Text=="")
            {
                lenght = 5;
            }
            else
            {
                lenght = int.Parse(LengthTextBox.Text);
            }
            p = new PasswordGenerator(lenght,NumbersCheckBox.IsChecked.Value, LowerCheckBox.IsChecked.Value, UpperCheckBox.IsChecked.Value, SymbolsCheckBox.IsChecked.Value, AmbigCheckBox.IsChecked.Value);
            PasswordTextBox.Text = p.GetPass();
           
        } 

        public string GetPass()
        {
            return p.GetPass();
        }

        private void SavePassButton_Click(object sender, RoutedEventArgs e)
        {
            pc.Password = GetPass();
            pc.PasswordBox.Text = GetPass();
            Close();
        }
    }
}
