using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorTagHelpersNetCore.Pages
{
    public enum Seniority
    {
        None = 0,
        Junior = 1,
        Middle = 2,
        Senior = 3
    }
    public class QuestionAndAnswers {
        public string Question { get; set; }
        public Dictionary<int, string> Answers { get; set; }
    }
    public class CapturingUseInputModel : PageModel
    {
        [BindProperty]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [BindProperty] // attribute preserve data between form postbacks
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Display(Name = "Has Photo")]
        public bool HasPhoto { get; set; }

        [Display(Name = "Seniority")]
        public Seniority SeniorityEnum { get; set; }

        #region Dates and Times
        // manage date and time, just the date or time, or month, or week of the year.
        [Display(Name = "Birthday date")]
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [BindProperty, DataType(DataType.Time)]
        public DateTime BirthTime { get; set; }
        [BindProperty, DataType("month")]
        public DateTime BirthMonth { get; set; }
        [BindProperty, DataType("week")]
        public DateTime BirthWeek { get; set; }
        #endregion

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        #region Radio buttons
        public string Question1 { get; set; }
        public int Question1Answer { get; set; }
        public Dictionary<int, string> Question1Answers { get; set; }
        #endregion

        [Display(Name = "Choose color")]
        public string ColorCode { get; set; }

        public void OnGet()
        {
            var q1 = GetQuestion1();
            SetModelProps(q1);
            SetModelDefaultValues(q1);
        }

        public void OnPost(string firstName, bool hasPhoto, string notes
            , int question1Answer
            , string colorCode)
        {
            var _firstName = firstName; // posted-value, null if string value is empty
            _firstName = FirstName; // null if attribute [BindProperty] not applied
            _firstName = Request.Form["FirstName"]; // posted-value

            var _hasPhoto = hasPhoto;

            var q1 = GetQuestion1();
            SetModelProps(q1);
            string answerText = Question1Answers[question1Answer];

            var _colorCode = colorCode;

            var _dateOfBirth = DateOfBirth;
            var _birthDate = BirthDate.Date;
            var _birthTime = BirthTime.TimeOfDay;
            var _birthMonth = BirthMonth.Month;
            // the default DateTimeModelBinder is unable to bind Week DataType value back to a DateTime
            var week = Request.Form["BirthWeek"].First().Split("-W");
            var _birthWeek = System.Globalization.ISOWeek.ToDateTime(Convert.ToInt32(week[0]), Convert.ToInt32(week[1]), DayOfWeek.Monday);
        }

        private QuestionAndAnswers GetQuestion1() { 
            return new QuestionAndAnswers()
            {
                Question = "How long are you in profesion?",
                Answers = new Dictionary<int, string> {
                    { 1, "Less than 1 year" },
                    { 2, "Less than 2 year" },
                    { 3, "Less than 3 year" }
                }
            };
        }
        private void SetModelProps(QuestionAndAnswers q1) {
            Question1 = q1.Question;
            Question1Answers = q1.Answers;
        }
        private void SetModelDefaultValues(QuestionAndAnswers q1) {
            Question1Answer = q1.Answers.First().Key;

            //var dt = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);
            //var isoDateString = dt.ToString("O");
            DateOfBirth = DateTime.Now;
            BirthDate = DateTime.Now;
            BirthTime = DateTime.Now;
            BirthMonth = DateTime.Now;
            BirthWeek = DateTime.Now;
        }
    }
}