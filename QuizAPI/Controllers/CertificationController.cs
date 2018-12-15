using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class CertificationController : Controller
    {
        // GET: Certification
        public ActionResult Index()
        {
            return View();
        }
        [Route("Certification/SamplePMPQuestion")]
        [Route("Free-Sample-PMP-Questions-PMBOK6")]
        public ActionResult SamplePMPQuestion()
        {
            ViewBag.Title = "Sample PMP Questions Based on PMBOK6";
            ViewBag.MetaDescription = "Free Sample PMP Questions Based on PMBOK6 ,PmBook Edition 6 PMP Questions ";
            ViewBag.MetaKeywords = "Free PmBook6 Sample Questions,Sample PMP Questions ";


            return View();
        }



        public ActionResult MicrosoftCertifications()
        {
            return View();
        }

        public ActionResult MCSDQuestions()
        {
            return View();
        }
        [Route("Certification/MCSD70480HtmlandJavascript")]
        [Route("Free-MCSD-70-480-Html-and-Javascript-Sample Questions")]
        public ActionResult MCSD70480HtmlandJavascript()
        {

            ViewBag.Title = "Free 70-480 Exam Questions and Answers";
            ViewBag.MetaDescription = "Get  real exam questions for 70-480 Programming in HTML5 with JavaScript and CSS3. Access online the  get ready for the test. ";
            ViewBag.MetaKeywords = "MCSD -70-480 Questions,Free Mirosoft certification Questions, ";



            return View();
        }

    }
}