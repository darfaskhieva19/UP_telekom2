//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ТелекомНеваСвязь
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRM
    {
        public string ApplicationNumber { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public int PersonalAccount { get; set; }
        public int Service { get; set; }
        public int ServiceType { get; set; }
        public int ApplicationView { get; set; }
        public int ServiceStatus { get; set; }
        public string TypeEquipment { get; set; }
        public string Problem { get; set; }
        public Nullable<System.DateTime> DateClosing { get; set; }
        public int TypeProblem { get; set; }
    
        public virtual Service Service1 { get; set; }
        public virtual Status Status { get; set; }
        public virtual TypeOfProblem TypeOfProblem { get; set; }
        public virtual TypeService TypeService { get; set; }
        public virtual ViewService ViewService { get; set; }
    }
}
