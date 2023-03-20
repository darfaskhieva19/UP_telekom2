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

namespace ТелекомНеваСвязь
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.Base = new Entities();
            ClassFrame.Mframe = frameL;
            ClassFrame.Mframe.Navigate(new PageSubscriber());
            tbTitle.Text = "Абоненты ТНС";
            List<Employees> employees = DataBase.Base.Employees.ToList();
            foreach(Employees employee in employees)
            {
                cbUser.Items.Add(employee.Surname + " " + employee.Name + " " + employee.Patronymic);
            }
            cbUser.SelectedIndex = 0;            
        }

        private void cbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spAbon.Visibility = Visibility.Collapsed;
            spActiv.Visibility = Visibility.Collapsed;
            spBill.Visibility = Visibility.Collapsed;
            spCRM.Visibility = Visibility.Collapsed;
            spEquip.Visibility = Visibility.Collapsed;
            spPodPol.Visibility = Visibility.Collapsed;
            if (cbUser.SelectedIndex != 0)
            {
                Employees employees = DataBase.Base.Employees.FirstOrDefault(z => z.ID == cbUser.SelectedIndex + 1);
                //imgUser.ImageSource = new BitmapImage(new Uri("../../picture/" + employees.Photo, UriKind.Relative)); //фото пользователя 
                List<Information> information = DataBase.Base.Information.Where(z => z.IDRole == employees.IDRole).ToList();
                listEvent.ItemsSource = information;
                switch (employees.IDRole)
                {
                    case 1:
                        spAbon.Visibility = Visibility.Visible;
                        spCRM.Visibility = Visibility.Visible;
                        spBill.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        spAbon.Visibility = Visibility.Visible;
                        spCRM.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        spAbon.Visibility = Visibility.Visible;
                        spPodPol.Visibility = Visibility.Visible;
                        spCRM.Visibility = Visibility.Visible;
                        spEquip.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        spAbon.Visibility = Visibility.Visible;
                        spPodPol.Visibility = Visibility.Visible;
                        spCRM.Visibility = Visibility.Visible;
                        spEquip.Visibility = Visibility.Visible;
                        break;
                    case 5:
                        spAbon.Visibility = Visibility.Visible;
                        spBill.Visibility = Visibility.Visible;
                        spActiv.Visibility = Visibility.Visible;
                        break;
                    case 6:
                        spAbon.Visibility = Visibility.Visible;
                        spPodPol.Visibility = Visibility.Visible;
                        spCRM.Visibility = Visibility.Visible;
                        spEquip.Visibility = Visibility.Visible;
                        spBill.Visibility = Visibility.Visible;
                        spActiv.Visibility = Visibility.Visible;
                        break;
                    case 7:
                        spAbon.Visibility = Visibility.Visible;
                        spActiv.Visibility = Visibility.Visible;
                        spEquip.Visibility = Visibility.Visible;
                        spCRM.Visibility = Visibility.Visible;
                        break;
                        default:
                        break;
                }                            
            }
        }

        private void spAbon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClassFrame.Mframe.Navigate(new PageSubscriber());
            tbTitle.Text = "Абоненты ТНС";
        }

        private void spCRM_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClassFrame.Mframe.Navigate(new PageCRM());
            tbTitle.Text = "CRM";
        }
    }
}
