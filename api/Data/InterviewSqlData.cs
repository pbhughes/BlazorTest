using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


namespace api.Models {
    public class InterviewSqlData : DbContext {

        
        public InterviewSqlData (DbContextOptions<InterviewSqlData> options) : base (options) { }
        public DbSet<Interview> Interviews { get; set; }

        public DbSet<Interviewee> Interviewees {get; set;}

        public DbSet<Interviewer> Interviewers {get; set;}

        public DbSet<Question> Questions{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=(localdb)\\interviewData;Database=Blogging;Trusted_Connection=True;");

        
    }
}