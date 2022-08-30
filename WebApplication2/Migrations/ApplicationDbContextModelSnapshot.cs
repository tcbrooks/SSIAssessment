﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication2.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssignmentPlanParticipationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BenefitsAssignmentCertificationIndicator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimFrequencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityCodeQualifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilityTypeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderSupplierSignatureIndicator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseOfInformationIndicator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalClaimChargeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Claim");
                });
#pragma warning restore 612, 618
        }
    }
}