using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HospitalApp.Data
{
    internal class ViewModelAppoinment: DependencyObject
    {
        public AppointmeintWindow Window { get; set; }
        private Repository repository;

        public ViewModelAppoinment()
        {
            repository = new Repository();
            Appointments = repository.SelectAppointment("SelectAllFromAppointments");
            AddCommand = new DelegateCommand(Add);
        }



        public List<Appointment> Appointments
        {
            get { return (List<Appointment>)GetValue(AppointmentsProperty); }
            set { SetValue(AppointmentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Appointments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppointmentsProperty =
            DependencyProperty.Register("Appointments", typeof(List<Appointment>), typeof(ViewModelAppoinment), new PropertyMetadata(null));

        public TabItem MenuTabItem
        {
            get { return (TabItem)GetValue(MenuTabItemProperty); }
            set { SetValue(MenuTabItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuTabItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuTabItemProperty =
            DependencyProperty.Register("MenuTabItem", typeof(TabItem), typeof(ViewModelAppoinment), new PropertyMetadata(null));

        public DelegateCommand AddCommand
        {
            get { return (DelegateCommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(DelegateCommand), typeof(ViewModelAppoinment), new PropertyMetadata(null));

        public void Add()
        {

        }

    }
}
