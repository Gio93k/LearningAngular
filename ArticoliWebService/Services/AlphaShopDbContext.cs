using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;
namespace ArticoliWebService.Services
{
    public class AlphaShopDbContext : DbContext
    {
        /*permette la mappatura delle nostre classi di modello con le relative tabelle del nostro dbms
        e gestisce la connessione con il dbms*/
        public AlphaShopDbContext(DbContextOptions<AlphaShopDbContext> options) : base(options)
        {

        }

        //non si usa l'entity framework
        public virtual DbSet<Articoli> Articoli { get; set} //alla classe articoli corrisponde la tabella articoli
        public virtual DbSet<Ean> Barcode { get; set} //alla classe Ean corrisponde la taella Barcode
        public virtual DbSet<FamAssort> Famassort { get; set} //alla classe FamAssort corrisponde la taella famassort
        public virtual DbSet<Ingredienti> Ingredienti { get; set} //alla classe Ingredienti corrisponde la taella ingredienti
        public virtual DbSet<Iva> Iva { get; set; } //alla classe Iva corrisponde la taella Iva


        /*Questo metodo ha lo scopo è quello di configurare tutti gil elementi delle nostri classi modello */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuro la chiave primaria della tabella articoli
            modelBuilder.Entity<Articoli>()
            .HasKey(a => new { a.CodArt });

            //configuro la relazione uno al molti fra articolo e Barcode
            modelBuilder.Entity<Ean>()
            .HasOne<Articoli>(s => s.articolo) //ad un articolo...
            .WithMany(g => g.barcode) //corrispondono molti barcode
            .HasForeignKey(s => s.CodArt); //chiave estera dell'entity barcode su articoli 

            //configuro la relazione uno a uno fra articolo e Ingredienti
            modelBuilder.Entity<Articoli>()
            .HasOne<Ingredienti>(g => g.ingredienti)
            .WithOne(a => a.articolo)
            .HasForeignKey<Ingredienti>(k => k.CodArt);

            //configuro la relazione molti a uno fra articoli e iva
            modelBuilder.Entity<Iva>()
           .HasMany<Articoli>(a => a.articoli)
           .WithOne(i => i.iva)
           .HasForeignKey(k => k.IdIva);

            //configuro la relazione uno a uno fra famassort e Articoli

            modelBuilder.Entity<FamAssort>()
            .HasMany<Articoli>(a => a.articoli)
            .WithOne(f => f.famAssort)
            .HasForeignKey(k => k.IdFamAss);
        }
    }