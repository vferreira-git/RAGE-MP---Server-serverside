﻿// <auto-generated />
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DALContext))]
    [Migration("20190929024909_fourth")]
    partial class fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DAL.EF.TableClasses.Character", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<string>("AccountSerial");

                    b.Property<uint>("Dimension");

                    b.Property<float>("LastX");

                    b.Property<float>("LastY");

                    b.Property<float>("LastZ");

                    b.Property<float>("Rotation");

                    b.Property<string>("Skin");

                    b.HasKey("Name");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DAL.TableClasses.Account", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<bool>("remember");

                    b.Property<string>("serial");

                    b.HasKey("Username");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DAL.TableClasses.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("EnterX");

                    b.Property<float>("EnterY");

                    b.Property<float>("EnterZ");

                    b.Property<float>("ExitX");

                    b.Property<float>("ExitY");

                    b.Property<float>("ExitZ");

                    b.Property<string>("IPL");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
