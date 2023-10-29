﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SavioApi.Data;

#nullable disable

namespace SavioApi.Migrations
{
    [DbContext(typeof(SavioDbContext))]
    [Migration("20231029062457_renamed models from users to users and account to UserAccounts ")]
    partial class renamedmodelsfromuserstousersandaccounttoUserAccounts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("SavioApi.Models.Data.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountUserId")
                        .HasColumnType("TEXT");

                    b.Property<double>("TransactionAmount")
                        .HasColumnType("REAL");

                    b.Property<Guid>("TransactionReceiver")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TransactionSender")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TransactionUpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionId");

                    b.HasIndex("AccountUserId", "AccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SavioApi.Models.Data.UserAccount", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<double>("AccountBalance")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("AccountCreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AccountUpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("BankName")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "AccountNumber");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SavioApi.Models.Data.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BVN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserAccountAccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserAccountUserId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("UserAccountUserId", "UserAccountAccountNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SavioApi.Models.Data.Transaction", b =>
                {
                    b.HasOne("SavioApi.Models.Data.UserAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountUserId", "AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SavioApi.Models.Data.UserAccount", b =>
                {
                    b.HasOne("SavioApi.Models.Data.Users", "AccountUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountUser");
                });

            modelBuilder.Entity("SavioApi.Models.Data.Users", b =>
                {
                    b.HasOne("SavioApi.Models.Data.UserAccount", null)
                        .WithMany("AccountBeneficiaries")
                        .HasForeignKey("UserAccountUserId", "UserAccountAccountNumber");
                });

            modelBuilder.Entity("SavioApi.Models.Data.UserAccount", b =>
                {
                    b.Navigation("AccountBeneficiaries");
                });
#pragma warning restore 612, 618
        }
    }
}
