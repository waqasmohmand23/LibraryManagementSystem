using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Library_management_system
{
    public static class DataManager
    {
        private const string USERS_FILE = "users.json";
        private const string BOOKS_FILE = "books.json";



        public static List<Issue> Issues { get; set; } = new List<Issue>();
        private const string ISSUES_FILE = "issues.json";

        public static void LoadData()
        {
            try
            {
                if (File.Exists(USERS_FILE))
                {
                    string json = File.ReadAllText(USERS_FILE);
                    Users = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }

            try
            {
                if (File.Exists(BOOKS_FILE))
                {
                    string json = File.ReadAllText(BOOKS_FILE);
                    Books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}");
            }

            try
            {
                if (File.Exists(STUDENTS_FILE))
                {
                    string json = File.ReadAllText(STUDENTS_FILE);
                    Students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }

            try
            {
                if (File.Exists(ISSUES_FILE))
                {
                    string json = File.ReadAllText(ISSUES_FILE);
                    Issues = JsonSerializer.Deserialize<List<Issue>>(json) ?? new List<Issue>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading issues: {ex.Message}");
            }
        }

        public static void SaveUsers()
        {
            try
            {
                string json = JsonSerializer.Serialize(Users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(USERS_FILE, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving users: {ex.Message}");
            }
        }

        public static void SaveBooks()
        {
            try
            {
                string json = JsonSerializer.Serialize(Books, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(BOOKS_FILE, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving books: {ex.Message}");
            }
        }

        public static void SaveStudents()
        {
            try
            {
                string json = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(STUDENTS_FILE, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving students: {ex.Message}");
            }
        }

        public static void SaveIssues()
        {
            try
            {
                string json = JsonSerializer.Serialize(Issues, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ISSUES_FILE, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving issues: {ex.Message}");
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long Price { get; set; }
        public long Quantity { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public string EnrollmentNo { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }

    public class Issue
    {
        public string StudentEnrollment { get; set; }
        public string StudentName { get; set; }
        public string StudentDepartment { get; set; }
        public string StudentContact { get; set; }
        public string StudentEmail { get; set; }
        public string BookName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
