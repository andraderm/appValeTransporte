using API_VT.Models;
using API_VT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API_VT.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Escala> Escalas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<DespesaFuncionario> DespesasFuncionarios { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Password=dev456852;Persist Security Info=True;User ID=dev2;Initial Catalog=ValeTransporte;Data Source=LAPTOP-0HGKU7B7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DespesaFuncionario>().HasKey(x => new { x.DespesaId, x.FuncionarioId });

            Escala e1 = new Escala(1, "5x2");
            Escala e2 = new Escala(2, "6x1");
            Escala e3 = new Escala(3, "6x2");
            Escala e4 = new Escala(4, "12x36");

            Setor s1 = new Setor(1, "Vendas");
            Setor s2 = new Setor(2, "Manutenção");
            Setor s3 = new Setor(3, "Limpeza");
            Setor s4 = new Setor(4, "Segurança");
            Setor s5 = new Setor(5, "Recursos Humanos");
            Setor s6 = new Setor(6, "Administração");
            Setor s7 = new Setor(7, "Brigada de Incêndio");
            Setor s8 = new Setor(8, "Recepção");


            Funcionario f1 = new Funcionario(1, "João", "Paulo", new DateTime(2017, 08, 03), 15.60, 1, 2);
            Funcionario f2 = new Funcionario(2, "Antônio", "Figueiredo", new DateTime(2017, 05, 28), 9.40, 1, 6);
            Funcionario f3 = new Funcionario(3, "Mariana", "Silva", new DateTime(2019, 01, 09), 11.20, 2, 5);
            Funcionario f4 = new Funcionario(4, "Maria", "José", new DateTime(2016, 04, 17), 10.40, 3, 8);
            Funcionario f5 = new Funcionario(5, "Fábio", "Torres", new DateTime(2018, 02, 20), 12.10, 3, 1);
            Funcionario f6 = new Funcionario(6, "Marcos", "Oliveira", new DateTime(2017, 07, 04), 16.00, 4, 4);
            Funcionario f7 = new Funcionario(7, "Ana", "Paula", new DateTime(2019, 09, 14), 12.90, 2, 3);
            Funcionario f8 = new Funcionario(8, "Fabiana", "Alves", new DateTime(2018, 06, 20), 7.60, 3, 1);
            Funcionario f9 = new Funcionario(9, "José", "Augusto", new DateTime(2017, 07, 07), 14.50, 1, 2);
            Funcionario f10 = new Funcionario(10, "Bruna", "Ferraz", new DateTime(2018, 11, 27), 13.30, 4, 7);
            Funcionario f11 = new Funcionario(11, "Laura", "Viana", new DateTime(2020, 01, 08), 7.90, 3, 8);
            Funcionario f12 = new Funcionario(12, "Vinícius", "André", new DateTime(2018, 01, 15), 11.60, 2, 2);
            Funcionario f13 = new Funcionario(13, "Guilherme", "Barros", new DateTime(2018, 10, 21), 10.10, 2, 4);
            Funcionario f14 = new Funcionario(14, "Regina", "Pires", new DateTime(2017, 05, 07), 9.60, 3, 5);


            modelBuilder.Entity<Escala>().HasData(new List<Escala>() { e1, e2, e3, e4 });
            modelBuilder.Entity<Setor>().HasData(new List<Setor>() { s1, s2, s3, s4, s5, s6, s7, s8 });
            modelBuilder.Entity<Funcionario>().HasData(new List<Funcionario>() { f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14 });

        }

    }
}
