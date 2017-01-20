﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webapi.core.entityframework.DBProviders;

namespace webapi.core.entityframework.Migrations
{
    [DbContext(typeof(DBBusinessContext))]
    partial class DBBusinessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("webapi.core.welcome.Models.Business", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Timestamp");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("Id");

                    b.ToTable("Business");
                });
        }
    }
}