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
            if (grade >= 5 && grade <= 10) Grade = grade;
            else throw new Exception("Invalid grade!");
            Regex rx = new Regex("[0-9]+/[0-9]+");
            if (rx.IsMatch(indeks)) Indeks = indeks;
            else throw new Exception("Index is not valid!");
            ExamCode = examCode;
            Date = date;
            ProfCode = profCode; 
        }

        public override string ToString()
        {
            return $"{Indeks} {ExamCode} {Date.Date} {Grade} {ProfCode}";
        }
    }
}
