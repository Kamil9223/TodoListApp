﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.Context.Migrations
{
    [DbContext(typeof(TodoTasksContext))]
    [Migration("20210410144618_OnDelete")]
    partial class OnDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoListApp.Core.Domain.SingleTask", b =>
                {
                    b.Property<int>("SingleTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardTasksBoardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PredictedFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)0);

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("SingleTaskId");

                    b.HasIndex("BoardTasksBoardId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TodoListApp.Core.Domain.TaskDetails", b =>
                {
                    b.Property<int>("TaskDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<int?>("SingleTaskId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TaskDetailsId");

                    b.HasIndex("SingleTaskId");

                    b.ToTable("TaskDetails");
                });

            modelBuilder.Entity("TodoListApp.Core.Domain.TasksBoard", b =>
                {
                    b.Property<int>("TasksBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TasksBoardId");

                    b.HasIndex("UserId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("TodoListApp.Core.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TodoListApp.Core.Domain.SingleTask", b =>
                {
                    b.HasOne("TodoListApp.Core.Domain.TasksBoard", "Board")
                        .WithMany("Tasks")
                        .HasForeignKey("BoardTasksBoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TodoListApp.Core.Domain.TaskDetails", b =>
                {
                    b.HasOne("TodoListApp.Core.Domain.SingleTask", "SingleTask")
                        .WithMany("Details")
                        .HasForeignKey("SingleTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TodoListApp.Core.Domain.TasksBoard", b =>
                {
                    b.HasOne("TodoListApp.Core.Domain.User", "User")
                        .WithMany("Boards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
