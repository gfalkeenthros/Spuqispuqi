using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spuqispuqi.Viewmodel
{
    class TestViewmodel : ViewModelBase
    {
        private DateTimeOffset dateFrom1;
        private TimeSpan timeFrom1;

        public DateTimeOffset dateFrom
        {
            get => dateFrom1;
            set
            {
                dateFrom1 = value;
                OnPropertyChanged(nameof(dateFrom));
            }
        }
        public TimeSpan timeFrom
        {
            get => timeFrom1;
            set
            {
                timeFrom1 = value;
                OnPropertyChanged(nameof(timeFrom));
            }
        }

        public DateTimeOffset dateAndTime { get; set; }
        public String Combined { get; set; }

        public RelayCommand Combine { get; set; }

        public TestViewmodel()
        {
            dateFrom = DateTime.Today;
            timeFrom = DateTime.Now.TimeOfDay;
            Combine = new RelayCommand(CombineDates);
            Combined = "No date picked yet";
        }

        private void CombineDates()
        {
            dateAndTime = dateFrom.Date + timeFrom;
            Combined = dateAndTime.ToString("dd/MMx/yyyy HH:mm:tt");
            OnPropertyChanged(nameof(Combined));
        }
    }
}
