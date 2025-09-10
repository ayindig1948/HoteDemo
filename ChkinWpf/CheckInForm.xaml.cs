using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HotelDataA.Moudls;
using HotelDataA.RoomMan;

namespace ChkinWpf
{
    /// <summary>
    /// Interaction logic for CheckInForm.xaml
    /// </summary>
    public partial class CheckInForm : Window
    {
        private readonly IdataDb _db;
        private Bookings _data = null;

        public CheckInForm(IdataDb db)
        {
            _db=db;
            InitializeComponent();
        }
        public void FilFrom(Bookings data)
        {
            _data=data;
            FirstNameText.Text = _data.FirstName;
            LastNameText.Text =_data.LastName;
            RoomText.Text=_data.name;
            RoomNumberText.Text=_data.RoomNumber;
            TotelCostText.Text= String.Format("{0:c}", _data.totelPrice);
        }

        private void ChekIn_Click(object sender, RoutedEventArgs e)
        {
            _db.Chakin(_data.Id
                );
            this.Close();
        }
    }
}
