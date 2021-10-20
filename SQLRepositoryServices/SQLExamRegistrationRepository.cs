using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQLRepositoryServices
{
    public class SQLExamRegistrationRepository : IExamRegistrationRepository
    {
        private SQLiteConnection Connection { get; set; }
        private SQLiteCommand Command { get; set; }
        private string TableName { get; set; }

        public SQLExamRegistrationRepository()
        {
            Connection = FacultyDB.GetConnection();
            Command = Connection.CreateCommand();
            TableName = "ExamRegistration";
        }

        public void Add(ExamRegistration examRegistration)
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT Indeks, SubjectId, Date FROM {TableName}";

            dataReader = Command.ExecuteReader();

            while (dataReader.Read())
            {
                string indeks = dataReader.GetString(0);
                Guid subjectId = Guid.Parse(dataReader.GetString(1));
                DateTime date = DateTime.Parse(dataReader.GetString(2));

                if (indeks.Equals(examRegistration.Index) && subjectId == examRegistration.SubjectId && date == examRegistration.Date)
                {
                    dataReader.Close();
                    throw new Exception("Exam registration already exists.");
                }
            }
            dataReader.Close();

            Command.CommandText = $"INSERT INTO {TableName} (Id, Indeks, SubjectID, Date, IsLocked) " +
                $"VALUES ('{examRegistration.Id.ToString()}','{examRegistration.Index}'," +
                $"'{examRegistration.SubjectId.ToString()}','{examRegistration.Date.ToString()}', 0);";
            Command.ExecuteNonQuery();
        }

        public void Delete(string index, Guid subjectId, DateTime date)
        {
            Command.CommandText = $"DELETE FROM {TableName} WHERE Indeks = '{index}' and SubjectID = '{subjectId.ToString()}' " +
                $"and Date = '{date.ToString()}' and IsLocked = 0";

            int rows = Command.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("Exam registration is not found or cannot be changed!");

        }

        public List<ExamRegistration> GetAll()
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT Id, Indeks, SubjectId, Date, Grade, ProfessorId FROM {TableName}";

            dataReader = Command.ExecuteReader();

            List<ExamRegistration> ers = new List<ExamRegistration>();

            while (dataReader.Read())
            {
                int? grade;
                Guid? professorId;

                if (dataReader.IsDBNull(4))
                    grade = null;
                else
                    grade = dataReader.GetInt32(4);

                if (dataReader.IsDBNull(5))
                    professorId = null;
                else
                    professorId = Guid.Parse(dataReader.GetString(5));

                Guid id = Guid.Parse(dataReader.GetString(0));
                string index = dataReader.GetString(1);
                Guid subjectId = Guid.Parse(dataReader.GetString(2));
                DateTime date = DateTime.Parse(dataReader.GetString(3));

                ExamRegistration er = new ExamRegistration(id, index, subjectId, date, grade, professorId);
                ers.Add(er);

            }

            dataReader.Close();

            return ers;
        }

        public ExamRegistration GetERByCredentials(string index, Guid subjectId, DateTime date)
        {
            ExamRegistration examRegistration = null;

            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT Id, Grade, ProfessorId FROM {TableName} WHERE Indeks = '{index}'" +
                $" AND SubjectID = '{subjectId}' AND Date = '{date}'";

            dataReader = Command.ExecuteReader();

            if (dataReader.HasRows)
            {
                int? grade;
                Guid? professorId;

                dataReader.Read();

                if (dataReader.IsDBNull(1))
                    grade = null;
                else
                    grade = dataReader.GetInt32(1);

                if (dataReader.IsDBNull(2))
                    professorId = null;
                else
                    professorId = Guid.Parse(dataReader.GetString(2));

                Guid id = Guid.Parse(dataReader.GetString(0));

                examRegistration = new ExamRegistration(id, index, subjectId, date, grade, professorId);
            }

            dataReader.Close();

            return examRegistration;
        }

        public void Update(string index, Guid subjectId, DateTime date, int grade, Guid professorId)
        {
            Command.CommandText = $"UPDATE {TableName} SET Grade = '{grade}', ProfessorID = '{professorId}', IsLocked = 1 WHERE Indeks = '{index}'" +
                $" AND SubjectID = '{subjectId}' AND Date = '{date}' AND IsLocked = 0";

            int rows = Command.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("Exam registration is not found or cannot be changed!");
        }
    }
}
