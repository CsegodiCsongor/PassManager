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
    /// Interaction logic for PasswordControll.xaml
    /// </summary>
    public partial class PasswordControll : UserControl
    {
        public string Username, Password,Description;
        public PasswordControll(string Username,string Password,string Description)
        {
            InitializeComponent();
            this.Username = Username;
            this.Password = Password;
            this.Description = Description;
            Update();
        }

        private void DeletePasswordBtn_Click(object sender, RoutedEventArgs e)
        {    
            for (int i = 0; i < Engine.controlls.Count; i++)
            {
                if (Engine.controlls[i].Username == Username &&
                   Engine.controlls[i].Password == Password &&
                   Engine.controlls[i].Description == Description)
                {
                    Engine.controlls.RemoveAt(i);
                    Engine.Update();
                    break;
                }
            }
        }

        private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow(this);
            m.Show();
        }

        public void Update()
        {
            DescriptionBox.Text = Description;
            UsernameBox.Text = Username;
            PasswordBox.Text = Password;
        }
    }
}
