using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace SQLRepositoryServices
{
    internal class FacultyDB
    {

        public static SQLiteConnection GetConnection()
        {

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), $"FacultyDB.sqlite");
            string connectionString = $"data source={databasePath}";

            bool ind = File.Exists(databasePath);

            if (!ind)
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();

            if (!ind)
                CreateTables(conn.CreateCommand());

            return conn;

        }

        private static void CreateTables(SQLiteCommand cmd)
        {
            cmd.CommandText = @"CREATE TABLE Student (ID TEXT NOT NULL, Indeks TEXT NOT NULL, FirstName TEXT NOT NULL, 
                                LastName TEXT NOT NULL, JMBG TEXT NOT NULL, PRIMARY KEY('Id'));";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Professor (ID TEXT NOT NULL, FirstName TEXT NOT NULL, 
                                LastName TEXT NOT NULL, JMBG TEXT NOT NULL, PRIMARY KEY('Id'));";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE Subject (ID TEXT NOT NULL, Name TEXT NOT NULL,
                                 ESPB INT NOT NULL, Semester INT NOT NULL, PRIMARY KEY('Id'));";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE ExamRegistration (ID TEXT NOT NULL, Indeks TEXT NOT NULL, SubjectID TEXT NOT NULL,
                                 Date TEXT NOT NULL, Grade INT, ProfessorID TEXT, IsLocked INT NOT NULL, 
                                 PRIMARY KEY('Indeks', 'SubjectId', 'Date'), 
                                 FOREIGN KEY(ProfessorID) REFERENCES Professor(Id));";
            cmd.ExecuteNonQuery();


    }
    }
}
