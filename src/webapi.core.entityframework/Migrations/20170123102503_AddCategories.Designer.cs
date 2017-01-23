using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Migrations
{
    [DbContext(typeof(DbWebApiContext))]
    [Migration("20170123102503_AddCategories")]
    partial class AddCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("webapi.core.entityframework.DbModels.Business", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.HasKey("Id");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("webapi.core.entityframework.DbModels.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("webapi.core.entityframework.DbModels.Category", b =>
                {
                    b.HasOne("webapi.core.entityframework.DbModels.Business")
                        .WithMany("Categories")
                        .HasForeignKey("BusinessId");
                });
        }
    }
}
