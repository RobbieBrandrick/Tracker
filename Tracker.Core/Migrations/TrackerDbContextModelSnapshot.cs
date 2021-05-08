﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tracker.Core.Data;

namespace Tracker.Core.Migrations
{
    [DbContext(typeof(TrackerDbContext))]
    partial class TrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("SessionId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.ExerciseSet", b =>
                {
                    b.Property<int>("SetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SetId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("SetId")
                        .IsUnique();

                    b.ToTable("ExerciseSets");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.ExerciseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExerciseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Squat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bench"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Deadlift"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pullups"
                        });
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<long>("Duration")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RPE")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Reps")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Exercise", b =>
                {
                    b.HasOne("Tracker.Core.Models.ExerciseTracker.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tracker.Core.Models.ExerciseTracker.Session", "Session")
                        .WithMany("Exercises")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseType");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.ExerciseSet", b =>
                {
                    b.HasOne("Tracker.Core.Models.ExerciseTracker.Exercise", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tracker.Core.Models.ExerciseTracker.Set", "Set")
                        .WithOne("Exercise")
                        .HasForeignKey("Tracker.Core.Models.ExerciseTracker.ExerciseSet", "SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Set");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Exercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Session", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Tracker.Core.Models.ExerciseTracker.Set", b =>
                {
                    b.Navigation("Exercise");
                });
#pragma warning restore 612, 618
        }
    }
}
