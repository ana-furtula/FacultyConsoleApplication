using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
    public class ExamRegistration
    {
        public Guid Id { get; }
        public string Index { get; set; }
        public Guid SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int? Grade { get; set; }
        public Guid? ProfId { get; set; }
        public bool IsLocked { get; set; }

        public ExamRegistration(string index, Guid subjectId, DateTime date, int? grade, Guid? profId)
        {
            if (grade.HasValue && profId.HasValue)
            {
                IsLocked = true;
                if (!Validation.GradeValidation(grade.Value))
                    throw new Exception("Invalid grade.");
            }
            else
            {
                IsLocked = false;
            }

            if (!Validation.IndexValidation(index))
                throw new Exception("Invalid index");

            Id = Guid.NewGuid();
            Index = index;
            Grade = grade;
            SubjectId = subjectId;
            Date = date;
            ProfId = profId;

        }

        public ExamRegistration(Guid id, string index, Guid subjectId, DateTime date, int? grade, Guid? profId) : this(index, subjectId, date, grade, profId)
        {
            Id = id;
        }

        public override string ToString()
        {
            if (IsLocked)
                return $"{Index} {SubjectId} {Date.Date} {Grade} {ProfId}";
            else
                return $"{Index} {SubjectId} {Date.Date}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ExamRegistration er)
            {
                return Index.Equals(er.Index) && SubjectId.Equals(er.SubjectId) && Date.Date == er.Date.Date;
            }
            return false;
        }
    }
}
