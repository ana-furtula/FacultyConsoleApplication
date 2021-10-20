using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQLRepositoryServices
{
    public class SQLSubjectRepository : ISubjectRepository
    {
        private SQLiteConnection Connection { get; set; }
        private SQLiteCommand Command { get; set; }
        public string TableName { get; set; }

        public SQLSubjectRepository()
        {
            Connection = FacultyDB.GetConnection();
            Command = Connection.CreateCommand();
            TableName = "Subject";
        }

        public void Add(Subject subject)
        {

            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT Name FROM {TableName}";

            dataReader = Command.ExecuteReader();

            while (dataReader.Read())
            {
                string name = dataReader.GetString(0);

                if (name.Equals(subject.Name))
                {
                    dataReader.Close();
                    throw new Exception("Subject already exists.");
                }
            }
            dataReader.Close();

            Command.CommandText = $"INSERT INTO {TableName} (Id, Name, Semester, ESPB) VALUES ('{subject.Id.ToString()}','{subject.Name}','{subject.Semester}','{subject.ESPB}');";
            Command.ExecuteNonQuery();

        }

        public void Update(string name, string newName)
        {
            Command.CommandText = $"UPDATE {TableName} SET Name = '{newName}' WHERE Name = '{name}'";
            int rows = Command.ExecuteNonQuery();
            if (rows == 0) throw new Exception("Subject is not found!");
        }

        public void Delete(string name)
        {
            Command.CommandText = $"DELETE FROM {TableName} WHERE Name = '{name}'";
            int rows = Command.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("Subject is not found!");
        }

        public Subject GetSubjectByCredentials(string name)
        {
            Subject subject = null;

            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName} WHERE Name = '{name}'";

            dataReader = Command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();

                string id = dataReader.GetString(0);
                int espb = dataReader.GetInt32(2);
                int semester = dataReader.GetInt32(3);

                subject = new Subject(Guid.Parse(id), name, espb, semester);
            }

            dataReader.Close();

            return subject;
        }

        public List<Subject> GetAll()
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName}";

            dataReader = Command.ExecuteReader();

            List<Subject> subjects = new List<Subject>();

            while (dataReader.Read())
            {
                string id = dataReader.GetString(0);
                string name = dataReader.GetString(1);
                int espb = dataReader.GetInt32(2);
                int semester = dataReader.GetInt32(3);

                Subject subject = new Subject(Guid.Parse(id), name, espb, semester);
                subjects.Add(subject);

            }

            dataReader.Close();

            return subjects;
        }

        public bool Exists(Subject subject)
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName} WHERE Name = '{subject.Name}'";
            dataReader = Command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Close();
                return true;
            }

            dataReader.Close();
            return false;
        }
    }
}
