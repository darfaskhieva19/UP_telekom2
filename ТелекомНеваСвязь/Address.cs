
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
    
public partial class Address
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Address()
    {

        this.Subscriber = new HashSet<Subscriber>();

    }


    public int IDAddress { get; set; }

    public int Country { get; set; }

    public int City { get; set; }

    public int Street { get; set; }

    public Nullable<int> Home { get; set; }

    public string Apartment { get; set; }

    public Nullable<int> Districts { get; set; }



    public virtual City City1 { get; set; }

    public virtual Country Country1 { get; set; }

    public virtual DistrictsAddress DistrictsAddress { get; set; }

    public virtual Street Street1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Subscriber> Subscriber { get; set; }

}

}
