﻿// <auto-generated />
using System;
using KokoPizza.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KokoPizza.Persistance.Migrations
{
    [DbContext(typeof(KokoPizzaDbContext))]
    partial class KokoPizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseHiLo(modelBuilder, "EntityFrameworkHiLoSequence");

            modelBuilder.HasSequence("EntityFrameworkHiLoSequence")
                .IncrementsBy(10);

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_carts");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_carts_user_id");

                    b.ToTable("carts", (string)null);
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint")
                        .HasColumnName("cart_id");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_cart_items");

                    b.HasIndex("CartId")
                        .HasDatabaseName("ix_cart_items_cart_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_cart_items_product_id");

                    b.ToTable("cart_items", (string)null);
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ship_address");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint")
                        .HasColumnName("status_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("product_price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_items_order_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_items_product_id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PictureUri")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("picture_uri");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("KokoPizza.Core.Domain.Entities.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cart_items_carts_cart_id");

                    b.HasOne("KokoPizza.Core.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cart_items_products_product_id");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("KokoPizza.Core.Domain.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_items_orders_order_id");

                    b.HasOne("KokoPizza.Core.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_items_products_product_id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Product", b =>
                {
                    b.HasOne("KokoPizza.Core.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("KokoPizza.Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}