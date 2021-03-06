﻿// <auto-generated />
using System;
using Memo.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Memo.Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190215155333_settersInWord")]
    partial class settersInWord
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Memo.Domain.WordsModel.Word", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("NextIteration");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Memo.Domain.WordsModel.WordStatistic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DifficultyWord");

                    b.Property<int>("NumberTypedCorrect");

                    b.Property<int>("TimesLoaded");

                    b.Property<int>("TimesTypedWrong");

                    b.Property<Guid>("WordId");

                    b.HasKey("Id");

                    b.HasIndex("WordId")
                        .IsUnique();

                    b.ToTable("WordStatistics");
                });

            modelBuilder.Entity("Memo.Domain.WordsModel.WordStatistic", b =>
                {
                    b.HasOne("Memo.Domain.WordsModel.Word", "Word")
                        .WithOne("WordStatistic")
                        .HasForeignKey("Memo.Domain.WordsModel.WordStatistic", "WordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
