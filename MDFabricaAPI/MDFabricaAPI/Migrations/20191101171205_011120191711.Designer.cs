﻿// <auto-generated />
using System;
using MDFabricaAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MDFabricaAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191101171205_011120191711")]
    partial class _011120191711
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MDFabricaAPI.Models.Machine", b =>
                {
                    b.Property<long>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MachineTypeId");

                    b.Property<long?>("ProductionLineId");

                    b.HasKey("MachineId");

                    b.HasIndex("MachineTypeId");

                    b.HasIndex("ProductionLineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("MDFabricaAPI.Models.MachineType", b =>
                {
                    b.Property<long>("MachineTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("MachineTypeId");

                    b.ToTable("MachineTypes");
                });

            modelBuilder.Entity("MDFabricaAPI.Models.Operation", b =>
                {
                    b.Property<long>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MachineTypeId");

                    b.Property<int>("OperationTime");

                    b.Property<double>("PreparationTime");

                    b.HasKey("OperationId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("MDFabricaAPI.Models.ProductionLine", b =>
                {
                    b.Property<long>("ProductionLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ProductionLineId");

                    b.ToTable("ProductionLines");
                });

            modelBuilder.Entity("MDFabricaAPI.Models.Machine", b =>
                {
                    b.HasOne("MDFabricaAPI.Models.MachineType", "MachineType")
                        .WithMany("Machines")
                        .HasForeignKey("MachineTypeId");

                    b.HasOne("MDFabricaAPI.Models.ProductionLine", "ProductionLine")
                        .WithMany("Machines")
                        .HasForeignKey("ProductionLineId");

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Brand", "Brand", b1 =>
                        {
                            b1.Property<long>("MachineId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("brand")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Brand")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("MachineId");

                            b1.ToTable("Machines");

                            b1.HasOne("MDFabricaAPI.Models.Machine")
                                .WithOne("Brand")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Brand", "MachineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Capacity", "Capacity", b1 =>
                        {
                            b1.Property<long>("MachineId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("capacity")
                                .ValueGeneratedOnAdd()
                                .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                                .HasColumnName("Capacity")
                                .HasColumnType("decimal(5, 2)")
                                .HasDefaultValue(0m);

                            b1.HasKey("MachineId");

                            b1.ToTable("Machines");

                            b1.HasOne("MDFabricaAPI.Models.Machine")
                                .WithOne("Capacity")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Capacity", "MachineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Identification", "Identification", b1 =>
                        {
                            b1.Property<long>("MachineId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("identification")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Identification")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("MachineId");

                            b1.ToTable("Machines");

                            b1.HasOne("MDFabricaAPI.Models.Machine")
                                .WithOne("Identification")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Identification", "MachineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Localization", "Localization", b1 =>
                        {
                            b1.Property<long>("MachineId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("localization")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Localization")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("MachineId");

                            b1.ToTable("Machines");

                            b1.HasOne("MDFabricaAPI.Models.Machine")
                                .WithOne("Localization")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Localization", "MachineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Model", "Model", b1 =>
                        {
                            b1.Property<long>("MachineId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("model")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Model")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("MachineId");

                            b1.ToTable("Machines");

                            b1.HasOne("MDFabricaAPI.Models.Machine")
                                .WithOne("Model")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Model", "MachineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MDFabricaAPI.Models.MachineType", b =>
                {
                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("MachineTypeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("name")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("MachineTypeName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("MachineTypeId");

                            b1.ToTable("MachineTypes");

                            b1.HasOne("MDFabricaAPI.Models.MachineType")
                                .WithOne("Name")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Name", "MachineTypeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MDFabricaAPI.Models.Operation", b =>
                {
                    b.HasOne("MDFabricaAPI.Models.MachineType", "MachineType")
                        .WithMany("OperationsList")
                        .HasForeignKey("MachineTypeId");

                    b.OwnsOne("MDFabricaAPI.Models.ToolName", "ToolName", b1 =>
                        {
                            b1.Property<long>("OperationId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("toolName")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("ToolName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("OperationId");

                            b1.ToTable("Operations");

                            b1.HasOne("MDFabricaAPI.Models.Operation")
                                .WithOne("ToolName")
                                .HasForeignKey("MDFabricaAPI.Models.ToolName", "OperationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.OperationTool", "OperationTool", b1 =>
                        {
                            b1.Property<long>("OperationId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("operationTool")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("OperationTool")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("OperationId");

                            b1.ToTable("Operations");

                            b1.HasOne("MDFabricaAPI.Models.Operation")
                                .WithOne("OperationTool")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.OperationTool", "OperationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("OperationId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("name")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("OperationName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("OperationId");

                            b1.ToTable("Operations");

                            b1.HasOne("MDFabricaAPI.Models.Operation")
                                .WithOne("Name")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Name", "OperationId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MDFabricaAPI.Models.ProductionLine", b =>
                {
                    b.OwnsOne("MDFabricaAPI.Models.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("ProductionLineId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("name")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("ProdLineName")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("ProductionLineId");

                            b1.ToTable("ProductionLines");

                            b1.HasOne("MDFabricaAPI.Models.ProductionLine")
                                .WithOne("Name")
                                .HasForeignKey("MDFabricaAPI.Models.ValueObjects.Name", "ProductionLineId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
