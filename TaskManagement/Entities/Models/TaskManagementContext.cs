using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Dtos;

namespace TaskManagement.Models
{
    public class TaskManagementContext : DbContext
    {
        byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<RefSet> RefSet { get; set; }

        public DbSet<SetRefTerm> SetRefTerm { get; set; }

        public DbSet<RefTerm> RefTerm { get; set; }

        public DbSet<TaskAssigneeMapping> TaskAssigneeMapping { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string refTermPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\RefTermData.csv";
            string refTermCSV = File.ReadAllText(refTermPath);
            string[] RefTermdata = refTermCSV.Split('\r');
            List<RefTerm> list = new List<RefTerm>();
            foreach (string item in RefTermdata)
            {
                string[] row = item.Split(",");
                RefTerm refObj = new RefTerm { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString(),CreatedDate=DateTime.Now,IsActive=true };
                list.Add(refObj);
            }
            modelBuilder.Entity<RefTerm>()
            .HasData(list);

            string refSetTermPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\RefSetTerm.csv";
            string refSetTermCSV = File.ReadAllText(refSetTermPath);
            string[] RefSetTermdata = refSetTermCSV.Split('\r');
            List<SetRefTerm> SetRefTermlist = new List<SetRefTerm>();
            foreach (string item in RefSetTermdata)
            {
                string[] row = item.Split(",");
                SetRefTerm refObj = new SetRefTerm() {Id=Guid.NewGuid(),RefSetId=Guid.Parse(row[0]),RefTermId=Guid.Parse(row[1]),IsActive=true,CreatedDate=DateTime.Now };
                SetRefTermlist.Add(refObj);
            }
            modelBuilder.Entity<SetRefTerm>()
            .HasData(SetRefTermlist);


            string refSetPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\RefSetData.csv";
            string refSetCSV = File.ReadAllText(refSetPath);
            string[] refSetdata = refSetCSV.Split('\r');
            List<RefSet> refSetList = new List<RefSet>();
            foreach (string item in refSetdata)
            {
                string[] row = item.Split(",");
                RefSet refObj = new RefSet { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString(),IsActive = true, CreatedDate = DateTime.Now };
                refSetList.Add(refObj);
            }
            modelBuilder.Entity<RefSet>()
            .HasData(refSetList);


            string loginPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\Migrations\Files\LoginData.csv";
            string loginCSV = File.ReadAllText(loginPath);
            string[] LoginData = loginCSV.Split('\r');
            List<User> LoginList = new List<User>();
            foreach (string item in LoginData)
            {
                string[] row = item.Split(",");
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateEncryptor(this.key, this.iv);
                byte[] inputbuffer = Encoding.Unicode.GetBytes(row[1]);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                string EncryptPassword = Convert.ToBase64String(outputBuffer);
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Email=row[0],
                    Password= EncryptPassword,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };
                LoginList.Add(user);
            }
            modelBuilder.Entity<User>()
            .HasData(LoginList);

        }
    }
}
