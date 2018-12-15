namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addedlanguage : DbMigration
    {
        public override void Up()
        {


            CreateTable(
                "dbo.LanguageMasters",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.CandidateExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.Questions", "LanguageId", "dbo.LanguageMasters");
            DropForeignKey("dbo.Questions", "KnowledgeAreaId", "dbo.KnowledgeAreas");
            DropForeignKey("dbo.Questions", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.CandidateExamQuestionDetails", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.CandidateExamQuestionDetails", "CandidateExamDetailId", "dbo.CandidateExamDetails");
            DropForeignKey("dbo.QuestionPercentageDetails", "QuestionPercentageId", "dbo.QuestionPercentages");
            DropForeignKey("dbo.QuestionPercentages", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.QuestionPercentageDetails", "KnowledgeAreaId", "dbo.KnowledgeAreas");
            DropForeignKey("dbo.KnowledgeAreas", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.CandidateExamDetails", "CandidateExamId", "dbo.CandidateExams");
            DropForeignKey("dbo.CandidateExams", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.CandidateExams", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "CertificationId" });
            DropIndex("dbo.Questions", new[] { "LanguageId" });
            DropIndex("dbo.Questions", new[] { "KnowledgeAreaId" });
            DropIndex("dbo.Questions", new[] { "CertificationId" });
            DropIndex("dbo.CandidateExamQuestionDetails", new[] { "QuestionId" });
            DropIndex("dbo.CandidateExamQuestionDetails", new[] { "CandidateExamDetailId" });
            DropIndex("dbo.QuestionPercentageDetails", new[] { "QuestionPercentageId" });
            DropIndex("dbo.QuestionPercentages", new[] { "CertificationId" });
            DropIndex("dbo.QuestionPercentageDetails", new[] { "KnowledgeAreaId" });
            DropIndex("dbo.KnowledgeAreas", new[] { "CertificationId" });
            DropIndex("dbo.CandidateExamDetails", new[] { "CandidateExamId" });
            DropIndex("dbo.CandidateExams", new[] { "CandidateId" });
            DropTable("dbo.LanguageMasters");

        }
    }
}
