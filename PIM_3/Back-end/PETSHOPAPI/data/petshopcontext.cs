using Microsoft.EntityFrameworkCore;
using PETSHOPAPI.models;
using PETSHOPAPI.Models;

namespace PETSHOPAPI.data
{
    public class PetshopContext : DbContext
    {
        public PetshopContext(
            DbContextOptions<PetshopContext> options
        )
            : base(options)
        {
        }

        // =========================
        // TABELAS
        // =========================

        public DbSet<Agendamento> Agendamentos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}