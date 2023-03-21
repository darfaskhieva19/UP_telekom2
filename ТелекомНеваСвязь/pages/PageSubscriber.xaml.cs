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
    /// Логика взаимодействия для PageSubscriber.xaml
    /// </summary>
    public partial class PageSubscriber : Page
    {
        public PageSubscriber()
        {
            InitializeComponent();
            dgSubscriber.ItemsSource = DataBase.Base.Subscriber.ToList();
            List<DistrictsAddress> districts = DataBase.Base.DistrictsAddress.ToList(); //заполнение ComboBox с районами
            cbRaion.Items.Add("Все районы");
            foreach (DistrictsAddress district in districts)
            {
                cbRaion.Items.Add(district.DistrictsName);
            }
            cbRaion.SelectedIndex = 0;
            List<Address> addresses = DataBase.Base.Address.ToList(); //заполнение ComboBox с улицами
            cbStreet.Items.Add("Все улицы");
            foreach (Address address in addresses)
            {
                if (address.Home != null)
                {
                    cbStreet.Items.Add(address.Street1.StreetName + ", " + address.Home);
                }
                else
                {
                    cbStreet.Items.Add(address.Street1.StreetName);
                }
            }
            cbStreet.SelectedIndex = 0;           
        }
        /// <summary>
        /// поиск и фильтрация
        /// </summary>
        public void Filter()
        {
            List<Subscriber> listFilter = DataBase.Base.Subscriber.ToList();

            //поиск
            if (!string.IsNullOrWhiteSpace(tbSurname.Text))
            {
                listFilter = listFilter.Where(z => z.SubscriberSurname.ToLower().Contains(tbSurname.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(tbPersonalAccount.Text))
            {
                listFilter = listFilter.Where(z => z.Treaty.TreatyPersonalAccount.ToString().ToLower().Contains(tbPersonalAccount.Text.ToLower())).ToList();
            }
            //фильтрация по району
            if (cbRaion.SelectedIndex > 0)
            {
                listFilter = listFilter.Where(z => z.Address.DistrictsAddress.DistrictsName == (string)cbRaion.SelectedValue).ToList();
            }
            //фильтрация по улицам
            if (cbStreet.SelectedIndex > 0)
            {
                listFilter = listFilter.Where(z => z.Address.Street1.StreetName + ", " + z.Address.Home == cbStreet.SelectedValue.ToString()).ToList();
            }
            //активные или неактивные
            if (cbActive.IsChecked == true && cbNoActive.IsChecked == false)
            {
                listFilter = listFilter.Where(z => z.Treaty.TreatyTerminationDate == null).ToList();
            }

            if (cbActive.IsChecked == false && cbNoActive.IsChecked == true)
            {
                listFilter = listFilter.Where(z => z.Treaty.TreatyTerminationDate != null).ToList();
            }
            dgSubscriber.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
        }
        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbRaion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void cbStreet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void dgSubscriber_MouseDoubleClick(object sender, MouseButtonEventArgs e) //При двойном клике открывается страница с подробным описанием абонента
        {
            Subscriber subscribers = new Subscriber();
            foreach (Subscriber subscriberss in dgSubscriber.SelectedItems)
            {
                subscribers = subscriberss;
            }

            if (subscribers != null)
            {
                ClassFrame.Mframe.Navigate(new SubscribersInfo(subscribers));
            }
            else
            {
                return;
            }
        }

        private void cbActive_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void tbPersonalAccount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }
    }
}
