using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace HospitalApp.Data
{
    internal class ViewModelDoctor: DependencyObject
    {
        private Repository repository;
        public DoctorWindow Window { get; set; }
        public List<string> WeekList { get; set; }
        public List<TimeSpan> TimeSpans { get; set; }
        public List<DateTime> Times { get; set; }
        public string SelectWeekDay { get; set; }
        public DateTime SelectBegin { get; set; }
        public DateTime SelectEnd { get; set; }
        public Dictionary<string, DayOfWeek> Dictionary { get; set; }
        //public List<Position> Positions { get; set; }
        public ViewModelDoctor()
        {
            repository = new Repository();
            Positions = repository.SelectPosition("SelectAllFromPositions");
            CloseWindowCommand = new DelegateCommand(CloseWindow);
            TimaTables = new ObservableCollection<Schedule>();
            Times = new List<DateTime>
            {
                new DateTime(2000,1,1, 8, 00, 00),
                new DateTime(2000,1,1,  9, 00, 00),
                new DateTime(2000,1,1,  10, 00, 00),
                new DateTime(2000,1,1, 11, 00, 00),
                new DateTime(2000,1,1,  12, 00, 00),
                new DateTime(2000,1,1,  13, 00, 00),
                new DateTime(2000,1,1,  14, 00, 00),
                new DateTime(2000,1,1,  15, 00, 00),
                new DateTime(2000,1,1,  16, 00, 00),
                new DateTime(2000,1,1,  17, 00, 00),
                new DateTime(2000,1,1, 18, 00, 00),
                new DateTime(2000,1,1,  19, 00, 00),
                new DateTime(2000,1,1,  20, 00, 00)
            };
            TimeSpans = new List<TimeSpan>()
            {
                new TimeSpan(8,00,00),
                new TimeSpan(9,00,00),
                new TimeSpan(10,00,00),
                new TimeSpan(11,00,00),
                new TimeSpan(12,00,00),
                new TimeSpan(13,00,00),
                new TimeSpan(14,00,00),
                new TimeSpan(15,00,00),
                new TimeSpan(16,00,00),
                new TimeSpan(17,00,00),
                new TimeSpan(18,00,00),
                new TimeSpan(19,00,00),
                new TimeSpan(20,00,00)
            };
            SelectBegin = Times[0];
            SelectEnd = Times[5];
            WeekList = new List<string>
            {
                "Понедельник",
                "Вторник",
                "Среда",
                "Четверг",
                "Пятница"
            };
            Dictionary = new Dictionary<string, DayOfWeek>
            {
                {"Понедельник",DayOfWeek.Monday},
                { "Вторник",DayOfWeek.Tuesday},
                { "Среда",DayOfWeek.Wednesday},
                { "Четверг",DayOfWeek.Thursday},
                { "Пятница",DayOfWeek.Friday},
                { "Суббота",DayOfWeek.Saturday },
                { "Воскресенье",DayOfWeek.Sunday }
            };
            AddTimeTableCommand = new DelegateCommand(AddDayOfWeek);
        }
        #region Commands



        public List<Doctor> Doctors
        {
            get { return (List<Doctor>)GetValue(DoctorsProperty); }
            set { SetValue(DoctorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Doctors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DoctorsProperty =
            DependencyProperty.Register("Doctors", typeof(List<Doctor>), typeof(ViewModelDoctor), new PropertyMetadata(null));



        public DelegateCommand CloseWindowCommand
        {
            get { return (DelegateCommand)GetValue(CloseWindowCommandProperty); }
            set { SetValue(CloseWindowCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseWindowCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseWindowCommandProperty =
            DependencyProperty.Register("CloseWindowCommand", typeof(DelegateCommand), typeof(ViewModelDoctor), new PropertyMetadata(null));

        public DelegateCommand AddTimeTableCommand
        {
            get { return (DelegateCommand)GetValue(AddTimeTableCommandProperty); }
            set { SetValue(AddTimeTableCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTimeTableCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTimeTableCommandProperty =
            DependencyProperty.Register("AddTimeTableCommand", typeof(DelegateCommand), typeof(ViewModelDoctor),
                new PropertyMetadata(null));


        public DelegateCommand DeleteTameTableCommand
        {
            get { return (DelegateCommand)GetValue(DeleteTameTableCommandProperty); }
            set { SetValue(DeleteTameTableCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteTameTableCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteTameTableCommandProperty =
            DependencyProperty.Register("DeleteTameTableCommand", typeof(DelegateCommand), typeof(ViewModelDoctor),
                new PropertyMetadata(null));

        public ObservableCollection<Schedule> TimaTables
        {
            get { return (ObservableCollection<Schedule>)GetValue(TimaTablesProperty); }
            set { SetValue(TimaTablesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimaTables.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimaTablesProperty =
            DependencyProperty.Register("TimaTables", typeof(ObservableCollection<Schedule>), typeof(ViewModelDoctor),
                new PropertyMetadata(null));



        public Schedule SelectedTimaTable
        {
            get { return (Schedule)GetValue(SelectedTimaTableProperty); }
            set { SetValue(SelectedTimaTableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedTimaTable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTimaTableProperty =
            DependencyProperty.Register("SelectedTimaTable", typeof(Schedule), typeof(ViewModelDoctor), new PropertyMetadata(null));

        #endregion
        #region DepProperties



        public string FIO
        {
            get { return (string)GetValue(FIOProperty); }
            set { SetValue(FIOProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PersonFIO.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FIOProperty =
            DependencyProperty.Register("FIO", typeof(string), typeof(ViewModelDoctor), new PropertyMetadata(""));



        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PersonPassport.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(ViewModelDoctor), new PropertyMetadata(""));



        public Position SelectedPosition
        {
            get { return (Position)GetValue(SelectedPositionProperty); }
            set { SetValue(SelectedPositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPositionProperty =
            DependencyProperty.Register("SelectedPosition", typeof(Position), typeof(ViewModelDoctor), new PropertyMetadata(null));



        public List<Position> Positions
        {
            get { return (List<Position>)GetValue(PositionsProperty); }
            set { SetValue(PositionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Positions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionsProperty =
            DependencyProperty.Register("Positions", typeof(List<Position>), typeof(ViewModelDoctor), new PropertyMetadata(null));



        public void CloseWindow()
        {
            ulong a;
            string errorString = "Ошибка! некорректный ввод по следующим позициям:";
            if (string.IsNullOrWhiteSpace(FIO))
            {
                errorString += "\nЗначение ФИО не заполнено";
            }
            if (string.IsNullOrWhiteSpace(PhoneNumber) || !ulong.TryParse(PhoneNumber, out a) || PhoneNumber.Length != 10)
            {
                errorString += "\nЗначение номера не заполнено или не соответствует стандарту";
            }
            if (TimaTables.Count == 0)
            {
                errorString += "\nВрач не может не работать!";
            }
            if (errorString == "Ошибка! некорректный ввод по следующим позициям:")
            {
                Window.DialogResult = true;
                Window.Close();
            }

            else
            {
                MessageBox.Show(errorString);
            }


        }
        /// <summary>
        /// Добавляет новый день недели в расписание врача
        /// </summary>
        public void AddDayOfWeek()
        {
            TimaTables.Add(new Schedule {Id = Guid.NewGuid(), DayBegin = SelectBegin, DayEnd = SelectEnd, WeekDay = SelectWeekDay});
        }


        #endregion 
    }
}