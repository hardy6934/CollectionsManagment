﻿// <auto-generated />
using System;
using CollectionsManagment.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollectionsManagment.DataBase.Migrations
{
    [DbContext(typeof(CollectionsManagmentContext))]
    partial class CollectionsManagmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("FirstBigStringField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstBigStringFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FirstBoolField")
                        .HasColumnType("bit");

                    b.Property<string>("FirstBoolFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FirstDatetimeField")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstDatetimeFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FirstNumericField")
                        .HasColumnType("int");

                    b.Property<string>("FirstNumericFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstStringField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstStringFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondBigStringField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondBigStringFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SecondBoolField")
                        .HasColumnType("bit");

                    b.Property<string>("SecondBoolFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SecondDatetimeField")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecondDatetimeFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SecondNumericField")
                        .HasColumnType("int");

                    b.Property<string>("SecondNumericFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondStringField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondStringFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdBigStringField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdBigStringFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ThirdDatetimeField")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThirdDatetimeFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThirdNumericField")
                        .HasColumnType("int");

                    b.Property<string>("ThirdNumericFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdStringField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdStringFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ThirdtBoolField")
                        .HasColumnType("bit");

                    b.Property<string>("ThirdtBoolFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Collection", b =>
                {
                    b.HasOne("CollectionsManagment.DataBase.Entities.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Comment", b =>
                {
                    b.HasOne("CollectionsManagment.DataBase.Entities.Item", "Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectionsManagment.DataBase.Entities.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Item", b =>
                {
                    b.HasOne("CollectionsManagment.DataBase.Entities.Collection", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Like", b =>
                {
                    b.HasOne("CollectionsManagment.DataBase.Entities.Item", "Item")
                        .WithMany("Likes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectionsManagment.DataBase.Entities.User", null)
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Tag", b =>
                {
                    b.HasOne("CollectionsManagment.DataBase.Entities.Item", "Item")
                        .WithMany("Tags")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.User", b =>
                {
                    b.HasOne("CollectionsManagment.DataBase.Entities.Account", "Account")
                        .WithOne("Users")
                        .HasForeignKey("CollectionsManagment.DataBase.Entities.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectionsManagment.DataBase.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Account", b =>
                {
                    b.Navigation("Users")
                        .IsRequired();
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Collection", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Item", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CollectionsManagment.DataBase.Entities.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
