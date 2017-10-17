using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MojContext : DbContext
    {
        public MojContext() : base("DziennikElektronicznyBazaConection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MojContext>());
        }

        public virtual DbSet<Uczen> Uczniowie { get; set; }
        public virtual DbSet<Przedmiot> Przedmioty{ get; set; }
        public virtual DbSet<Adres> Adresy { get; set; }
        public virtual DbSet<Klasa> Klasy { get; set; }
        public virtual DbSet<UczenPrzedmiotOcena> OcenyUczniow{ get; set; }
        public virtual DbSet<Szkola> ListaSzkol { get; set; }
        public virtual DbSet<Dyrektor> Dyrektorzy { get; set; }
        public virtual DbSet<Logowanie> Logowania { get; set; }
        public virtual DbSet<Nauczyciel> Nauczyciele { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         // base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        //  public virtual DbSet
    }
}
