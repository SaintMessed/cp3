using Bogus;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;


namespace ExceptionForm
{
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
        }
     public class AgeRestrictionException : Exception
    {
        public AgeRestrictionException(string message) : base(message) { }
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var faker = new Faker<User>()
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Age, f => f.Random.Int(10, 30));

            var users = faker.Generate(10);

            using var connection = new SqliteConnection("Data Source=users.db");
            connection.Open();

            var createCmd = connection.CreateCommand();
            createCmd.CommandText =
            @"CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT,
                Email TEXT,
                Age INTEGER
            );";
            createCmd.ExecuteNonQuery();

            foreach (var user in users)
            {
                try
                {
                    InsertUser(user, connection);
                    listBox1.Items.Add($"Добавлен: {user.Name} ({user.Age})");
                }
                catch (AgeRestrictionException ex)
                {
                    listBox1.Items.Add($"Ошибка: {ex.Message}");
                }
            }
        }
        private void InsertUser(User user, SqliteConnection connection)
        {
            if (user.Age < 14)
                throw new AgeRestrictionException($"Пользователь {user.Name} младше 14 лет!");

            var cmd = connection.CreateCommand();
            cmd.CommandText =
            @"INSERT INTO Users (Name, Email, Age)
              VALUES ($name, $email, $age);";

            cmd.Parameters.AddWithValue("$name", user.Name);
            cmd.Parameters.AddWithValue("$email", user.Email);
            cmd.Parameters.AddWithValue("$age", user.Age);

            cmd.ExecuteNonQuery();
        }
    }
}