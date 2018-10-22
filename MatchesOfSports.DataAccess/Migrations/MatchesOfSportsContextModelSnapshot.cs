﻿// <auto-generated />
using System;
using MatchesOfSports.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchesOfSports.DataAccess.Migrations
{
    [DbContext(typeof(MatchesOfSportsContext))]
    partial class MatchesOfSportsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatchesOfSports.Domain.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MatchId");

                    b.Property<string>("TheComment");

                    b.Property<Guid?>("UserWhoCommentUserId");

                    b.HasKey("CommentId");

                    b.HasIndex("MatchId");

                    b.HasIndex("UserWhoCommentUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.Match", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAndTime");

                    b.Property<Guid?>("KindOfSportSportId");

                    b.Property<Guid?>("TeamId");

                    b.Property<Guid>("TeamOne");

                    b.Property<Guid>("TeamTwo");

                    b.Property<Guid?>("TheSportSportId");

                    b.Property<bool>("WasDeleted");

                    b.HasKey("MatchId");

                    b.HasIndex("KindOfSportSportId");

                    b.HasIndex("TeamId");

                    b.HasIndex("TheSportSportId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.Sport", b =>
                {
                    b.Property<Guid>("SportId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("WasDeleted");

                    b.HasKey("SportId");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.Property<Guid?>("SportId");

                    b.Property<Guid?>("UserId");

                    b.Property<bool>("WasDeleted");

                    b.HasKey("TeamId");

                    b.HasIndex("SportId");

                    b.HasIndex("UserId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.Property<string>("UserName");

                    b.Property<int>("UserRole");

                    b.Property<bool>("WasDeleted");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.Comment", b =>
                {
                    b.HasOne("MatchesOfSports.Domain.Match")
                        .WithMany("Comments")
                        .HasForeignKey("MatchId");

                    b.HasOne("MatchesOfSports.Domain.User", "UserWhoComment")
                        .WithMany("ListOfComments")
                        .HasForeignKey("UserWhoCommentUserId");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.Match", b =>
                {
                    b.HasOne("MatchesOfSports.Domain.Sport", "KindOfSport")
                        .WithMany()
                        .HasForeignKey("KindOfSportSportId");

                    b.HasOne("MatchesOfSports.Domain.Team")
                        .WithMany("ListOfMatches")
                        .HasForeignKey("TeamId");

                    b.HasOne("MatchesOfSports.Domain.Sport", "TheSport")
                        .WithMany()
                        .HasForeignKey("TheSportSportId");
                });

            modelBuilder.Entity("MatchesOfSports.Domain.Team", b =>
                {
                    b.HasOne("MatchesOfSports.Domain.Sport", "Sport")
                        .WithMany("ListOfTeams")
                        .HasForeignKey("SportId");

                    b.HasOne("MatchesOfSports.Domain.User")
                        .WithMany("ListOfFavouriteTeams")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
