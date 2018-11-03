namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateExamDetails",
                c => new
                    {
                        CandidateExamDetailId = c.Int(nullable: false, identity: true),
                        CandidateExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateExamDetailId)
                .ForeignKey("dbo.CandidateExams", t => t.CandidateExamId, cascadeDelete: true)
                .Index(t => t.CandidateExamId);
            
            CreateTable(
                "dbo.CandidateExams",
                c => new
                    {
                        CandidateExamId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateExamId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(nullable: false),
                        CandidateEmail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPasswod = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        CertificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Certifications", t => t.CertificationId, cascadeDelete: true)
                .Index(t => t.CertificationId);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        CertificationId = c.Int(nullable: false, identity: true),
                        CertificationName = c.String(),
                    })
                .PrimaryKey(t => t.CertificationId);
            
            CreateTable(
                "dbo.KnowledgeAreas",
                c => new
                    {
                        KnowledgeAreaId = c.Int(nullable: false, identity: true),
                        CertificationId = c.Int(nullable: false),
                        KnowledgeAreaName = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.KnowledgeAreaId)
                .ForeignKey("dbo.Certifications", t => t.CertificationId, cascadeDelete: true)
                .Index(t => t.CertificationId);
            
            CreateTable(
                "dbo.QuestionPercentageDetails",
                c => new
                    {
                        QuestionPercentageDetailId = c.Int(nullable: false, identity: true),
                        QuestionPercentageId = c.Int(nullable: false),
                        KnowledgeAreaId = c.Int(nullable: false),
                        TotalPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionPercentageDetailId)
                .ForeignKey("dbo.KnowledgeAreas", t => t.KnowledgeAreaId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionPercentages", t => t.QuestionPercentageId, cascadeDelete: true)
                .Index(t => t.QuestionPercentageId)
                .Index(t => t.KnowledgeAreaId);
            
            CreateTable(
                "dbo.QuestionPercentages",
                c => new
                    {
                        QuestionPercentageId = c.Int(nullable: false, identity: true),
                        CertificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionPercentageId)
                .ForeignKey("dbo.Certifications", t => t.CertificationId, cascadeDelete: false)
                .Index(t => t.CertificationId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        CertificationId = c.Int(nullable: false),
                        FullQuestion = c.String(nullable: false),
                        AnswerOption1 = c.String(nullable: false),
                        AnswerOption2 = c.String(nullable: false),
                        AnswerOption3 = c.String(nullable: false),
                        AnswerOption4 = c.String(nullable: false),
                        CorrectAnswerIndex = c.String(nullable: false),
                        Mark = c.Int(),
                        AreaofKnowledge = c.String(),
                        AnswerExplanation = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Certifications", t => t.CertificationId, cascadeDelete: true)
                .Index(t => t.CertificationId);
            
            CreateTable(
                "dbo.CandidateExamQuestionDetails",
                c => new
                    {
                        CandidateExamQuestionDetailsId = c.Int(nullable: false, identity: true),
                        CandidateExamDetailId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        SelectedAnswer = c.Int(nullable: false),
                        IsCorrect = c.Boolean(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CandidateExamQuestionDetailsId)
                .ForeignKey("dbo.CandidateExamDetails", t => t.CandidateExamDetailId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: false)
                .Index(t => t.CandidateExamDetailId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.Questions", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.CandidateExamQuestionDetails", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.CandidateExamQuestionDetails", "CandidateExamDetailId", "dbo.CandidateExamDetails");
            DropForeignKey("dbo.QuestionPercentageDetails", "QuestionPercentageId", "dbo.QuestionPercentages");
            DropForeignKey("dbo.QuestionPercentages", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.QuestionPercentageDetails", "KnowledgeAreaId", "dbo.KnowledgeAreas");
            DropForeignKey("dbo.KnowledgeAreas", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.CandidateExamDetails", "CandidateExamId", "dbo.CandidateExams");
            DropForeignKey("dbo.CandidateExams", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.CandidateExamQuestionDetails", new[] { "QuestionId" });
            DropIndex("dbo.CandidateExamQuestionDetails", new[] { "CandidateExamDetailId" });
            DropIndex("dbo.Questions", new[] { "CertificationId" });
            DropIndex("dbo.QuestionPercentages", new[] { "CertificationId" });
            DropIndex("dbo.QuestionPercentageDetails", new[] { "KnowledgeAreaId" });
            DropIndex("dbo.QuestionPercentageDetails", new[] { "QuestionPercentageId" });
            DropIndex("dbo.KnowledgeAreas", new[] { "CertificationId" });
            DropIndex("dbo.Exams", new[] { "CertificationId" });
            DropIndex("dbo.CandidateExams", new[] { "ExamId" });
            DropIndex("dbo.CandidateExams", new[] { "CandidateId" });
            DropIndex("dbo.CandidateExamDetails", new[] { "CandidateExamId" });
            DropTable("dbo.CandidateExamQuestionDetails");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionPercentages");
            DropTable("dbo.QuestionPercentageDetails");
            DropTable("dbo.KnowledgeAreas");
            DropTable("dbo.Certifications");
            DropTable("dbo.Exams");
            DropTable("dbo.Candidates");
            DropTable("dbo.CandidateExams");
            DropTable("dbo.CandidateExamDetails");
        }
    }
}
