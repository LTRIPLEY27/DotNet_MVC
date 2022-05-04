using Microsoft.EntityFrameworkCore;

namespace PizzaAgain.Models
{ /// <summary>
/// MODELO A SEGUIR POR ENTITY FRAMEWORK PARA MAPPEAR LAS ENTIDADES EN LA BASE DE DATOS
/// </summary>
    public class Pizza
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public string ? Description { get; set; }
    }

    // INSERCI�N DE BASE DE DATOS EN MEMORIA

    class PizzaData : DbContext// SESI�N QUE GUARDA INSTANCIAS EN BASE DE DATOS
    {
        public PizzaData(DbContextOptions options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; } 
    }
}