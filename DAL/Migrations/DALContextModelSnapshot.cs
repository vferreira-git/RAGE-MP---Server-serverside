﻿// <auto-generated />
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DALContext))]
    partial class DALContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Banco");

                    b.Property<bool>("CartaLigeiros");

                    b.Property<bool>("CartaMota");

                    b.Property<bool>("CartaPesados");

                    b.Property<uint>("Dimension");

                    b.Property<int>("Dinheiro");

                    b.Property<int>("Faction");

                    b.Property<int>("Health");

                    b.Property<float>("Hunger");

                    b.Property<string>("Inventory");

                    b.Property<float>("LastX");

                    b.Property<float>("LastY");

                    b.Property<float>("LastZ");

                    b.Property<float>("Rotation");

                    b.Property<string>("Skin");

                    b.Property<float>("Thirst");

                    b.HasKey("Name");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DAL.EF.TableClasses.DroppedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("Dimension");

                    b.Property<string>("Item");

                    b.Property<float>("PosX");

                    b.Property<float>("PosY");

                    b.Property<float>("PosZ");

                    b.HasKey("Id");

                    b.ToTable("DroppedItems");
                });

            modelBuilder.Entity("DAL.EF.TableClasses.Faction", b =>
                {
                    b.Property<string>("Faction_Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Faction_Banco");

                    b.Property<string>("Faction_Owner");

                    b.Property<string>("Faction_Rank1");

                    b.Property<string>("Faction_Rank2");

                    b.Property<string>("Faction_Rank3");

                    b.Property<string>("Faction_Rank4");

                    b.Property<string>("Faction_Rank5");

                    b.Property<string>("Faction_Rank6");

                    b.Property<string>("Faction_Rank7");

                    b.Property<int>("Faction_Salary_1");

                    b.Property<int>("Faction_Salary_2");

                    b.Property<int>("Faction_Salary_3");

                    b.Property<int>("Faction_Salary_4");

                    b.Property<int>("Faction_Salary_5");

                    b.Property<int>("Faction_Salary_6");

                    b.Property<int>("Faction_Salary_7");

                    b.Property<int>("Faction_Type");

                    b.HasKey("Faction_Name");

                    b.ToTable("Factions");
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