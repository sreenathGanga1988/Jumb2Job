using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace QuizAPI.Models
{
    public class LanguageMaster
    {
        [Key]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Enter Correct Language")]
        [Display(Name = "Language Name")]
        public string LanguageName { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        [Display(Name = "Certification Name")]
        public string CertificationName { get; set; }
        public virtual List<KnowledgeArea> KnowlwdgeAreas { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<QuestionPercentage> QuestionPercentages { get; set; }
    }


    public class KnowledgeArea
    {
      
        [Key]
        public int KnowledgeAreaId { get; set; }
        [Required(ErrorMessage = "Enter Correct Certification")]
        [Display(Name = "Certification")]
        public int CertificationId { get; set; }
        [Display(Name = "Name")]
        public string KnowledgeAreaName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        public virtual Certification Certification { get; set; }
        public virtual List<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
        public virtual List<Question> Questions { get; set; }
    }

    public class QuestionPercentage
    {
        [Key]
        public int QuestionPercentageId { get; set; }
        [Required(ErrorMessage = "Enter Correct Certification")]
        [Display(Name = "Certification")]
        public int CertificationId { get; set; }
        public virtual Certification Certification { get; set; }
        public virtual List<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
    }

    public class QuestionPercentageDetail
    {
        [Key]
        public int QuestionPercentageDetailId { get; set; }
        [Required(ErrorMessage = "QuestionPercentage")]
        [Display(Name = "QuestionPercentage")]

        public int QuestionPercentageId { get; set; }
        [Required(ErrorMessage = "Enter Correct Knowlege Area")]
        [Display(Name = "Knowlege Area")]
        public int KnowledgeAreaId { get; set; }
        public int TotalPercentage { get; set; }
        public virtual QuestionPercentage QuestionPercentage { get; set; }
        public virtual KnowledgeArea KnowledgeArea { get; set; }
    }



    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Select Certification")]
        [Display(Name = "Certification")]
        public int CertificationId { get; set; }


        [Display(Name = "Study Area")]
        public int KnowledgeAreaId { get; set; }

        [Required(ErrorMessage = "Select Language")]
        [Display(Name = "Language :")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Enter Question")]
        [Display(Name = "Question")]
        public string FullQuestion { get; set; }

        [Required(ErrorMessage = "Enter Answer Option 1")]
        [Display(Name = "Option 1")]
        public string AnswerOption1 { get; set; }

        [Required(ErrorMessage = "Answer Option 2")]
        [Display(Name = "Option 2")]
        public string AnswerOption2 { get; set; }

        [Required(ErrorMessage = "Answer Option 3")]
        [Display(Name = "Option 3")]
        public string AnswerOption3 { get; set; }

        [Required(ErrorMessage = "Answer Option 4")]
        [Display(Name = "Option 4")]
        public string AnswerOption4 { get; set; }

        [Required(ErrorMessage = "Enter Correct Answer")]
        [Display(Name = "Correct Answer")]
        public string CorrectAnswerIndex { get; set; }

        [Display(Name = "Mark for Question")]
        public int? Mark { get; set; }
        [Display(Name = "QuestionType")]
        public string AreaofKnowledge { get; set; }

        [Display(Name = "Explanation of Answer")]
        public string AnswerExplanation { get; set; }

        [Display(Name = "Can be used for Test")]
        public bool isDisplayOnly { get; set; }


       public virtual LanguageMaster LanguageMaster { get; set; }
        public virtual KnowledgeArea KnowledgeArea { get; set; }

        
        public virtual Certification Certification { get; set; }

        public virtual List<CandidateExamQuestionDetail> CandidateExamQuestionDetails { get; set; }
    }


    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [Required(ErrorMessage = "Enter CandidateName")]
        [Display(Name = "Candidate Name")]
        public string CandidateName { get; set; }

        [Required(ErrorMessage = "Enter Candidate Email")]
        [Display(Name = " Email/Username")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CandidateEmail { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPasswod { get; set; }

        public virtual List<CandidateExam> CandidateExam { get; set; }
    }

    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Enter Certification for Exam")]
        [Display(Name = " Certification")]
        public int CertificationId { get; set; }
        public virtual Certification Certification { get; set; }
    }

    public class CandidateExam
    {
        [Key]
        public int CandidateExamId { get; set; }
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual List<CandidateExamDetail> CandidateExamDetail { get; set; }
    }

    public class CandidateExamDetail
    {
        [Key]
        public int CandidateExamDetailId { get; set; }
        public int CandidateExamId { get; set; }
        public virtual CandidateExam CandidateExam { get; set; }
        public virtual List<CandidateExamQuestionDetail> CandidateExamQuestionDetail { get; set; }
    }

    public class CandidateExamQuestionDetail
    {
        [Key]
        public int CandidateExamQuestionDetailsId { get; set; }
        public int CandidateExamDetailId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswer { get; set; }
        public bool? IsCorrect { get; set; }
        public string Status { get; set; }

        public virtual Question Question { get; set; }
        public virtual CandidateExamDetail CandidateExamDetail { get; set; }
    }
}


