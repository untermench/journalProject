//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace journalProject.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Класс
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Класс()
        {
            this.Доступ = new HashSet<Доступ>();
            this.Занятие = new HashSet<Занятие>();
            this.Ученик = new HashSet<Ученик>();
        }
    
        public int ID { get; set; }
        public int Номер { get; set; }
        public string Префикс { get; set; }
        public Nullable<int> Класс_рукID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Доступ> Доступ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Занятие> Занятие { get; set; }
        public virtual Пользователь Пользователь { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ученик> Ученик { get; set; }
    }
}
