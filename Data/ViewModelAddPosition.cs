using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HospitalApp.Data
{
     internal class ViewModelAddPosition : DependencyObject
    {
         public AddPositionWindow Window { get; set; }
         private Repository _repository;

         public ViewModelAddPosition()
         {
                _repository = new Repository();
                CloseWindowCommand = new DelegateCommand(CloseWindow);
         }

        public List<Position> Positions
        {
            get { return (List<Position>)GetValue(PositionsProperty); }
            set { SetValue(PositionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Positions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionsProperty =
            DependencyProperty.Register("Positions", typeof(List<Position>), typeof(ViewModelAddPosition), new PropertyMetadata(null));

        public string PositionName
        {
            get { return (string)GetValue(PositionNameProperty); }
            set { SetValue(PositionNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PositionName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionNameProperty =
            DependencyProperty.Register("PositionName", typeof(string), typeof(ViewModelAddPosition), new PropertyMetadata(null));

        public TabItem MenuTabItem
        {
            get { return (TabItem)GetValue(MenuTabItemProperty); }
            set { SetValue(MenuTabItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuTabItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuTabItemProperty =
            DependencyProperty.Register("MenuTabItem", typeof(TabItem), typeof(ViewModelAddPosition), new PropertyMetadata(null));

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
            if (string.IsNullOrWhiteSpace(PositionName))
            {
                errorString += "\nПоле 'Должность' не заполнено";
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