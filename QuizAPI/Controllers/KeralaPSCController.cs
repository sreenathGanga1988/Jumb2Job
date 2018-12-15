using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class KeralaPSCController : Controller
    {
        // GET: KeralaPSC
        public ActionResult Index()
        {
            ViewBag.Heading = "Free PSC Training Online ";
            return View();
        }
        [Route("KeralaPSC/EnglishPSCQuestions")]
        [Route("Free-English-PSC-Questions")]
        public ActionResult EnglishPSCQuestions()
        {

            ViewBag.Heading = "Free English PSC Questions ";
            ViewBag.Title = "Sample General Knowledge English PSC Questions ,Previous PSC Questions  ";
            ViewBag.MetaDescription = "Study Kerala PSC online in English,Practise  Malayalam English PSC Questions,General Knowledge Question in English Kerala PSC GK Questions and Answers . View PSC Questions and answers for Kerala PSC Exams, UPSC Exams, Secretariat Assistant Exams, LGS Exams LDC Exams";
            ViewBag.MetaKeywords = "Free English General Knowledge,Kerala PSC Questions,Practise GK Questions ";
            return View();


        }
        [Route("KeralaPSC/PSCMalayalamQuestions")]
        [Route("Free-Malayalam-PSC-Questions")]
        public ActionResult PSCMalayalamQuestions()
        {
            ViewBag.Heading = "Free  Malayalam PSC Questions";
            ViewBag.Title = "Sample PSC General Knowledge Questions in  Malayalam,Study PSC Online";
            ViewBag.MetaDescription = "Study Kerala PSC online in Malayalam,Practise Malayalam Kerala PSC Questions,General Knowledge Question in Malayalam";
            ViewBag.MetaKeywords = "Free Malayalam General Knowledge,Best Kerala PSC Questions,Practise GK Questions in Malayalam";
            return View();
        }



        [Route("KeralaPSC/OnlineMalayalamPSCTest")]
        [Route("Online-Malayalam-PSC-Test")]
        public ActionResult OnlineMalayalamPSCTest()
        {
            ViewBag.Heading = "Free Online Malayalam PSC Mock Exam";
            ViewBag.Title = "Online Malyalam PSC Test";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 50 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            return View();
        }
        [Route("KeralaPSC/OnlineEnglishPSCTest")]
        [Route("Online-English-PSC-Test")]
        public ActionResult OnlineEnglishPSCTest()
        {
            ViewBag.Heading = "Free Online Malayalam PSC Mock Exam";
            ViewBag.Title = "Online English PSC Test";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 50 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            return View();
        }



        [Route("KeralaPSC/KeralaPSCUniversityAssistantTest")]
        [Route("Online-PSC-University-Assistant-Exam")]
        public ActionResult KeralaPSCUniversityAssistantTest()
        {
            ViewBag.Heading = "Online PSC University Assistant PSC Mock Exam";
            ViewBag.Title = "Online English PSC Test";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 50 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            return View();
        }
    }
}