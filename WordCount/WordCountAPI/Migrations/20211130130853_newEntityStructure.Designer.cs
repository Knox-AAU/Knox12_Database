﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WordCount.Data;

namespace WordCount.Migrations
{
    [DbContext(typeof(ArticleContext))]
    [Migration("20211130130853_newEntityStructure")]
    partial class newEntityStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WordCount.Data.Models.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<string>("PublisherName")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("TotalWords")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PublisherName");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("WordCount.Data.Models.JsonSchemaModel", b =>
                {
                    b.Property<string>("SchemaName")
                        .HasColumnType("text");

                    b.Property<string>("JsonString")
                        .HasColumnType("jsonb");

                    b.HasKey("SchemaName");

                    b.ToTable("JsonSchema");
                });

            modelBuilder.Entity("WordCount.Data.Models.Publisher", b =>
                {
                    b.Property<string>("PublisherName")
                        .HasColumnType("text");

                    b.HasKey("PublisherName");

                    b.HasIndex("PublisherName")
                        .IsUnique();

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("WordCount.Data.Models.Term", b =>
                {
                    b.Property<string>("Literal")
                        .HasColumnType("text");

                    b.HasKey("Literal");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("WordCount.Data.Models.WordOccurance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("WordLiteral")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("WordLiteral");

                    b.ToTable("WordOccurance");
                });

            modelBuilder.Entity("WordCount.Data.Models.WordRatio", b =>
                {
                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<float>("Percent")
                        .HasColumnType("real");

                    b.Property<string>("PublisherName")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("TotalWords")
                        .HasColumnType("integer");

                    b.Property<string>("Word")
                        .HasColumnType("text");

                    b.ToView("WordRatio");
                });

            modelBuilder.Entity("WordCount.Data.Models.Article", b =>
                {
                    b.HasOne("WordCount.Data.Models.Publisher", "Publisher")
                        .WithMany("Articles")
                        .HasForeignKey("PublisherName");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("WordCount.Data.Models.WordOccurance", b =>
                {
                    b.HasOne("WordCount.Data.Models.Article", "Article")
                        .WithMany("Words")
                        .HasForeignKey("ArticleId");

                    b.HasOne("WordCount.Data.Models.Term", "Word")
                        .WithMany("Occurances")
                        .HasForeignKey("WordLiteral");

                    b.Navigation("Article");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("WordCount.Data.Models.Article", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("WordCount.Data.Models.Publisher", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("WordCount.Data.Models.Term", b =>
                {
                    b.Navigation("Occurances");
                });
#pragma warning restore 612, 618
        }
    }
}
