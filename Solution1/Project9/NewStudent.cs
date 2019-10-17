using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Project9.DataLayer;
using System.Text.RegularExpressions;

namespace Project9
{
    public partial class NewStudent : Form
    {
        public Form Parent { get; set; }

        public NewStudent(Form parent)
        {
            InitializeComponent();
            Parent = parent;
        }

        private void NewStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parent.Enabled = true;
            ((RegisterForm)Parent).UpdateData();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsValid()
        {
            string checker = "([a-z]{0,}:([1-6],){0,}[1-6];){1,}";
                    return Regex.IsMatch(courseTextBox.Text,checker);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                String[] info = Regex.Split(courseTextBox.Text, ";\\s*").Where(s => !String.IsNullOrEmpty(s)).ToArray();
                List<Statistics> statisticsList = new List<Statistics>();
                foreach (var element in info)
                {
                    statisticsList.Add(new Statistics(element));
                }
                Student newStudent = new Student(firstNameTextBox.Text, lastNameTextBox.Text);
                statisticsList.ForEach(s => newStudent.AddStatistic(s));
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}