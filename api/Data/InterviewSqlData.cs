using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class InterviewSqlData : DbContext
    {


        public InterviewSqlData(DbContextOptions<InterviewSqlData> options) : base(options) { }
        public DbSet<Interview> Interviews { get; set; }

        public DbSet<Interviewee> Interviewees { get; set; }

        public DbSet<Interviewer> Interviewers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Vote> Votes {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=(localdb)\\MsSqllocaldb;Database=Interviews;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //one to many interviewee can have many interviews
            //an interview belongs to one interviewee
            mb.Entity<Interview>().HasOne(i => i.Interviewee).WithMany(i => i.Interviews);

            //many to many an interviewer will conduct mulitple interviews and 
            //an interview will have multiple interviewers
            mb.Entity<InterviewAndInterviewees>()
                .HasKey( ivier => new { ivier.InterviewId, ivier.InterviewerId});
            mb.Entity<InterviewAndInterviewees>()
                .HasOne(i => i.Interview).WithMany( i => i.Interviewers)
                .HasForeignKey(i => i.InterviewerId);
            mb.Entity<InterviewAndInterviewees>()
                .HasOne(ir => ir.Interviewer).WithMany( i => i.Interviews)
                .HasForeignKey( ik => ik.InterviewerId);

            //may to many interview to questions and questions to interviews
            //an interview will have multiple questions and a question can
            //be asked in multiple interviews
            mb.Entity<InterviewQuestions>()
                .HasKey( iq => new { iq.InterviewId, iq.QuestionId});
            mb.Entity<InterviewQuestions>()
                .HasOne( i => i.Interview).WithMany( q => q.Questions)
                .HasForeignKey(ik => ik.InterviewId);
            mb.Entity<InterviewQuestions>()
                .HasOne( q => q.Question).WithMany( i => i.Interviews)
                .HasForeignKey( ik => ik.QuestionId);          

            // on to many a question can have multiple votes but a vote 
            //belongs to one question
            mb.Entity<Question>().HasMany( v => v.Votes).WithOne(v => v.Question);

           
        }
    }
}