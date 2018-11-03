using QuizAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizAPI.Controllers
{
    public class PMPController : ApiController
    {
        public List<QuestionViewModel> Get()
        {

            //List<string> List = new List<string>();
            //List.Add("sourav kayal");
            //List.Add("Ajay Joshi");
            //List.Add("Nontey Banerjee");
            //return List;
            
return QuizAPI.Repository.QuestionRepository.GetQuestion();
        }
        [HttpGet]
        public List<QuestionViewModel> Get(int CertificationId,int LanguageId=0)
        {
            return QuizAPI.Repository.QuestionRepository.GetQuestionofExamofLanguage(CertificationId, LanguageId);
        }











        public List<QuestionViewModel> Post(List<QuestionViewModel> answerSheet)
        {
            foreach (QuestionViewModel qvmodel in answerSheet)
            {
                var question = QuizAPI.Repository.QuestionRepository.GetQuestion(qvmodel.QuestionId);

                qvmodel.CorrectAnswer = question.CorrectAnswerIndex;


                if (qvmodel.UserAnswer == qvmodel.CorrectAnswer)
                {
                    qvmodel.isCorrect = "Y";
                }
                else
                {
                    qvmodel.isCorrect = "N";

                }
            }

            return answerSheet;
        }
    }
}
