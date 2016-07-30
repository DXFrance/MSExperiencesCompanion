using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ScheduleApi.Models;

namespace ScheduleApi.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20160729222155_RemoveTimeInSessions")]
    partial class RemoveTimeInSessions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScheduleApi.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ScheduleApi.Models.SessionSpeaker", b =>
                {
                    b.Property<int>("SessionId");

                    b.Property<int>("SpeakerId");

                    b.HasKey("SessionId", "SpeakerId");

                    b.HasIndex("SessionId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SessionSpeaker");
                });

            modelBuilder.Entity("ScheduleApi.Models.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Twitter")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("ScheduleApi.Models.SessionSpeaker", b =>
                {
                    b.HasOne("ScheduleApi.Models.Speaker", "Speaker")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ScheduleApi.Models.Session", "Session")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
