using System;
namespace Project10.Views
{
    public partial class MainView : NavigableUserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
        private void rentalButton_Click(object sender, EventArgs e)
        {
            Owner.SetView(new RentingView());
        }
        private void controlPanleButton_Click(object sender, EventArgs e)
        {
            Owner.SetView(new ControlPanelView());
        }
    }
}