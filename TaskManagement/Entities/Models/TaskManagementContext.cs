using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Dtos;
using TaskManagement.Entities.Models;

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

        public DbSet<RefSetTerm> RefSetTerm { get; set; }

        public DbSet<RefTerm> RefTerm { get; set; }

        public DbSet<TaskMapAssignee> TaskMapAssignee { get; set; }

        public DbSet<Assignee> Assignee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string refTermPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\RefTermData.csv";
            string refTermCSV = File.ReadAllText(refTermPath);
            string[] RefTermdata = refTermCSV.Split('\r');
            List<RefTerm> list = new List<RefTerm>();
            foreach (string item in RefTermdata)
            {
                string[] row = item.Split(",");
                RefTerm refObj = new RefTerm { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString() };
                list.Add(refObj);
            }

            string refSetTermPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\RefSetTerm.csv";
            string refSetTermCSV = File.ReadAllText(refSetTermPath);
            string[] RefSetTermdata = refSetTermCSV.Split('\r');
            List<RefSetTerm> SetRefTermlist = new List<RefSetTerm>();
            foreach (string item in RefSetTermdata)
            {
                string[] row = item.Split(",");
                RefSetTerm refObj = new RefSetTerm() {Id=Guid.Parse(row[0]),RefSetId=Guid.Parse(row[1]),RefTermId=Guid.Parse(row[2]) };
                SetRefTermlist.Add(refObj);
            }

            string refSetPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\RefSetData.csv";
            string refSetCSV = File.ReadAllText(refSetPath);
            string[] refSetdata = refSetCSV.Split('\r');
            List<RefSet> refSetList = new List<RefSet>();
            foreach (string item in refSetdata)
            {
                string[] row = item.Split(",");
                RefSet refObj = new RefSet { Id = Guid.Parse(row[0]), Key = row[1].ToString(), Description = row[2].ToString() };
                refSetList.Add(refObj);
            }

            string loginPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\LoginData.csv";
            string loginCSV = File.ReadAllText(loginPath);
            string[] LoginData = loginCSV.Split('\r');
            List<LoginDTO> LoginList = new List<LoginDTO>();
            foreach (string item in LoginData)
            {
                string[] row = item.Split(",");
                SymmetricAlgorithm algorithm = DES.Create();
                ICryptoTransform transform = algorithm.CreateEncryptor(this.key, this.iv);
                byte[] inputbuffer = Encoding.Unicode.GetBytes(row[1]);
                byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                string EncryptPassword = Convert.ToBase64String(outputBuffer);
                LoginDTO loginDTO = new LoginDTO()
                {
                    UserName=row[0],
                    Password= EncryptPassword
                };
                LoginList.Add(loginDTO);
            }

            string assigneeDataPath = @"C:\Users\Hp\source\repos\TaskManagement\TaskManagement\Entities\RefSetData.csv";
            string assigneeCSV = File.ReadAllText(assigneeDataPath);
            string[] assigneedata = assigneeCSV.Split('\r');
            List<Assignee> assigneeList = new List<Assignee>();
            foreach (string item in assigneedata)
            {
                string[] row = item.Split(",");
                Assignee refObj = new Assignee { Id = Guid.Parse(row[0]), Name = row[1].ToString()};
                assigneeList.Add(refObj);
            }
        }
    }
}
