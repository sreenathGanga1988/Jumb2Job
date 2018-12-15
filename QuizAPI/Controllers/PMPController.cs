using QuizAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

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

        public List<QuestionViewModel> GetQuestion(int certificationId = 0, int languageID = 0, int Number = 0)
        {
            return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionQuestion(Number, certificationId, languageID);
        }




        public List<QuestionViewModel> GetQuestionofKnowledgeArea(int certificationId = 0, int languageID = 0, int knowledgeAeadid = 0, int Number = 0)
        {
            return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionQuestion(Number, certificationId, languageID);
        }


        public List<QuestionViewModel> GetSingleQuestion(int QuestionID = 0)
        {
            return QuizAPI.Repository.QuestionRepository.GetSingleQuestion(QuestionID);
        }




        public List<QuestionViewModel> Post(List<QuestionViewModel> answerSheet)
        {
            foreach (QuestionViewModel qvmodel in answerSheet)
            {
                var question = QuizAPI.Repository.QuestionRepository.GetQuestion(qvmodel.QuestionId);

                qvmodel.CorrectAnswer = question.CorrectAnswerIndex;


                if (qvmodel.UserAnswer.Trim() == "")
                {
                    qvmodel.isCorrect = "S";
                }
                else
                {
                    if (qvmodel.UserAnswer.Trim() == qvmodel.CorrectAnswer.Trim())
                    {
                        qvmodel.isCorrect = "Y";
                    }
                    else
                    {
                        qvmodel.isCorrect = "N";

                    }
                }


            }

            return answerSheet;
        }












    }
}
