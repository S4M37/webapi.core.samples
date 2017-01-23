using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Migrations
{
    [DbContext(typeof(DbWebApiContext))]
    [Migration("20170123120652_fix_timefield")]
    partial class fix_timefield
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

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("webapi.core.entityframework.DbModels.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("webapi.core.entityframework.DbModels.Business", b =>
                {
                    b.HasOne("webapi.core.entityframework.DbModels.Category")
                        .WithMany("Businesses")
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
