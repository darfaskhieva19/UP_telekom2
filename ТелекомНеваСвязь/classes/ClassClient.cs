using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТелекомНеваСвязь
{
    public partial class Subscriber
    {
        public string FIO
        {
            get
            {
                return SubscriberSurname + " " + SubscriberName + " " + SubscriberPatronymic;
            }
        }
        public string SubscribersService
        {
            get
            {
                List<ServiceTreaty> Service = DataBase.Base.ServiceTreaty.Where(z => z.TreatyID == Treaty.TreatyNumber).ToList();
                string str = "";
                foreach (ServiceTreaty treaty in Service)
                {
                    str += treaty.Service.ServiceName + ", ";
                }
                str = str.Substring(0, str.Length - 2);
                return str;
            }
        }
    }
}
