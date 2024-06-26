﻿// <auto-generated />
using System;
using FintechAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace FintechAPI.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240402113154_migration4")]
    partial class migration4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FintechAPI.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_category");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("dt_created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.Property<bool>("Type")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("type");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TAB_CATEGORY");
                });

            modelBuilder.Entity("FintechAPI.Models.TransactionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_transaction");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BankId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_bank");

                    b.Property<int>("CategoryId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_category");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("dt_created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("description");

                    b.Property<bool>("Type")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("type");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_user");

                    b.Property<double>("Value")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("TAB_TRANSACTION");
                });

            modelBuilder.Entity("FintechAPI.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_user");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("dt_created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("NVARCHAR2(16)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("TAB_USER");
                });

            modelBuilder.Entity("FintechApi.Models.BankModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_bank");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("label");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("TAB_BANK");
                });

            modelBuilder.Entity("FintechAPI.Models.CategoryModel", b =>
                {
                    b.HasOne("FintechAPI.Models.UserModel", "User")
                        .WithMany("CategoryModels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FintechAPI.Models.TransactionModel", b =>
                {
                    b.HasOne("FintechApi.Models.BankModel", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FintechAPI.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FintechAPI.Models.UserModel", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FintechAPI.Models.UserModel", b =>
                {
                    b.Navigation("CategoryModels");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
