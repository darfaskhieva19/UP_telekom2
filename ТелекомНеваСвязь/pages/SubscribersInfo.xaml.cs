using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для SubscribersInfo.xaml
    /// </summary>
    public partial class SubscribersInfo : Page
    {
        public SubscribersInfo(Subscriber subscribers)
        {
            InitializeComponent();
            tbNumber.Text = "Номер абонента: " + subscribers.IDSubscriber;
            tbFIO.Text = subscribers.SubscriberSurname + " " + subscribers.SubscriberName + " " + subscribers.SubscriberPatronymic;
            tbSeria.Text = "Серия: " + subscribers.PassportData.Series; //Формирование паспортных данных
            tbNomer.Text = "Номер: " + subscribers.PassportData.Number;
            tbDateOfIssue.Text = "Дата выдачи: " + subscribers.PassportData.PassportDateIssued;
            tbIssuedBy.Text = "Выдан: " + subscribers.PassportData.PassportIssued;
            tbTreatyNumber.Text = "Номер: " + subscribers.Treaty.TreatyNumber; //Формирование данных договора
            tbDateOfCinclusion.Text = "Дата заключения: " + subscribers.Treaty.TreatyDateСonclusion;
            tbTypeTreaty.Text = "Тип договора: " + subscribers.Treaty.TypeTreaty;
            if (subscribers.Treaty.TreatyTerminationDate != null)
            {
                tbTermibationDate.Text = "Дата расторжения: " + subscribers.Treaty.TreatyTerminationDate;
                tbReasonForTermination.Text = "Причина расторжения: " + subscribers.Treaty.ReasonForTermination;
            }
            else
            {
                tbTermibationDate.Text = "";
                tbTermibationDate.Visibility = Visibility.Collapsed;
                tbReasonForTermination.Text = "";
                tbReasonForTermination.Visibility = Visibility.Collapsed;
            }
            //tbPersonalAccount.Text = "Лицевой счет: " + subscribers.Treaty.TreatyPersonalAccount;
            //if (subscribers.Address.Street1.StreetName != null) //данные адреса
            //{
            //    if (subscribers.Address.Home != null)
            //    {
            //        if (subscribers.Address.Apartment != null)
            //        {
            //            tbAddress.Text = subscribers.Address.DistrictsAddress.DistrictsName + ", " + subscribers.Address.Street1.StreetName + ", " + subscribers.Address.Home + ", " + subscribers.Address.Apartment;
            //        }
            //        else
            //        {
            //            tbAddress.Text = subscribers.Address.DistrictsAddress.DistrictsName + ", " + subscribers.Address.Street1.StreetName + ", " + subscribers.Address.Home;
            //        }
            //    }
            //    else
            //    {
            //        tbAddress.Text = subscribers.Address.DistrictsAddress.DistrictsName + ", " + subscribers.Address.Street1.StreetName;
            //    }
            //}
            //else
            //{
            //    tbAddress.Text = subscribers.Address.DistrictsAddress.DistrictsName;
            //}
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Mframe.Navigate(new PageSubscriber());
        }
    }
}
