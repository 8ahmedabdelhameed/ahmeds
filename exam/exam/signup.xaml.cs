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
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
        examEntities db = new examEntities();
        public signup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login s = new login();
            this.NavigationService.Navigate(s);
        }
        private bool isvalid(string password)
        {
            bool lower, digit, special;
            lower = digit = special = false;
            string set = "!@#$%^&*()_";
            foreach (char s in password)
            {

                if (s >= 'a' && s <= 'b')
                { lower = true; }
                else if (s >= '0' && s <= '9')
                { digit = true; }
                else if (set.Contains(s))
                {
                    special = true;
                }

            }
            return lower && digit && special;

        }
        private void sign_upbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userss tab = new userss();
                tab.username = nametxt.Text;
                if (isvalid(passtxt.Text))
                {
                    tab.userpassword = passtxt.Text;
                }
                else { MessageBox.Show("password must contain digit nums chars"); }
                if (numtxt.Text.Length == 11)
                {
                    tab.phone = numtxt.Text;
                }
                else { MessageBox.Show("number must be 11  digit length "); }

                int age = int.Parse(agetxt.Text);
                if (age >= 18 && age <= 60)
                {
                    tab.age = int.Parse(agetxt.Text);
                }
                else { MessageBox.Show("age must be between 18 and 60 "); }
                if (male.IsEnabled)
                {
                    tab.gender = "male";
                }
                else if (female.IsEnabled)
                {
                    tab.gender = "female";

                }
                else { MessageBox.Show("choose only 1 gender"); }
                tab.city = combo.Text;
                db.usersses.Add(tab);
                db.SaveChanges();
                MessageBox.Show("a new user has been added go sign in");
                    }
            catch { MessageBox.Show("wrong input unable to add user" +
                ""); }

        }
    }
}
