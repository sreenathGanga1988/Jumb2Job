using QuizAPI.Models;
using QuizAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAPI.Repository
{
    class DbRepository
    {
    }

    public static class QuestionRepository
    {
        public static QuizContext cntxt = new QuizContext();

        public static List<QuestionViewModel> GetQuestion()
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1,
                         AnswerOption2 = qst.AnswerOption2,
                         AnswerOption3 = qst.AnswerOption3,
                         AnswerOption4 = qst.AnswerOption4,
                         CorrectAnswer = qst.CorrectAnswerIndex,
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.AreaofKnowledge,
                         AnswerExplanation = qst.AnswerExplanation
                     }).ToList();

            return q;
        }

        public static List<QuestionViewModel> GetQuestionofExamofLanguage(int CertificationId,int LanguageId)
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.LanguageId==LanguageId && qst.CertificationId==CertificationId 
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1,
                         AnswerOption2 = qst.AnswerOption2,
                         AnswerOption3 = qst.AnswerOption3,
                         AnswerOption4 = qst.AnswerOption4,
                         CorrectAnswer = qst.CorrectAnswerIndex,
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation
                     }).ToList();

            return q;
        }

        public static Question GetQuestion(int Quid)
        {
            Question question = cntxt.Questions.Where(u => u.QuestionId == Quid).FirstOrDefault();

            return question;
        }
    }


    public static class CertificationRepository
    {
        public static QuizContext cntxt = new QuizContext();

        public static void InsertCertification(Certification cert)
        {

            cntxt.Certifications.Add(cert);
            cntxt.SaveChanges();
        }

        public static List<CertificationNames> GetAllCertifications()
        {
            List<CertificationNames> certificationNames = cntxt.Certifications.Select(cert => new CertificationNames { CertificationID = cert.CertificationId, Certificationname = cert.CertificationName }).ToList();

            return certificationNames;
        }
    }


    public static class KnowledgeAreaRepository
    {
        public static QuizContext cntxt = new QuizContext();

        public static void InsertKnowledgeArea(KnowledgeArea knowledgeArea)
        {

            cntxt.KnowledgeAreas.Add(knowledgeArea);
            cntxt.SaveChanges();
        }

        public static List<KnowledgeAreaNames> GetAllknowledgeArea()
        {
            List<KnowledgeAreaNames> knowledgeAreaNames = cntxt.KnowledgeAreas.Select(cert => new KnowledgeAreaNames { KnowledgeAreaname = cert.KnowledgeAreaName, KnowledgeAreaID = cert.KnowledgeAreaId }).ToList();

            return knowledgeAreaNames;
        }

        public static List<KnowledgeArea> GetAllknowledgeAreaOfCertification(int CertificationID)
        {
            List<KnowledgeArea> knowledgeAreaNames = cntxt.KnowledgeAreas.Where(x => x.CertificationId == CertificationID).ToList();

            return knowledgeAreaNames;
        }
    }




    public static class QuestionPercentageRepository
    {
        public static QuizContext cntxt = new QuizContext();




        public static QuestionPercentage GetQuestionPercentage(int CertificationID)
        {
            QuestionPercentage questionPercentage = null;
            try
            {
                questionPercentage = questionPercentage = cntxt.QuestionPercentages.Where(x => x.CertificationId == CertificationID).First();
            }
            catch (Exception)
            {


            }


            return questionPercentage;
        }




        public static Decimal GetKnowledgeAreaQuestionPercentageofCertification(int questionpercentageid, int knowledgeareaid)
        {
            Decimal percentage = 0;

            try
            {
                var q = cntxt.QuestionPercentageDetails.Where(x => x.QuestionPercentageId == questionpercentageid && x.KnowledgeAreaId == knowledgeareaid).First();
            }
            catch (Exception)
            {


            }

            return percentage;

        }


        public static QuestionPercentage CreateQuestionPercentage(int CertificationID)
        {
            QuestionPercentage questionPercentage = null;


            if (CertificationID != 0)
            {

                questionPercentage = GetQuestionPercentage(CertificationID);


                if (questionPercentage == null)
                {
                    questionPercentage = new QuestionPercentage();
                    questionPercentage.QuestionPercentageId = 0;
                    questionPercentage.CertificationId = CertificationID;

                }



                List<KnowledgeArea> knowledgeArealist = KnowledgeAreaRepository.GetAllknowledgeAreaOfCertification(CertificationID);

                foreach (KnowledgeArea element in knowledgeArealist)
                {

                    if (!questionPercentage.QuestionPercentageDetails.Any(f => f.KnowledgeAreaId == element.KnowledgeAreaId))
                    {

                        QuestionPercentageDetail det = new QuestionPercentageDetail();
                        det.KnowledgeAreaId = element.KnowledgeAreaId;
                        det.KnowledgeArea = element;
                        det.TotalPercentage = 0;

                        questionPercentage.QuestionPercentageDetails.Add(det);
                    }





                }

            }

            return questionPercentage;
        }


        public static void InsertQuestionPercentageDetails(QuestionPercentageDetail questionPercentageDetail)
        {
            if (questionPercentageDetail.QuestionPercentageDetailId != 0)
            {







            }

            else
            {


                cntxt.QuestionPercentageDetails.Add(questionPercentageDetail);
                cntxt.SaveChanges();





            }


        }

        public static List<Certification> GetAllCertifications()
        {
            List<Certification> certifications = cntxt.Certifications.ToList();
            return certifications;
        }
    }



}
