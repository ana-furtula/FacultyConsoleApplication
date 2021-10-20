using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SQLRepositoryServices
{
    public class SQLStudentRepository : IStudentRepository
    {
        private SQLiteConnection Connection { get; set; }
        private SQLiteCommand Command { get; set; }
        private string TableName { get; set; }

        public SQLStudentRepository()
        {
            Connection = FacultyDB.GetConnection();
            Command = Connection.CreateCommand();
            TableName = "Student";
        }

        public void AddStudent(Student student)
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT Indeks FROM {TableName}";

            dataReader = Command.ExecuteReader();

            while (dataReader.Read())
            {
                string myreader = dataReader.GetString(0);
                if (myreader.Equals(student.Indeks))
                {
                    dataReader.Close();
                    throw new Exception("Student already exists.");
                }
            }
            dataReader.Close();

            Command.CommandText = $"INSERT INTO {TableName} (Id, Indeks, FirstName, LastName, JMBG) VALUES ('{student.Id.ToString()}','{student.Indeks}','{student.FirstName}','{student.LastName}','{student.JMBG}');";
            Command.ExecuteNonQuery();

        }

        public void DeleteStudent(string indeks)
        {
            Command.CommandText = $"DELETE FROM {TableName} WHERE Indeks = '{indeks}'";
            int rows = Command.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("Student is not found!");

        }

        public List<Student> GetAll()
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName}";

            dataReader = Command.ExecuteReader();

            List<Student> students = new List<Student>();

            while (dataReader.Read())
            {
                string id = dataReader.GetString(0);
                string index = dataReader.GetString(1);
                string firstName = dataReader.GetString(2);
                string lastName = dataReader.GetString(3);
                string jmbg = dataReader.GetString(4);

                Student student = new Student(Guid.Parse(id), firstName, lastName, index, jmbg);
                students.Add(student);

            }

            dataReader.Close();

            return students;
        }

        public Student GetStudentByIndex(string indeks)
        {
            Student student = null;

            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName} WHERE Indeks = '{indeks}'";

            dataReader = Command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();

                string id = dataReader.GetString(0);
                string firstName = dataReader.GetString(2);
                string lastName = dataReader.GetString(3);
                string jmbg = dataReader.GetString(4);

                student = new Student(Guid.Parse(id), firstName, lastName, indeks, jmbg);
            }

            dataReader.Close();

            return student;
        }

        public void UpdateStudent(string index, string newFirstName)
        {

            Command.CommandText = $"UPDATE {TableName} SET FirstName = '{newFirstName}' WHERE Indeks = '{index}'";
            int rows = Command.ExecuteNonQuery();
            if (rows == 0) throw new Exception("Student is not found!");

        }
    }
}
