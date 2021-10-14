using System;
using System.Collections.Generic;
using Domain;

namespace FacultyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository.StudentRepository.Instance.Load();
            Repository.ProfessorRepository.Instance.Load();
            Repository.ExamRepository.Instance.Load();
            Repository.ExamRegistrationRepository.Instance.Load();
            bool ind;
            int ans;
            do
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Professors");
                Console.WriteLine("3. Exams");
                Console.WriteLine("4. Exam registrations");
                ind = Int32.TryParse(Console.ReadLine(), out ans);
                if (ind)
                {
                    Console.WriteLine();
                    switch (ans)
                    {
                        case 0:
                            break;
                        case 1:
                            int ans1;
                            do
                            {
                                Console.WriteLine("0. Exit students");
                                Console.WriteLine("1. Create student");
                                Console.WriteLine("2. Read student");
                                Console.WriteLine("3. Update student");
                                Console.WriteLine("4. Delete student");
                                ind = Int32.TryParse(Console.ReadLine(), out ans1);
                                Console.WriteLine();
                                if (ind)
                                {
                                    switch (ans1)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            CreateStudent();
                                            break;
                                        case 2:
                                            ReadStudent();
                                            break;
                                        case 3:
                                            UpdateStudent();
                                            break;
                                        case 4:
                                            DeleteStudent();
                                            break;
                                        default:
                                            Console.WriteLine("Bad request");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid request!");
                                    ans1 = -1;
                                }
                            } while (ans1 != 0);
                            break;
                        case 2:
                            int ans2;
                            do
                            {
                                Console.WriteLine("0. Exit profs");
                                Console.WriteLine("1. Create");
                                Console.WriteLine("2. Read");
                                Console.WriteLine("3. Update");
                                Console.WriteLine("4. Delete");
                                ind = Int32.TryParse(Console.ReadLine(), out ans2);
                                Console.WriteLine();
                                if (ind)
                                {
                                    switch (ans2)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            CreateProf();
                                            break;
                                        case 2:
                                            ReadProf();
                                            break;
                                        case 3:
                                            UpdateProf();
                                            break;
                                        case 4:
                                            DeleteProf();
                                            break;
                                        default:
                                            Console.WriteLine("Bad request");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid request!");
                                    ans2 = -1;
                                }
                            } while (ans2 != 0);
                            break;
                        case 3:
                            int ans3;
                            do
                            {
                                Console.WriteLine("0. Exit exams");
                                Console.WriteLine("1. Create exam");
                                Console.WriteLine("2. Read exam");
                                Console.WriteLine("3. Update exam");
                                Console.WriteLine("4. Delete exam");
                                ind = Int32.TryParse(Console.ReadLine(), out ans3);
                                Console.WriteLine();
                                if (ind)
                                {
                                    switch (ans3)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            CreateExam();
                                            break;
                                        case 2:
                                            ReadExam();
                                            break;
                                        case 3:
                                            UpdateExam();
                                            break;
                                        case 4:
                                            DeleteExam();
                                            break;
                                        default:
                                            Console.WriteLine("Bad request");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid request!");
                                    ans3 = -1;
                                }
                            } while (ans3 != 0);
                            break;
                        case 4:
                            int ans4;
                            do
                            {
                                Console.WriteLine("0. Exit exam registrations");
                                Console.WriteLine("1. Create exam registration");
                                Console.WriteLine("2. Read exam registration");
                                Console.WriteLine("3. Update exam registration");
                                Console.WriteLine("4. Delete exam registration");
                                ind = Int32.TryParse(Console.ReadLine(), out ans4);
                                Console.WriteLine();
                                if (ind)
                                {
                                    switch (ans4)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            CreateExamRegistration();
                                            break;
                                        case 2:
                                            ReadExamRegistration();
                                            break;
                                        case 3:
                                            UpdateExamRegistration();
                                            break;
                                        case 4:
                                            DeleteExamRegistration();
                                            break;
                                        default:
                                            Console.WriteLine("Bad request");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid request!");
                                    ans3 = -1;
                                }
                            } while (ans4 != 0);
                            break;
                        default:
                            Console.WriteLine("Bad request");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid request!");
                    ans = -1;
                }
            } while (ans != 0);
        }

        private static void DeleteExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter exam code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine();
            try
            {
                Repository.ExamRegistrationRepository.Instance.Delete(index, code, date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine("Enter new grade: ");
            int newGrade;
            ind = Int32.TryParse(Console.ReadLine(), out newGrade);
            if (!ind)
            {
                Console.WriteLine("Invalid grade input.");
                return;
            }
            Console.WriteLine();
            try
            {
                Repository.ExamRegistrationRepository.Instance.Update(index, code, date, newGrade);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine();
            ExamRegistration er = Repository.ExamRegistrationRepository.Instance.GetERByCredentials(index, code, date);
            if (er != null) Console.WriteLine(er.ToString());
            else Console.WriteLine("Exam not found!");
            Console.WriteLine();
        }

        private static void CreateExamRegistration()
        {
            Console.WriteLine("Enter index: ");
            string index = Console.ReadLine();
            Console.WriteLine("Enter exam code: ");
            string examCode = Console.ReadLine();
            Console.WriteLine("Enter date (1/1/2021) : ");
            DateTime date;
            bool ind = DateTime.TryParse(Console.ReadLine(), out date);
            if (!ind)
            {
                Console.WriteLine("Invalid date input.");
                return;
            }
            Console.WriteLine("Enter grade: ");
            int grade;
            ind = Int32.TryParse(Console.ReadLine(), out grade);
            if (!ind)
            {
                Console.WriteLine("Invalid grade input.");
                return;
            }
            Console.WriteLine("Enter professor code: ");
            string profCode = Console.ReadLine();
            try
            {
                Repository.ExamRegistrationRepository.Instance.Add(index, examCode, date, grade, profCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteExam()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Repository.ExamRepository.Instance.Delete(code);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateExam()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter new code: ");
            string newCode = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Repository.ExamRepository.Instance.Update(code, newCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadExam()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine();
            Exam exam = Repository.ExamRepository.Instance.GetExamByCredentials(code);
            if (exam != null) Console.WriteLine(exam.ToString());
            else Console.WriteLine("Exam not found!");
            Console.WriteLine();
        }

        private static void CreateExam()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter espb: ");
            int espb;
            bool ind = Int32.TryParse(Console.ReadLine(), out espb);
            if (!ind)
            {
                Console.WriteLine("Input is not valid.");
                return;
            }
            try
            {
                Repository.ExamRepository.Instance.Add(code, name, espb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteProf()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Repository.ProfessorRepository.Instance.Delete(code);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateProf()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter new code: ");
            string newCode = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Repository.ProfessorRepository.Instance.Update(code, newCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void ReadProf()
        {
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            Console.WriteLine();
            Professor prof = Repository.ProfessorRepository.Instance.GetProfByCredentials(code);
            if (prof != null) Console.WriteLine(prof.ToString());
            else Console.WriteLine("Professor not found!");
            Console.WriteLine();
        }

        private static void CreateProf()
        {
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter code: ");
            string code = Console.ReadLine();
            try
            {
                Repository.ProfessorRepository.Instance.Add(firstName, lastName, code);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CreateStudent()
        {
            try
            {
                Console.WriteLine("Enter first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter index: ");
                string indeks = Console.ReadLine();
                Repository.StudentRepository.Instance.Add(firstName, lastName, indeks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ReadStudent()
        {
            Console.WriteLine("Enter index: ");
            string indeks = Console.ReadLine();
            Console.WriteLine();
            if (!Validation.IndexValidation(indeks))
            {
                Console.WriteLine("Invalid index input.");
                return;
            }
            Student s = Repository.StudentRepository.Instance.GetStudentByIndex(indeks);
            if (s != null) Console.WriteLine(s.ToString());
            else Console.WriteLine("Student not found!");
            Console.WriteLine();
        }

        static void UpdateStudent()
        {
            Console.WriteLine("Enter old index: ");
            string oldIndeks = Console.ReadLine();
            if (!Validation.IndexValidation(oldIndeks))
            {
                Console.WriteLine("Invalid index input.");
                return;
            }
            Console.WriteLine("Enter new index: ");
            string newIndeks = Console.ReadLine();
            if (!Validation.IndexValidation(newIndeks))
            {
                Console.WriteLine("Invalid index input.");
                return;
            }
            Console.WriteLine();
            try
            {
                Repository.StudentRepository.Instance.Update(oldIndeks, newIndeks);
                Repository.StudentRepository.Instance.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void DeleteStudent()
        {
            Console.WriteLine("Enter index: ");
            string indeks = Console.ReadLine();
            if (!Validation.IndexValidation(indeks))
            {
                Console.WriteLine("Invalid index input.");
                return;
            }
            Console.WriteLine();
            try
            {
                Repository.StudentRepository.Instance.Delete(indeks);
                Repository.StudentRepository.Instance.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
