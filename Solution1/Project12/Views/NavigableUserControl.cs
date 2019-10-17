using System.Windows.Forms;
namespace Project10.Views
{
    public partial class NavigableUserControl : UserControl
    {
        public ToolbarForm Owner { get; set; }
        public NavigableUserControl Previous { get; set; }
        public NavigableUserControl()
        {
            InitializeComponent();
        }
    }
}