namespace Project10.Views
{
    public partial class MainForm : ToolbarForm
    {
        public MainForm()
        {
            InitializeComponent();
            SetView(new LoginView());
        }
    }
}