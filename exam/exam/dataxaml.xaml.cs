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
    /// Interaction logic for dataxaml.xaml
    /// </summary>
    public partial class dataxaml : Page
    { examEntities db = new examEntities();
        public dataxaml(string pass,userss s)
        {
            InitializeComponent();
            
            this.label.Content= pass+"'s ";
            this.nametxt.Content = s.username;
            this.passtxt.Content = "*********";
            this.citytxt.Content= s.city;
            this.phonetxt.Content = s.phone;
            this.agetxt.Content = s.age;
            this.gendertxt.Content = s.gender;
        }

        private void Button_Click(object sender, object e)
        {
            login s = new login();
            this.NavigationService.Navigate(s);
        }
    }
}
