﻿// <auto-generated />
using System;
using BloggieWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloggieWebsite.Migrations
{
    [DbContext(typeof(BloggieDbContext))]
    [Migration("20240602101223_User-details")]
    partial class Userdetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlogPostTag", b =>
                {
                    b.Property<Guid>("BlogPostsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BlogPostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("BlogPostTag");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeaturedImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urlhandle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPostComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogPostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostID");

                    b.HasIndex("UsersId");

                    b.ToTable("PostComments");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPostLikes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogPostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("UsersId");

                    b.ToTable("BlogPostLike");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BackendAPIProgress")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Github")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MobileTemplateProgress")
                        .HasColumnType("int");

                    b.Property<int>("OnePageProgress")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebDesignProgress")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WebsiteMarkupProgress")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogPostTag", b =>
                {
                    b.HasOne("BloggieWebsite.Models.Domain.BlogPost", null)
                        .WithMany()
                        .HasForeignKey("BlogPostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloggieWebsite.Models.Domain.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPost", b =>
                {
                    b.HasOne("BloggieWebsite.Models.Domain.Users", null)
                        .WithMany("BlogPosts")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPostComment", b =>
                {
                    b.HasOne("BloggieWebsite.Models.Domain.BlogPost", null)
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloggieWebsite.Models.Domain.Users", null)
                        .WithMany("Comments")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPostLikes", b =>
                {
                    b.HasOne("BloggieWebsite.Models.Domain.BlogPost", null)
                        .WithMany("Likes")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloggieWebsite.Models.Domain.Users", null)
                        .WithMany("Likes")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.Tag", b =>
                {
                    b.HasOne("BloggieWebsite.Models.Domain.Users", null)
                        .WithMany("Tags")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.BlogPost", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("BloggieWebsite.Models.Domain.Users", b =>
                {
                    b.Navigation("BlogPosts");

                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
