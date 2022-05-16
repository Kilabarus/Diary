using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using DiaryClient.Model;

namespace DiaryClient.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private Task _task;

        public long IdNotify
        {
            get 
            { 
                return _task.Id; 
            }
            set
            {
                _task.Id = value;
                OnPropertyChanged("Id");
            } 
        }
        
        public string TitleNotify
        {
            get
            {
                return _task.Title;
            }
            set
            {
                _task.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string BeginDateNotify
        {
            get
            {
                return _task.BeginDate;
            }
            set
            {
                _task.BeginDate = value;
                OnPropertyChanged("BeginDate");
            }
        }

        public string EndDateNotify
        {
            get
            {
                return _task.EndDate;
            }
            set
            {
                _task.EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public string DescriptionNotify
        {
            get
            {
                return _task.Description;
            }
            set
            {
                _task.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public Nullable<long> Type_IdNotify
        {
            get
            {
                return _task.Type_Id;
            }
            set
            {
                _task.Type_Id = value;
                OnPropertyChanged("Type_Id");
            }
        }

        public Nullable<long> Frequency_Id
        {
            get
            {
                return _task.Frequency_Id;
            }
            set
            {
                _task.Frequency_Id = value;
                OnPropertyChanged("Frequency_Id");
            }
        }

        public Nullable<long> Status_Id
        {
            get
            {
                return _task.Status_Id;
            }
            set
            {
                _task.Status_Id = value;
                OnPropertyChanged("Status_Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
