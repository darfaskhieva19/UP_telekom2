
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
    
public partial class ReasonForTermination
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ReasonForTermination()
    {

        this.Treaty = new HashSet<Treaty>();

    }


    public int IDReasonForTermination { get; set; }

    public string ReasonForTermination1 { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Treaty> Treaty { get; set; }

}

}
