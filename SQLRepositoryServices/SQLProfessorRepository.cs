using Domain;
using RepositoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQLRepositoryServices
{
    public class SQLProfessorRepository : IProfessorRepository
    {
        private SQLiteConnection Connection { get; set; }
        private SQLiteCommand Command { get; set; }
        private string TableName { get; set; }

        public SQLProfessorRepository()
        {
            Connection = FacultyDB.GetConnection();
            Command = Connection.CreateCommand();
            TableName = "Professor";
        }

        public void AddProfessor(Professor professor)
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT JMBG FROM {TableName}";

            dataReader = Command.ExecuteReader();

            while (dataReader.Read())
            {
                string myreader = dataReader.GetString(0);
                if (myreader.Equals(professor.JMBG))
                {
                    dataReader.Close();
                    throw new Exception("Professor already exists.");
                }
            }
            dataReader.Close();

            Command.CommandText = $"INSERT INTO {TableName} (Id, FirstName, LastName, JMBG) VALUES ('{professor.Id.ToString()}','{professor.FirstName}','{professor.LastName}','{professor.JMBG}');";
            Command.ExecuteNonQuery();
        }

        public void DeleteProfessor(string jmbg)
        {
            Command.CommandText = $"DELETE FROM {TableName} WHERE JMBG = '{jmbg}'";
            int rows = Command.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("Professor is not found!");
        }

        public List<Professor> GetAll()
        {
            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName}";

            dataReader = Command.ExecuteReader();

            List<Professor> professors = new List<Professor>();

            while (dataReader.Read())
            {
                string id = dataReader.GetString(0);
                string firstName = dataReader.GetString(1);
                string lastName = dataReader.GetString(2);
                string jmbg = dataReader.GetString(3);

                Professor professor = new Professor(Guid.Parse(id), firstName, lastName, jmbg);
                professors.Add(professor);

            }

            dataReader.Close();

            return professors;
        }

        public Professor GetProfByCredentials(string jmbg)
        {
            Professor professor = null;

            SQLiteDataReader dataReader;

            Command.CommandText = $"SELECT * FROM {TableName} WHERE JMBG = '{jmbg}'";

            dataReader = Command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();

                string id = dataReader.GetString(0);
                string firstName = dataReader.GetString(1);
                string lastName = dataReader.GetString(2);

                professor = new Professor(Guid.Parse(id), firstName, lastName, jmbg);
            }

            dataReader.Close();

            return professor;
        }

        public void UpdateProfessor(string jmbg, string newFirstName)
        {
            Command.CommandText = $"UPDATE {TableName} SET FirstName = '{newFirstName}' WHERE JMBG = '{jmbg}'";
            int rows = Command.ExecuteNonQuery();
            if (rows == 0) throw new Exception("Professor is not found!");
        }
    }
}
