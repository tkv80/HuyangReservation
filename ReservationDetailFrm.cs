using System.Windows.Forms;

namespace HuyangReservation
{
    public partial class ReservationDetailFrm : Form
    {
        public ReservationDetailFrm()
        {
            InitializeComponent();
            cbLodgeTime.Items.Add(new {Value = 1, Text = "1박2일"});
            cbLodgeTime.Items.Add(new {Value = 2, Text = "2박3일"});
            cbLodgeTime.Items.Add(new {Value = 3, Text = "3박4일"});
        }
    }
}