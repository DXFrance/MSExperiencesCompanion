using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RatingApi.Models;

namespace RatingApi.Migrations
{
    [DbContext(typeof(RatingContext))]
    partial class RatingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RatingApi.Models.Rating", b =>
                {
                    b.Property<int>("SessionId");

                    b.Property<int>("UserId");

                    b.Property<int>("Notation");

                    b.HasKey("SessionId", "UserId");

                    b.ToTable("Ratings");
                });
        }
    }
}
