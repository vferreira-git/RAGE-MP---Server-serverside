﻿// <auto-generated />
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DALContext))]
    [Migration("20191011115617_Nova")]
    partial class Nova
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

                    b.Property<int>("Dinheiro");

                    b.Property<string>("Inventory");

                    b.Property<float>("LastX");

                    b.Property<float>("LastY");

                    b.Property<float>("LastZ");

                    b.Property<float>("Rotation");

                    b.Property<string>("Skin");

                    b.HasKey("Name");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DAL.EF.TableClasses.DroppedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<uint>("Dimension");

                    b.Property<string>("Item");

                    b.Property<string>("Name");

                    b.Property<float>("PosX");

                    b.Property<float>("PosY");

                    b.Property<float>("PosZ");

                    b.HasKey("Id");

                    b.ToTable("DroppedItems");
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

                    b.Property<uint>("EnterDimension");

                    b.Property<int>("EnterInterior");

                    b.Property<float>("EnterX");

                    b.Property<float>("EnterY");

                    b.Property<float>("EnterZ");

                    b.Property<int>("ExitInterior");

                    b.Property<float>("ExitX");

                    b.Property<float>("ExitY");

                    b.Property<float>("ExitZ");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
