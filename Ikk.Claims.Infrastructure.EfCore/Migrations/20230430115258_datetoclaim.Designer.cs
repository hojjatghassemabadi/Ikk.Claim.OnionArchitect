﻿// <auto-generated />
using System;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ikk.Claims.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(ClaemContext))]
    [Migration("20230430115258_datetoclaim")]
    partial class datetoclaim
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("clm")
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Batchs.Batch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CarInBatchId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Batchs", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.CarInBaches.CarInBatch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BatchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PartId")
                        .HasColumnType("bigint");

                    b.Property<long>("TypeCarId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("PartId");

                    b.HasIndex("TypeCarId");

                    b.ToTable("carInBatches", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.CKDQRs.CKDQR", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Attachment")
                        .HasColumnType("int");

                    b.Property<string>("CountainerNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("OverSeasFactory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OverSeasePlantAction")
                        .HasColumnType("int");

                    b.Property<int>("PackingStatus")
                        .HasColumnType("int");

                    b.Property<int>("Problemtype")
                        .HasColumnType("int");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("ReportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Responsibility")
                        .HasColumnType("int");

                    b.Property<int>("URgencyClassification")
                        .HasColumnType("int");

                    b.Property<int>("Warranty")
                        .HasColumnType("int");

                    b.Property<string>("caseNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CKDQRs", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.CKDQRs.CKDQRPic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CkdqrId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CkdqrId");

                    b.ToTable("CKDQRPics", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claems.Claem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BatchId")
                        .HasColumnType("bigint");

                    b.Property<string>("ClaemNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountPart")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("Claems", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claems.ClaemInCkdqr", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CkdqrId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClaemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CkdqrId");

                    b.HasIndex("ClaemId");

                    b.ToTable("claemInCkdqrs", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claims.ClaemPic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ClaemId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("PicAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClaemId");

                    b.ToTable("ClaemPics", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Parts.ClaimInPart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ClaemId")
                        .HasColumnType("bigint");

                    b.Property<long>("PartId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClaemId");

                    b.HasIndex("PartId");

                    b.ToTable("ClaimInPart", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Parts.Part", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Parts", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.TypeCars.TypeCar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TypeCars", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Users.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRemoved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Famil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RemovedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Entities.Users.UserInRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRoles", "clm");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.CarInBaches.CarInBatch", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.Batchs.Batch", "Batch")
                        .WithMany("CarInBatchs")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ikk.Claims.Domain.Enities.Parts.Part", null)
                        .WithMany("CarInBatches")
                        .HasForeignKey("PartId");

                    b.HasOne("Ikk.Claims.Domain.Enities.TypeCars.TypeCar", "Typecar")
                        .WithMany("CarInBatches")
                        .HasForeignKey("TypeCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Typecar");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.CKDQRs.CKDQRPic", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.CKDQRs.CKDQR", "CKDQR")
                        .WithMany("Pics")
                        .HasForeignKey("CkdqrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CKDQR");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claems.Claem", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.Batchs.Batch", "Batch")
                        .WithMany("Claims")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claems.ClaemInCkdqr", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.CKDQRs.CKDQR", "CKDQR")
                        .WithMany("claemInCkdqrs")
                        .HasForeignKey("CkdqrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ikk.Claims.Domain.Enities.Claems.Claem", "Claem")
                        .WithMany("claemInCkdqrs")
                        .HasForeignKey("ClaemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CKDQR");

                    b.Navigation("Claem");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claims.ClaemPic", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.Claems.Claem", "Claem")
                        .WithMany("Pics")
                        .HasForeignKey("ClaemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Claem");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Parts.ClaimInPart", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.Claems.Claem", "claem")
                        .WithMany("ClaemInParts")
                        .HasForeignKey("ClaemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ikk.Claims.Domain.Enities.Parts.Part", "Part")
                        .WithMany("ClaemInParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("claem");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Entities.Users.UserInRole", b =>
                {
                    b.HasOne("Ikk.Claims.Domain.Enities.Users.Role", "Role")
                        .WithMany("UserInRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ikk.Claims.Domain.Enities.Users.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Batchs.Batch", b =>
                {
                    b.Navigation("CarInBatchs");

                    b.Navigation("Claims");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.CKDQRs.CKDQR", b =>
                {
                    b.Navigation("Pics");

                    b.Navigation("claemInCkdqrs");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Claems.Claem", b =>
                {
                    b.Navigation("ClaemInParts");

                    b.Navigation("Pics");

                    b.Navigation("claemInCkdqrs");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Parts.Part", b =>
                {
                    b.Navigation("CarInBatches");

                    b.Navigation("ClaemInParts");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.TypeCars.TypeCar", b =>
                {
                    b.Navigation("CarInBatches");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Users.Role", b =>
                {
                    b.Navigation("UserInRoles");
                });

            modelBuilder.Entity("Ikk.Claims.Domain.Enities.Users.User", b =>
                {
                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
