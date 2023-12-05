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

namespace exam
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        examEntities db = new examEntities();
        public login()
        {
            InitializeComponent();
        }

        private void signupb_Click(object sender, RoutedEventArgs e)
        {
            signup s = new signup();
            this.NavigationService.Navigate(s);
        }

        private void forgetb_Click(object sender, RoutedEventArgs e)
        {
            forget f = new forget();
            this.NavigationService.Navigate(f);
        }

        private void confirmb_Click(object sender, RoutedEventArgs e)
        {  if (combo.Text == "user")
            {
                userss tab = new userss();
                try
                {
                    tab = db.usersses.FirstOrDefault(x => x.username == nametxt.Text && x.userpassword == passtxt.Text);
                    if (tab != null)
                    {
                        string pass = nametxt.Text;
                        dataxaml dataxaml = new dataxaml(pass, tab);
                        MessageBox.Show("right information");
                        this.NavigationService.Navigate(dataxaml);

                    }
                    else { MessageBox.Show("check the password and username again"); }
                }
                catch { MessageBox.Show("wrong input"); }
            }
        else if (combo.Text=="admin")
            {

            }
        }
    }
}
