﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iDelivery.Infrastructure.Persistence;

#nullable disable

namespace iDelivery.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("iDelivery.Domain.AccountAggregate.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApiKey");

                    b.HasIndex("Email");

                    b.HasIndex("PhoneNumber");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("iDelivery.Domain.AccountAggregate.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsValid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PlanId");

                    b.ToTable("Subscriptions", (string)null);
                });

            modelBuilder.Entity("iDelivery.Domain.AccountAggregate.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Email");

                    b.HasIndex("PhoneNumber");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("iDelivery.Domain.CommandAggregate.Command", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Intitule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Latitude")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Longitude")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PreferredDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PreferredTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quarter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("City");

                    b.HasIndex("Latitude");

                    b.HasIndex("Longitude");

                    b.HasIndex("Quarter");

                    b.HasIndex("RefNum");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("iDelivery.Domain.CourierAggregate.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourierId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourierId");

                    b.ToTable("Deliveries", (string)null);
                });

            modelBuilder.Entity("iDelivery.Domain.PlanAggregate.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("iDelivery.Domain.CourierAggregate.Courier", b =>
                {
                    b.HasBaseType("iDelivery.Domain.AccountAggregate.Entities.User");

                    b.Property<Guid>("SupervisorId")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Courier");
                });

            modelBuilder.Entity("iDelivery.Domain.ManagerAggregate.Manager", b =>
                {
                    b.HasBaseType("iDelivery.Domain.AccountAggregate.Entities.User");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("iDelivery.Domain.SupervisorAggregate.Supervisor", b =>
                {
                    b.HasBaseType("iDelivery.Domain.AccountAggregate.Entities.User");

                    b.HasDiscriminator().HasValue("Supervisor");
                });

            modelBuilder.Entity("iDelivery.Domain.AccountAggregate.Entities.Subscription", b =>
                {
                    b.HasOne("iDelivery.Domain.AccountAggregate.Account", "Account")
                        .WithMany("Subscriptions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iDelivery.Domain.PlanAggregate.Plan", "Plan")
                        .WithMany("Subscriptions")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("iDelivery.Domain.AccountAggregate.Entities.User", b =>
                {
                    b.HasOne("iDelivery.Domain.AccountAggregate.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("iDelivery.Domain.CommandAggregate.Command", b =>
                {
                    b.OwnsMany("iDelivery.Domain.AccountAggregate.Complaint", "Complaints", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("CommandId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("ManagerId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Message")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Object")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PictureBlob")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Status")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id");

                            b1.HasIndex("CommandId");

                            b1.ToTable("Complaints", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CommandId");
                        });

                    b.OwnsOne("iDelivery.Domain.CommandAggregate.Entities.DeliveryStatus", "DeliveryStatus", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("CommandId")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FileBlob")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FileType")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Status")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id");

                            b1.HasIndex("CommandId")
                                .IsUnique();

                            b1.ToTable("DeliveryStatuses", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CommandId");
                        });

                    b.Navigation("Complaints");

                    b.Navigation("DeliveryStatus")
                        .IsRequired();
                });

            modelBuilder.Entity("iDelivery.Domain.CourierAggregate.Entities.Delivery", b =>
                {
                    b.HasOne("iDelivery.Domain.CourierAggregate.Courier", "Courier")
                        .WithMany("Deliveries")
                        .HasForeignKey("CourierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("iDelivery.Domain.CommandAggregate.ValueObjects.CommandId", "CommandIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("CourierId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("CourierId");

                            b1.ToTable("DeliveryCommandIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CourierId");
                        });

                    b.Navigation("CommandIds");

                    b.Navigation("Courier");
                });

            modelBuilder.Entity("iDelivery.Domain.CourierAggregate.Courier", b =>
                {
                    b.OwnsMany("iDelivery.Domain.CommandAggregate.ValueObjects.CommandId", "CommandIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("CourierId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("CourierId");

                            b1.ToTable("CourierCommandIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CourierId");
                        });

                    b.Navigation("CommandIds");
                });

            modelBuilder.Entity("iDelivery.Domain.ManagerAggregate.Manager", b =>
                {
                    b.OwnsMany("iDelivery.Domain.Common.ValueObjects.ComplaintId", "ComplaintIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("ManagerId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("ManagerId");

                            b1.ToTable("ManagerComplaintIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ManagerId");
                        });

                    b.Navigation("ComplaintIds");
                });

            modelBuilder.Entity("iDelivery.Domain.SupervisorAggregate.Supervisor", b =>
                {
                    b.OwnsMany("iDelivery.Domain.CourierAggregate.ValueObjects.CourierId", "CourierIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("SupervisorId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("SupervisorId");

                            b1.ToTable("SupervisorCourierIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupervisorId");
                        });

                    b.Navigation("CourierIds");
                });

            modelBuilder.Entity("iDelivery.Domain.AccountAggregate.Account", b =>
                {
                    b.Navigation("Subscriptions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("iDelivery.Domain.PlanAggregate.Plan", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("iDelivery.Domain.CourierAggregate.Courier", b =>
                {
                    b.Navigation("Deliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
