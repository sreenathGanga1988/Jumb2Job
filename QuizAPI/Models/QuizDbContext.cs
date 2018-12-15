using System.Data.Entity;
using QuizAPI.Models;


public class QuizContext : DbContext
{

    public QuizContext()
        : base("name = QuizConnectionString")
    {
        Database.SetInitializer<QuizContext>(new CreateDatabaseIfNotExists<QuizContext>());


        //        Database.SetInitializer<QuizContext>(

        //new MigrateDatabaseToLatestVersion<QuizContext, GTest.Migrations.Configuration>());

        Database.Initialize(false);




    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Certification> Certifications { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<CandidateExam> CandidateExams { get; set; }
    public DbSet<CandidateExamDetail> CandidateExamDetails { get; set; }
    public DbSet<CandidateExamQuestionDetail> CandidateExamQuestionDetails { get; set; }
    public System.Data.Entity.DbSet<KnowledgeArea> KnowledgeAreas { get; set; }
    public System.Data.Entity.DbSet<QuestionPercentage> QuestionPercentages { get; set; }
    public System.Data.Entity.DbSet<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
    public System.Data.Entity.DbSet<LanguageMaster> LanguageMasters { get; set; }
    public System.Data.Entity.DbSet<CountryMaster> CountryMasters { get; set; }
    public System.Data.Entity.DbSet<JobFieldArea> JobFieldAreas { get; set; }
    public System.Data.Entity.DbSet<JobField> JobFields { get; set; }
    public System.Data.Entity.DbSet<JobVaccancy> JobVaccancys { get; set; }
    public System.Data.Entity.DbSet<SiteUrl> SiteUrls { get; set; }




}