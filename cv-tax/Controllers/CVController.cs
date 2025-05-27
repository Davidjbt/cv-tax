using cv_tax.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cv_tax.Controllers {

    public class CVController : Controller {

        private readonly static CVModel cv = new CVModel(
                profile: "Despite being a Robotics Engineering student, Software Engineering has always been my passion." +
                " I am highly procient in\r\nJava, self-taught Back-end Development with Spring," +
                " and experienced in Python for diverse tasks. Additionally, I learnt\r\nother languages and technologies," +
                " including C, Kotlin, and Angular. I aim to leverage my robotics background and\r\ntechnical skills to" +
                " make a meaningful impact as a Software Engineer.\r\n",
                projects: [
                    "Caterest\r\n" +
                    "I am developing an Instagram-like application, to practise and improve my development skills.\r\n" +
                    "● Using Spring Boot to develop the back-end application, the REST APIs handle GET and POST requests\r\n" +
                    "and interact with a local MySQL database to achieve the user requests.\r\n" +
                    "● Utilising Angular to produce a basic website to interact with the backend application, users can register,\r\n" +
                    "login, post pictures, and search other users.\r\n" +
                    "● Implementing authentication with JWT to prevent unauthorised access to endpoints.\r\n",
                    "QMUL Room Timetable\r\n" +
                    "Facilitate finding rooms within QMUL by fetching their timetables.\r\n" +
                    "● Developed an Android application, with Kotlin, able to web scrape the room timetables, indicated by the\r\n" +
                    "user queries, from the university’s website.\r\n" +
                    "● Utilised Kotlin multithreading capabilities to web scrape multiple room timetables simultaneously.\r\n" +
                    "● Implemented Google’s Protocol Buffers and Proto Datastore for efficient storage, retrieval, and\r\n" +
                    "organisation of user queries.\r\n"
                ],
                education: [
                    "Queen Mary, University of London Sep 2021–May 2024\r\n" +
                    "BEng Robotics Engineering\r\n" +
                    "● Graduated with a First Class\r\n" +
                    "● Worked in a group to design and develop a Myoelectric Prosthetic Hand with Tactile Sensing and Haptic\r\n" +
                    "Feedback, for my final year project.\r\n" +
                    "● Won Best Robotics Engineering Project in Industrial Liaison Forum"
                ],
                courses: [
                    "● Java 17 Masterclass: Start Coding in 2024, Udemy | Jul, 2021\r\n" +
                    "● Spring Framework 5: Beginner to Guru, Udemy | Nov, 2021\r\n" +
                    "● Supervised Machine Learning: Regression and Classification, Coursera | Jul, 2023"
                ]
            );

        public IActionResult Index() {
            return View(cv);
        }

        /// <summary>
        /// Gets CV
        /// </summary>
        /// <returns>A CV</returns>
        /// <response code="200">Returns the CV</response>
        [HttpGet]
        [Route("api/v1/cv")]
        [ProducesResponseType(typeof(CVModel), StatusCodes.Status200OK)]
        public IActionResult GetCV() {
            return Ok(cv);
        }
    }


}
