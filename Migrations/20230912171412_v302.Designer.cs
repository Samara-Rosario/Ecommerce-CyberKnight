﻿// <auto-generated />
using System;
using Ecommerce_CyberKnight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce_CyberKnight.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230912171412_v302")]
    partial class v302
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecoes");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataeHora")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("FormaPagamento")
                        .HasColumnType("double");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("itensDoPedido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("estoque")
                        .HasColumnType("float");

                    b.Property<double>("preco")
                        .HasColumnType("double");

                    b.Property<int>("unidadeMedida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.itemDoPedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("ValorItem")
                        .HasColumnType("double");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("itemDoPedidos");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Clientes", b =>
                {
                    b.HasOne("Ecommerce_CyberKnight.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Pedido", b =>
                {
                    b.HasOne("Ecommerce_CyberKnight.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce_CyberKnight.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.itemDoPedido", b =>
                {
                    b.HasOne("Ecommerce_CyberKnight.Models.Pedido", "Pedido")
                        .WithMany("ItensDoPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce_CyberKnight.Models.Produto", "Produto")
                        .WithMany("ItensDoPedido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Pedido", b =>
                {
                    b.Navigation("ItensDoPedido");
                });

            modelBuilder.Entity("Ecommerce_CyberKnight.Models.Produto", b =>
                {
                    b.Navigation("ItensDoPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
