using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for forget.xaml
    /// </summary>
    public partial class forget : Page
    {
        examEntities db = new examEntities();
        public forget()
        {
            InitializeComponent();
        }
        private bool isvalid (string password)
        {
            bool  lower ,digit , special ;
            lower=digit=special=false;
            string set = "!@#$%^&*()_";
           foreach(char s in password)
            {
               
                if (s >= 'a' && s <= 'b')
                { lower = true; }
                else if (s >= '0' && s <= '9')
                { digit= true; }
                else if (set.Contains(s))
                {
                    special= true;
                }
             
            }
           return lower && digit && special;

        }
        private void updatepassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userss tab = new userss();
             tab =   db.usersses.FirstOrDefault(x => x.phone == phonetxt.Text);
                if (newpasstxt.Text == confirmpasstxt.Text && isvalid(confirmpasstxt.Text))
                {
             
                    tab.userpassword = confirmpasstxt.Text;
                    db.usersses.AddOrUpdate(tab);
                    db.SaveChanges();
                    MessageBox.Show(tab.username + "'s password has been updated");
                    login login = new login();
                    this.NavigationService.Navigate(login);}
                else { MessageBox.Show("passsword must contain digit and chars and special chars"); }
                
           
            }
            catch { MessageBox.Show("wrong input check again"); }

        }
    }
}
