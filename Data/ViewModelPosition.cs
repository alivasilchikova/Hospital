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
    internal class ViewModelPosition : DependencyObject
    {
        public PositionWindow Window { get; set; }
        private Repository _repository;
        public ViewModelPosition()
        {
            _repository = new Repository();
            Positions = _repository.SelectPosition("SelectAllFromPositions");
            AddCommand = new DelegateCommand(Add);

        }


        public List<Position> Positions
        {
            get { return (List<Position>)GetValue(PositionsProperty); }
            set { SetValue(PositionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Positions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionsProperty =
            DependencyProperty.Register("Positions", typeof(List<Position>), typeof(ViewModelPosition), new PropertyMetadata(null));


        public string PositionName
        {
            get { return (string)GetValue(PositionNameProperty); }
            set { SetValue(PositionNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PositionName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionNameProperty =
            DependencyProperty.Register("PositionName", typeof(string), typeof(ViewModelPosition), new PropertyMetadata(null));

        public TabItem MenuTabItem
        {
            get { return (TabItem)GetValue(MenuTabItemProperty); }
            set { SetValue(MenuTabItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuTabItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuTabItemProperty =
            DependencyProperty.Register("MenuTabItem", typeof(TabItem), typeof(ViewModelPosition), new PropertyMetadata(null));

        public DelegateCommand AddCommand
        {
            get { return (DelegateCommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(DelegateCommand), typeof(ViewModelPosition), new PropertyMetadata(null));

        public void Add()
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
                _repository = new Repository();
                try
                {
                    _repository.InsertIntoPositions(addPosition);
                    Positions.Add(addPosition);

                }
                catch (Exception)
                {
                    throw;
                    //MessageBox.Show("некорректная вставка");
                }
            }

        }
    }
}
