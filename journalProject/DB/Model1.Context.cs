﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class journalDBEntities : DbContext
    {
        public journalDBEntities()
            : base("name=journalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Доступ> Доступ { get; set; }
        public virtual DbSet<Занятие> Занятие { get; set; }
        public virtual DbSet<Занятие_ученик> Занятие_ученик { get; set; }
        public virtual DbSet<Кабинет> Кабинет { get; set; }
        public virtual DbSet<Класс> Класс { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
        public virtual DbSet<Предмет> Предмет { get; set; }
        public virtual DbSet<Тема> Тема { get; set; }
        public virtual DbSet<Тип_пользователя> Тип_пользователя { get; set; }
        public virtual DbSet<Ученик> Ученик { get; set; }
    }
}
