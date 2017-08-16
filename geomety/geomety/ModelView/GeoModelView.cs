using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using geomety.Annotations;
using geomety.Common;
using geomety.Model;
using Windows.UI.Xaml.Controls;

namespace geomety.ModelView
{
    class GeoModelView : INotifyPropertyChanged
    {
        private Rectangle _myRec;
        private RelayCommand _moveRect;
        private Ellips _myEllips; 
        private Text _myText { get; set; }
        public ObservableCollection<Rectangle> Rectangles { get; set; }
        public ObservableCollection<Text> Texts { get; set; }

        public Rectangle MyRec
        {
            get { return _myRec; }
            set
            {
                _myRec = value;
                OnPropertyChanged();
            }
        }
        
        public Text MyText
        {
            get { return _myText; }
            set
            {
                _myText = value;
                OnPropertyChanged();
            }
        }

        public Ellips MyEllips
        {
            get
            {
                return _myEllips;
            }
            set
            {
                _myEllips = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand MoveRect
        {
            get
            {
                return _moveRect;
            }
            set
            {
                _moveRect = value;
            }
        }
        public RelayCommand AddRect { get; set; }
        public RelayCommand RemoveRect { get; set; }
        public RelayCommand Top { get; set; }
        public RelayCommand Down { get; set; }
        public RelayCommand Left { get; set; }
        public RelayCommand Right { get; set; }
        public RelayCommand Auto { get; set; }
        public GeoModelView()
        {
             MyRec = new Rectangle();
             MoveRect = new RelayCommand(DoMoveRectangle);
            AddRect = new RelayCommand(DoAddRectangle);
            RemoveRect = new RelayCommand(DoRemoveRectangle);

            Top = new RelayCommand(MoveTop);
            Down = new RelayCommand(MoveDown);
            Left = new RelayCommand(MoveLeft);
            Right = new RelayCommand(MoveRight);
            Auto = new RelayCommand(DoAuto);
            //DoMoveRectangle();
            Rectangles = new ObservableCollection<Rectangle>();
             Rectangles.Add(new Rectangle {CanvasLeft = "10",CanvasTop = "10", Fill = "#FFE01B8F", Height = "10", Width = "10"});
            Rectangles.Add(new Rectangle { CanvasLeft = "70", CanvasTop = "50", Fill = "#FFE01B8F", Height = "70", Width = "30" });
            Rectangles.Add(new Rectangle { CanvasLeft = "170", CanvasTop = "100", Fill = "#FFFFFFFF", Height = "50", Width = "70" });

            Texts = new ObservableCollection<Text>();
            Texts.Add(new Text {CanvasText = "hello", Left=10, Top=10});
            Texts.Add(new Text { CanvasText = "hello HELLO", Left = 20, Top = 20 });
            Texts.Add(new Text { CanvasText = "hello hello hello", Left = 30, Top = 30 });
            Texts.Add(new Text { CanvasText = "new hello hello hello", Left = 50, Top = 50 });

            MyEllips = new Ellips();

        }

        private async void DoAuto()
        {
            for(int i = 0; i<5; i++)
                MyEllips.SetCoordinate(Convert.ToInt32(MyEllips.CanvasTop)+20, Convert.ToInt32(MyEllips.CanvasLeft)+20);
            await Task.Delay(1000);
        }

        private void MoveRight()
        {
            MyEllips = new Ellips(0, Convert.ToInt32(MyEllips.CanvasLeft) + 20);
         //   MyEllips.SetCoordinate(0, Convert.ToInt32(MyEllips.CanvasLeft)+20);
        }

        private void MoveLeft()
        {
            MyEllips.SetCoordinate(0, Convert.ToInt32(MyEllips.CanvasLeft) - 20);
        }

        private void MoveDown()
        {
            MyEllips.SetCoordinate(0, Convert.ToInt32(MyEllips.CanvasTop)+20);
        }

        private void MoveTop()
        {
            MyEllips.SetCoordinate(0, Convert.ToInt32(MyEllips.CanvasTop) - 20);
        }

        private void DoAddRectangle()
        {
            int PosTop;
            int PosLeft;

            PosTop = Convert.ToInt32(Rectangles[Rectangles.Count - 1].CanvasTop) + 100;
            PosLeft = Convert.ToInt32(Rectangles[Rectangles.Count - 1].CanvasLeft) + 50;

            Rectangles.Add(new Rectangle { CanvasLeft = PosLeft.ToString(), CanvasTop = PosTop.ToString(), Fill = "Red", Height = "100", Width = "100" });
        }

        private void DoRemoveRectangle()
        {
            Rectangles.Remove(Rectangles[Rectangles.Count - 1]);
        }

        private async void DoMoveRectangle()
        {
            for (int i = 0; i < 5; i++)
            {
                int position = int.Parse(MyRec.CanvasLeft) + 50;
                if (position > 420)
                    position = 0;
                MyRec = new Rectangle {CanvasLeft = position.ToString()};
                await Task.Delay(1000);
            }
           
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
