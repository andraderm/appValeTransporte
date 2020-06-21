﻿// <auto-generated />
using System;
using API_VT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_VT.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_VT.Models.DespesaFuncionario", b =>
                {
                    b.Property<int>("DespesaId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<double>("CustoIndividual")
                        .HasColumnType("float");

                    b.Property<int>("DiasTrabalhados")
                        .HasColumnType("int");

                    b.HasKey("DespesaId", "FuncionarioId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("DespesasFuncionarios");
                });

            modelBuilder.Entity("API_VT.Models.Entities.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("API_VT.Models.Entities.Escala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EscalaTrabalho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Escalas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EscalaTrabalho = "5x2"
                        },
                        new
                        {
                            Id = 2,
                            EscalaTrabalho = "6x1"
                        },
                        new
                        {
                            Id = 3,
                            EscalaTrabalho = "6x2"
                        },
                        new
                        {
                            Id = 4,
                            EscalaTrabalho = "12x36"
                        });
                });

            modelBuilder.Entity("API_VT.Models.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CustoDiarioVT")
                        .HasColumnType("float");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EscalaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("EscalaId");

                    b.HasIndex("SetorId");

                    b.ToTable("Funcionarios");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CustoDiarioVT = 12.1,
                            DataAdmissao = new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 3,
                            Nome = "Fábio",
                            SetorId = 1,
                            Sobrenome = "Torres"
                        },
                        new
                        {
                            Id = 1,
                            CustoDiarioVT = 15.6,
                            DataAdmissao = new DateTime(2017, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 1,
                            Nome = "João",
                            SetorId = 2,
                            Sobrenome = "Paulo"
                        },
                        new
                        {
                            Id = 2,
                            CustoDiarioVT = 9.4000000000000004,
                            DataAdmissao = new DateTime(2017, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 1,
                            Nome = "Antônio",
                            SetorId = 6,
                            Sobrenome = "Figueiredo"
                        },
                        new
                        {
                            Id = 3,
                            CustoDiarioVT = 11.199999999999999,
                            DataAdmissao = new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 2,
                            Nome = "Mariana",
                            SetorId = 5,
                            Sobrenome = "Silva"
                        },
                        new
                        {
                            Id = 4,
                            CustoDiarioVT = 10.4,
                            DataAdmissao = new DateTime(2016, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 3,
                            Nome = "Maria",
                            SetorId = 8,
                            Sobrenome = "José"
                        },
                        new
                        {
                            Id = 6,
                            CustoDiarioVT = 16.0,
                            DataAdmissao = new DateTime(2017, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 4,
                            Nome = "Marcos",
                            SetorId = 4,
                            Sobrenome = "Oliveira"
                        },
                        new
                        {
                            Id = 7,
                            CustoDiarioVT = 12.9,
                            DataAdmissao = new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 2,
                            Nome = "Ana",
                            SetorId = 3,
                            Sobrenome = "Paula"
                        },
                        new
                        {
                            Id = 8,
                            CustoDiarioVT = 7.5999999999999996,
                            DataAdmissao = new DateTime(2018, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 3,
                            Nome = "Fabiana",
                            SetorId = 1,
                            Sobrenome = "Alves"
                        },
                        new
                        {
                            Id = 9,
                            CustoDiarioVT = 14.5,
                            DataAdmissao = new DateTime(2017, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 1,
                            Nome = "José",
                            SetorId = 2,
                            Sobrenome = "Augusto"
                        },
                        new
                        {
                            Id = 10,
                            CustoDiarioVT = 13.300000000000001,
                            DataAdmissao = new DateTime(2018, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 4,
                            Nome = "Bruna",
                            SetorId = 7,
                            Sobrenome = "Ferraz"
                        },
                        new
                        {
                            Id = 11,
                            CustoDiarioVT = 7.9000000000000004,
                            DataAdmissao = new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 3,
                            Nome = "Laura",
                            SetorId = 8,
                            Sobrenome = "Viana"
                        },
                        new
                        {
                            Id = 12,
                            CustoDiarioVT = 11.6,
                            DataAdmissao = new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 2,
                            Nome = "Vinícius",
                            SetorId = 2,
                            Sobrenome = "André"
                        },
                        new
                        {
                            Id = 13,
                            CustoDiarioVT = 10.1,
                            DataAdmissao = new DateTime(2018, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 2,
                            Nome = "Guilherme",
                            SetorId = 4,
                            Sobrenome = "Barros"
                        },
                        new
                        {
                            Id = 14,
                            CustoDiarioVT = 9.5999999999999996,
                            DataAdmissao = new DateTime(2017, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EscalaId = 3,
                            Nome = "Regina",
                            SetorId = 5,
                            Sobrenome = "Pires"
                        });
                });

            modelBuilder.Entity("API_VT.Models.Entities.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Vendas"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Manutenção"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Limpeza"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Segurança"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Recursos Humanos"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Administração"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Brigada de Incêndio"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Recepção"
                        });
                });

            modelBuilder.Entity("API_VT.Models.DespesaFuncionario", b =>
                {
                    b.HasOne("API_VT.Models.Entities.Despesa", "Despesa")
                        .WithMany("DespesasFuncionarios")
                        .HasForeignKey("DespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_VT.Models.Entities.Funcionario", "Funcionario")
                        .WithMany("DespesasFuncionarios")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_VT.Models.Entities.Funcionario", b =>
                {
                    b.HasOne("API_VT.Models.Entities.Escala", "Escala")
                        .WithMany()
                        .HasForeignKey("EscalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_VT.Models.Entities.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
