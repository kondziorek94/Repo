using System;
using System.Windows.Forms;
using Project9.DataLayer;

namespace Project9
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            listOfStudentsBox.DataSource = ObjectPlus.Objects[typeof(Student)];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void listOfStudentsBox_Format(object sender, ListControlConvertEventArgs e)
        {
            //w e.value jest przetrzymywany obiekt ktory bedzie prezentowany przez liste,
            //jezeli zrobisz e.value = null; to lista nie zapomni obiektow tylko  wyswietli nulle
            //ta wlasciwosc jest uzywana tylko na poczet prezentacji danych, nie zepsujesz danych pod spodem jezeli wpiszesz tu null

            Student currentstudent = (Student)e.Value;
            e.Value = currentstudent.FirstName + " " + currentstudent.LastName;
        }

        private void listOfStudentsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            descriptionTextBox.Text = listOfStudentsBox.SelectedItem + "";
        }

        public void UpdateData()
        {
            listOfStudentsBox.DataSource = null;
            listOfStudentsBox.DataSource = ObjectPlus.Objects[typeof(Student)];
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            NewStudent newStudentButton = new NewStudent(this);
            newStudentButton.Show();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
        }
    }
}