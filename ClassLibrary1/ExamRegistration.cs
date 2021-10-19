using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
    public class ExamRegistration
    {
        public string Indeks { get; set; }
        public string ExamCode { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
        public string ProfCode { get; set; }

        public ExamRegistration(string indeks, string examCode, DateTime date, int grade, string profCode)
        {
            Validation.GradeValidation(grade);
            Validation.IndexValidation(indeks);
            Indeks = indeks;
            Grade = grade;
            ExamCode = examCode;
            Date = date;
            ProfCode = profCode; 
        }

        public override string ToString()
        {
            return $"{Indeks} {ExamCode} {Date.Date} {Grade} {ProfCode}";
        }

        public override bool Equals(object obj)
        {
            if(obj is ExamRegistration er)
            {
                return Indeks.Equals(er.Indeks) && ExamCode.Equals(er.ExamCode) && Date.Date == er.Date.Date;
            }
            return false;
        }
    }
}
