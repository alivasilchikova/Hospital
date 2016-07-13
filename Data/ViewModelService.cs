using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Data
{
    class ViewModelService: DependencyObject
    {
        public AddServiceWindow Window { get; set; }
        private Repository _repository;

        public ViewModelService()
        {
            _repository = new Repository();
            Services = _repository.SelectService("SelectAllFromServices");
            CloseWindowCommand = new DelegateCommand(CloseWindow);

        }



        public List<Service> Services
        {
            get { return (List<Service>)GetValue(ServicesProperty); }
            set { SetValue(ServicesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Services.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServicesProperty =
            DependencyProperty.Register("Services", typeof(List<Service>), typeof(ViewModelService), new PropertyMetadata(null));



        public string ServiceName
        {
            get { return (string)GetValue(ServiceNameProperty); }
            set { SetValue(ServiceNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServiceName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServiceNameProperty =
            DependencyProperty.Register("ServiceName", typeof(string), typeof(ViewModelService), new PropertyMetadata(null));



        public decimal Cost
        {
            get { return (decimal)GetValue(CostProperty); }
            set { SetValue(CostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CostDecimal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CostProperty =
            DependencyProperty.Register("Cost", typeof(decimal), typeof(ViewModelService), new PropertyMetadata(null));

        public DelegateCommand CloseWindowCommand
        {
            get { return (DelegateCommand)GetValue(CloseWindowCommandProperty); }
            set { SetValue(CloseWindowCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseWindowCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseWindowCommandProperty =
            DependencyProperty.Register("CloseWindowCommand", typeof(DelegateCommand), typeof(ViewModelAddPosition), new PropertyMetadata(null));

        public void CloseWindow()
        {
            string errorString = "Ошибка! некорректный ввод по следующим позициям:";
            if (string.IsNullOrWhiteSpace(ServiceName))
            {
                errorString += "\nПоле 'Название услуги' не заполнено";
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

    }
    }
