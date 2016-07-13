using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace HospitalApp.Data
{
    class ViewModel: DependencyObject
    {
        Repository repository;
        public ViewModel()
        {
            repository = new Repository();
            AddCommand = new DelegateCommand(Add);
            PositionCommand = new DelegateCommand(PositionButton);
            AddAppointmentCommand = new DelegateCommand(AddAppointment);
            AddServiceCommand = new DelegateCommand(AddService);
            //MenuTabItem = new TabItem();
            Doctors = new ObservableCollection<Doctor>(repository.SelecDoctor("SelectAllFromDoctors"));
            Positions = new ObservableCollection<Position>(repository.SelectPosition("SelectAllFromPositions"));
            Customers = new ObservableCollection<Customer>(repository.SelectCustomers("SelectAllFromCustomers"));
            Schedules = new ObservableCollection<Schedule>(repository.SelectSchedule("SelectAllFromSchedules"));
            Appointments = new ObservableCollection<Appointment>(repository.SelectAppointment("SelectAllFromAppointments"));
            Bills = new ObservableCollection<Bill>(repository.SelectBills("SelectAllFromBills"));
            Services = new ObservableCollection<Service>(repository.SelectService("SelectAllFromServices"));
            //Parallel.ForEach(Doctors, t =>
            //{
            foreach (var t in Doctors)
            {
                foreach (Position t1 in Positions)
                {
                    if (t.PositionId == t1.Id)
                    {
                        t.Position = t1;
                    }
                }
                foreach (Schedule t2 in Schedules)
                {
                    if (t2.DoctorId == t.Id)
                    {
                        t2.Doctor = t;
                        t.Schedules.Add(t2);
                    }
                }
            }

            //});
        }
        #region Collection




        public ObservableCollection<Doctor> Doctors
        {
            get { return (ObservableCollection<Doctor>)GetValue(DoctorsProperty); }
            set { SetValue(DoctorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DoctorsProperty =
            DependencyProperty.Register("Doctors", typeof(ObservableCollection<Doctor>), typeof(ViewModel), new PropertyMetadata(null));





        public ObservableCollection<Position> Positions
        {
            get { return (ObservableCollection<Position>)GetValue(PositionsProperty); }
            set { SetValue(PositionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Positions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionsProperty =
            DependencyProperty.Register("Positions", typeof(ObservableCollection<Position>), typeof(ViewModel), new PropertyMetadata(null));




        public ObservableCollection<Appointment> Appointments
        {
            get { return (ObservableCollection<Appointment>)GetValue(AppointmentsProperty); }
            set { SetValue(AppointmentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Appointments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppointmentsProperty =
            DependencyProperty.Register("Appointments", typeof(ObservableCollection<Appointment>), typeof(ViewModel), new PropertyMetadata(null));



        public ObservableCollection<Bill> Bills
        {
            get { return (ObservableCollection<Bill>)GetValue(BillsProperty); }
            set { SetValue(BillsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Bills.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BillsProperty =
            DependencyProperty.Register("Bills", typeof(ObservableCollection<Bill>), typeof(ViewModel), new PropertyMetadata(null));



        public ObservableCollection<Customer> Customers
        {
            get { return (ObservableCollection<Customer>)GetValue(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomersProperty =
            DependencyProperty.Register("Customers", typeof(ObservableCollection<Customer>), typeof(ViewModel), new PropertyMetadata(null));



        public ObservableCollection<Schedule> Schedules
        {
            get { return (ObservableCollection<Schedule>)GetValue(SchedulesProperty); }
            set { SetValue(SchedulesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Schedules.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SchedulesProperty =
            DependencyProperty.Register("Schedules", typeof(ObservableCollection<Schedule>), typeof(ViewModel), new PropertyMetadata(null));



        public ObservableCollection<Service> Services
        {
            get { return (ObservableCollection<Service>)GetValue(ServicesProperty); }
            set { SetValue(ServicesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Services.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServicesProperty =
            DependencyProperty.Register("Services", typeof(ObservableCollection<Service>), typeof(ViewModel), new PropertyMetadata(null));


        #endregion
        #region DependencyProperties
        public TabItem MenuTabItem
        {
            get { return (TabItem)GetValue(MenuTabItemProperty); }
            set { SetValue(MenuTabItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuTabItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuTabItemProperty =
            DependencyProperty.Register("MenuTabItem", typeof(TabItem), typeof(ViewModel), new PropertyMetadata(null));



        public Doctor SelectedDoctor
        {
            get { return (Doctor)GetValue(SelectedDoctorProperty); }
            set { SetValue(SelectedDoctorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDoctor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDoctorProperty =
            DependencyProperty.Register("SelectedDoctor", typeof(Doctor), typeof(ViewModel), new PropertyMetadata(null));


        #endregion
        #region Commands


        public DelegateCommand AddCommand
        {
            get { return (DelegateCommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));

        public DelegateCommand InsertCommand
        {
            get { return (DelegateCommand)GetValue(InsertCommandProperty); }
            set { SetValue(InsertCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InsertCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InsertCommandProperty =
            DependencyProperty.Register("InsertCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));



        public DelegateCommand UpdateCommand
        {
            get { return (DelegateCommand)GetValue(UpdateCommandProperty); }
            set { SetValue(UpdateCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateCommandProperty =
            DependencyProperty.Register("UpdateCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));



        public DelegateCommand DeleteCommand
        {
            get { return (DelegateCommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));



        public DelegateCommand PositionCommand
        {
            get { return (DelegateCommand)GetValue(PositionCommandProperty); }
            set { SetValue(PositionCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PositionCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionCommandProperty =
            DependencyProperty.Register("PositionCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));




        public DelegateCommand AddAppointmentCommand
        {
            get { return (DelegateCommand)GetValue(AddAppointmentCommandProperty); }
            set { SetValue(AddAppointmentCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddAppointmentCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddAppointmentCommandProperty =
            DependencyProperty.Register("AddAppointmentCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));




        public DelegateCommand AddServiceCommand
        {
            get { return (DelegateCommand)GetValue(AddServiceCommandProperty); }
            set { SetValue(AddServiceCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddServiceCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddServiceCommandProperty =
            DependencyProperty.Register("AddServiceCommand", typeof(DelegateCommand), typeof(ViewModel), new PropertyMetadata(null));


        #endregion
        #region Methods

        public void PositionButton()
        {
            var addPositionWindow = new AddPositionWindow();
            ViewModelAddPosition addViewModelAddPosition = new ViewModelAddPosition();
            addPositionWindow.DataContext = addViewModelAddPosition;
            addViewModelAddPosition.Window = addPositionWindow;
            //addViewModelDoctor.Positions = Positions;
            if (addPositionWindow.ShowDialog() == true)
            {
                Position addPosition = new Position()
                {
                    Id = Guid.NewGuid(),
                    PositionName = addViewModelAddPosition.PositionName
                };
                repository = new Repository();
                try
                {
                    repository.InsertIntoPositions(addPosition);
                    Positions.Add(addPosition);

                }
                catch (Exception)
                {
                    throw;
                    //MessageBox.Show("некорректная вставка");
                }
            }

        }
        public void AddAppointment()
        {
            var addAppointmentWindow = new AppointmeintWindow();
            ViewModelAppoinment viewModelAppoinment = new ViewModelAppoinment();
            addAppointmentWindow.DataContext = viewModelAppoinment;
            viewModelAppoinment.Window = addAppointmentWindow;
            if (addAppointmentWindow.ShowDialog() == true)
            {

            }
        }

        public void AddService()
        {
            var addServiceWindow = new AddServiceWindow();
            ViewModelService viewModelService = new ViewModelService();
            addServiceWindow.DataContext = viewModelService;
            viewModelService.Window = addServiceWindow;
            if (addServiceWindow.ShowDialog() == true)
            {
                Service addService = new Service()
                {
                    Id = Guid.NewGuid(),
                    ServiceName = viewModelService.ServiceName,
                    Cost = viewModelService.Cost
                };
                repository = new Repository();
                try
                {
                    repository.InsertIntoServices(addService);
                    Services.Add(addService);
                }
                catch (Exception)
                {
                    throw;
                    //MessageBox.Show("некорректная вставка");
                }

            }

        }

        public void Add()
        {
            if (MenuTabItem.Header.ToString() == "Врачи")
            {
                var  addDoctorWindow = new DoctorWindow();
                ViewModelDoctor addViewModelDoctor = new ViewModelDoctor();
                addDoctorWindow.DataContext = addViewModelDoctor;
                addViewModelDoctor.Window = addDoctorWindow;
                //addViewModelDoctor.Positions = Positions;
                if (addDoctorWindow.ShowDialog() == true)
                {
                    Doctor AddDoctor = new Doctor()
                    {
                        Id = Guid.NewGuid(),
                        FIO = addViewModelDoctor.FIO,
                        PhoneNumber = addViewModelDoctor.PhoneNumber,
                        PositionId = addViewModelDoctor.SelectedPosition.Id,
                        Position = addViewModelDoctor.SelectedPosition,
                        Schedules = addViewModelDoctor.TimaTables

                        //Position = new Position { Id = Guid.NewGuid(), PositionName = addViewModelDoctor.SelectedPosition.PositionName }
                        //Person = new Person { Id = Guid.NewGuid(), FIO = addViewModelDoctor.PersonFio, Passport = addViewModelDoctor.PhoneNumber }
                    };
                    Parallel.ForEach(addViewModelDoctor.TimaTables, t =>
                    {
                        t.DoctorId = AddDoctor.Id;
                    });
                    repository = new Repository();
                    try
                    {
                        repository.InsertIntoDoctors(AddDoctor);
                        Doctors.Add(AddDoctor);
                        
                        foreach (var t in AddDoctor.Schedules)
                        {
                            repository.InsertIntoSchedules(t);
                            //Schedules.Add(t);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                        //MessageBox.Show("некорректная вставка");
                    }
                }


            }
            else if (MenuTabItem.Header.ToString() == "Пациенты")
            {

            }
        }


            #endregion

        public void GiveObjParameters(object _object)
        {
            
        }
        }
}
