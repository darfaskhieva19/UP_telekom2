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

namespace ТелекомНеваСвязь
{
    /// <summary>
    /// Логика взаимодействия для WindowNewCRM.xaml
    /// </summary>
    public partial class WindowNewCRM : Window
    {
        public WindowNewCRM(Subscriber subscriber)
        {
            InitializeComponent();
            tbNumber.Text = "Номер заявки: " + subscriber.Treaty.TreatyPersonalAccount + "/" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            dpDate.SelectedDate = DateTime.Now; //дата составления заявки
            tbNumberClient.Text = subscriber.IDSubscriber; //номер абонента
            tbNumberPerAcc.Text = subscriber.Treaty.TreatyPersonalAccount.ToString(); //лицевой счет
            cbService.Items.Add("Выберите услугу"); //услуга
            List<ServiceTreaty> serviceTreaties = DataBase.Base.ServiceTreaty.Where(z => z.TreatyID == subscriber.Treaty.TreatyNumber).ToList();
            foreach(ServiceTreaty serviceTreaty in serviceTreaties)
            {
                cbService.Items.Add(serviceTreaty.Service.ServiceName);
            }
            cbService.SelectedIndex = 0;
            cbTypeOfService.Items.Add("Выберите вид услуги"); //вид услуги
            List<ViewService> viewServices = DataBase.Base.ViewService.ToList();
            foreach(ViewService viewS in viewServices)
            {
                cbTypeOfService.Items.Add(viewS.ViewName);
            }
            cbTypeOfService.SelectedIndex = 0;
            List<Status> statuses = DataBase.Base.Status.ToList(); //статус заявки
            foreach(Status status in statuses)
            {
                cbStatus.Items.Add(status.Status1);
            }
            cbStatus.SelectedIndex = 0;
            tbTypeEq.Text = subscriber.Equipments.EquipmentName; //оборудование
            cbServiceType.Items.Add("Выберите тип услуги"); //тип услуги
            List<TypeService> typeServices = DataBase.Base.TypeService.ToList();
            foreach(TypeService typeService in typeServices)
            {
                cbServiceType.Items.Add(typeService.TypeService1);
            }
            cbServiceType.SelectedIndex = 0;
            cbTypeProblem.Items.Add("Выберите тип проблемы"); //тип проблемы
            List<TypeOfProblem> problems = DataBase.Base.TypeOfProblem.ToList();
            foreach(TypeOfProblem problem in problems)
            {
                cbTypeProblem.Items.Add(problem.TypeOfProblem1);
            }
            cbTypeProblem.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) //сохранение
        {
            try
            {
                if (cbService.SelectedIndex != 0 && cbServiceType.SelectedIndex != 0 && cbTypeProblem.SelectedIndex != 0 && cbTypeOfService.SelectedIndex != 0 && cbStatus.SelectedIndex != 0)
                {
                    CRM crm = new CRM()
                    {
                        ApplicationNumber = tbNumber.Text,
                        ApplicationDate = (DateTime)dpDate.SelectedDate,
                        PersonalAccount = Convert.ToInt32(tbNumberPerAcc.Text),
                        Service = cbService.SelectedIndex,
                        ServiceType = cbServiceType.SelectedIndex,
                        ApplicationView = cbTypeOfService.SelectedIndex,
                        ServiceStatus = cbStatus.SelectedIndex + 1,
                        TypeEquipment = tbTypeEq.Text,
                        Problem = tbDescription.Text,
                        DateClosing = dpDateClosing.SelectedDate,
                        TypeProblem = cbTypeProblem.SelectedIndex
                    };
                    DataBase.Base.CRM.Add(crm);
                    DataBase.Base.SaveChanges();
                    MessageBox.Show("Успешное создание заявки!");
                }
                else
                {
                    MessageBox.Show("Заполните все обязательные поля!");
                }
            }
            catch
            {
                MessageBox.Show("При сохранении возникла ошибка", "Системное сообщение");
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e) //проверка оборудования
        {
            Random rnd = new Random();
            int k = rnd.Next(2);
            if (k == 0)
            {
                MessageBox.Show("Оборудование исправно!");
                cbStatus.SelectedItem = "Закрыта";
                dpDateClosing.SelectedDate = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Оборудование неисправно!");
                cbStatus.SelectedItem = "Требует выезда";
            }
        }

        private void cbTypeOfService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbTypeOfService.Items.Clear();
            if(cbTypeOfService.SelectedIndex == 0)
            {
                cbTypeOfService.Items.Add("Сначала выберите тип услуги!");
                cbTypeOfService.SelectedIndex = 0;
            }
            else
            {
                cbTypeOfService.Items.Add("Выберите тип услуги");
                List<TypeService> typeServices = DataBase.Base.TypeService.Where(z => z.IDTypeService == cbTypeOfService.SelectedIndex).ToList();
                foreach(TypeService typeService in typeServices)
                {
                    cbTypeOfService.Items.Add(typeService.TypeService1);
                }
                cbTypeOfService.SelectedIndex = 0;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
