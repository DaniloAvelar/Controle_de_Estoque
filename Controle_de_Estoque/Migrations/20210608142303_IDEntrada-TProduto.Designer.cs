﻿// <auto-generated />
using System;
using Controle_de_Estoque.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Controle_de_Estoque.Migrations
{
    [DbContext(typeof(ControleDeEstoqueDbContext))]
    [Migration("20210608142303_IDEntrada-TProduto")]
    partial class IDEntradaTProduto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Controle_de_Estoque.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeCategoria")
                        .HasColumnType("longtext");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Entrada", b =>
                {
                    b.Property<int>("EntradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("motivoEntrada")
                        .HasColumnType("longtext");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("EntradaId");

                    b.HasIndex("IdProduto");

                    b.HasIndex("usuarioId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Caixa")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EntradaId")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QtdeProduto")
                        .HasColumnType("int");

                    b.HasKey("IdProduto");

                    b.HasIndex("EntradaId")
                        .IsUnique();

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Saida", b =>
                {
                    b.Property<int>("SaidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dataSaida")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("motivoSaida")
                        .HasColumnType("longtext");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("SaidaId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Saidas");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext");

                    b.Property<string>("usuarioEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("usuarioNome")
                        .HasColumnType("longtext");

                    b.HasKey("usuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Entrada", b =>
                {
                    b.HasOne("Controle_de_Estoque.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Estoque.Models.Usuario", "Usuario")
                        .WithMany("Entrada")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Produto", b =>
                {
                    b.HasOne("Controle_de_Estoque.Models.Entrada", "Entrada")
                        .WithOne()
                        .HasForeignKey("Controle_de_Estoque.Models.Produto", "EntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Controle_de_Estoque.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Entrada");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Saida", b =>
                {
                    b.HasOne("Controle_de_Estoque.Models.Usuario", "Usuario")
                        .WithMany("Saida")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Controle_de_Estoque.Models.Usuario", b =>
                {
                    b.Navigation("Entrada");

                    b.Navigation("Saida");
                });
#pragma warning restore 612, 618
        }
    }
}
