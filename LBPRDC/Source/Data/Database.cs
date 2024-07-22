using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms; // Make sure to include this for MessageBox

namespace LBPRDC.Source.Data
{
    internal class Database
    {
        public class Context : DbContext
        {
            public DbSet<Models.AccessPermission> AccessPermissions { get; set; }
            public DbSet<Models.RolePermission> RolePermissions { get; set; }


            public DbSet<Models.PayFrequency> PayFrequencies { get; set; }
            public DbSet<Models.User> Users { get; set; }
            public DbSet<Models.UserRole> UserRoles { get; set; }
            public DbSet<Models.AuditLog> AuditLogs { get; set; }

            public DbSet<Models.Employee> Employees { get; set; }
            public DbSet<Models.Suffix> Suffixes { get; set; }
            public DbSet<Models.EmployeeArchive> EmployeeArchives { get; set; }

            public DbSet<Models.EmploymentStatus> EmploymentStatus { get; set; }

            public DbSet<Models.Client> Clients { get; set; }
            public DbSet<Models.Classification> Classifications { get; set; }
            public DbSet<Models.Wage> Wages { get; set; }
            public DbSet<Models.Position> Position { get; set; }
            public DbSet<Models.Department> Departments { get; set; }
            public DbSet<Models.Location> Locations { get; set; }

            public DbSet<Models.Employee.History> EmployeePreviousRecord { get; set; }
            public DbSet<Models.EmploymentStatus.History> EmployeeEmploymentHistory { get; set; }
            public DbSet<Models.Department.History> EmployeeDepartmentLocationHistory { get; set; }
            public DbSet<Models.Position.History> EmployeePositionHistory { get; set; }
            public DbSet<Models.Position.RatesHistory> PositionRatesHistory { get; set; }

            public DbSet<Models.Billing> Billing { get; set; }
            public DbSet<Models.Billing.Record> BillingRecord { get; set; }
            public DbSet<Models.Billing.Account> BillingAccounts { get; set; }
            public DbSet<Models.Billing.Account.Equipment> BillingAccountEquipments { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(DataAccessHelper.GetConnectionString());
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //modelBuilder.Entity<Models.Department>().HasKey(d => d.ID);
                //modelBuilder.Entity<Models.Position>().HasKey(d => d.ID);

                //modelBuilder.Entity<Models.Employee.View>()
                //    .HasOne(e => e.ClientName)
                //    .WithMany()
                //    .HasForeignKey(e => e.ClientID);

                //modelBuilder.Entity<Models.Employee.View>()
                //    .HasOne(e => e.Department)
                //    .WithMany()
                //    .HasForeignKey(e => e.DepartmentID);

                //modelBuilder.Entity<Models.Employee.View>()
                //    .HasOne(e => e.Location)
                //    .WithMany()
                //    .HasForeignKey(e => e.LocationID);

                //modelBuilder.Entity<Models.Employee.View>()
                //    .HasOne(e => e.CivilStatus)
                //    .WithMany()
                //    .HasForeignKey(e => e.CivilStatusID);

                //modelBuilder.Entity<Models.Employee.View>()
                //    .HasOne(e => e.Position)
                //    .WithMany()
                //    .HasForeignKey(e => e.PositionID);

                //modelBuilder.Entity<Models.Employee.View>()
                //    .HasOne(e => e.EmploymentStatus)
                //    .WithMany()
                //    .HasForeignKey(e => e.EmploymentStatusID);
            }

            public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            {
                Cursor.Current = Cursors.WaitCursor;

                int result = await base.SaveChangesAsync(cancellationToken);

                Cursor.Current = Cursors.Default;

                return result;
            }
        }

        public static SqlConnection? Connect()
        {
            SqlConnection connection = new SqlConnection(DataAccessHelper.GetConnectionString());

            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Connection failed. Error code: {ex.ErrorCode}\nMessage: {ex.Message}", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return connection;
        }
    }
}
