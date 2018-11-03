using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAPI.Models.ViewModel
{
    public class QuizViewModel
    {

    }
    public class CertificationNames
    {
        public int CertificationID { get; set; }
        public String Certificationname { get; set; }
    }
    public class KnowledgeAreaNames
    {
        public int KnowledgeAreaID { get; set; }
        public String KnowledgeAreaname { get; set; }
    }
    public class CertificationQuestionPercentageDetails
    {
        public int KnowledgeAreadID { get; set; }
        public String KnowkledgeAreaName { get; set; }
        public Decimal Percentage { get; set; }
    }

    public class QuestionViewModel
    {

        public int QuestionId { get; set; }
        public int CertificationId { get; set; }
        public string FullQuestion { get; set; }
        public string AnswerOption1 { get; set; }
        public string AnswerOption2 { get; set; }
        public string AnswerOption3 { get; set; }
        public string AnswerOption4 { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public string isCorrect { get; set; }

        public int? Mark { get; set; }
        public string AreaofKnowledge { get; set; }
        public string AnswerExplanation { get; set; }

    }
}