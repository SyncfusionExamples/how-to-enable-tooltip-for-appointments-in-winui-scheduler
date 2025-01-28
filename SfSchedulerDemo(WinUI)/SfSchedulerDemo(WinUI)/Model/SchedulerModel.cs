namespace SfSchedulerDemo_WinUI_.Model
{
    using Microsoft.UI.Xaml.Media;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    /// <summary>
    /// Represents the model for a scheduler item.
    /// </summary>
    public class SchedulerModel : INotifyPropertyChanged
    {
        private DateTime from, to;
        private string eventName;
        private Brush color;
        private ObservableCollection<DateTime> recurrenceExceptionDates;
        private string rRUle;
        private object recurrenceId;
        private string endTimeZone;
        private string startTimeZone;
        private bool isAllDay;
        private ObservableCollection<object> resource;
        private ObservableCollection<object> resourceIdCollection;

        /// <summary>
        /// Gets or sets the collection of resource IDs associated with the scheduler item.
        /// </summary>
        public ObservableCollection<object> ResourceIdCollection
        {
            get { return resourceIdCollection; }
            set { resourceIdCollection = value; }
        }

        /// <summary>
        /// Gets or sets the start date and time of the scheduler item.
        /// </summary>
        public DateTime From
        {
            get { return from; }
            set
            {
                from = value;
                RaisePropertyChanged("From");
            }
        }

        /// <summary>
        /// Gets or sets the end date and time of the scheduler item.
        /// </summary>
        public DateTime To
        {
            get { return to; }
            set
            {
                to = value;
                RaisePropertyChanged("To");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the scheduler item is an all-day event.
        /// </summary>
        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                RaisePropertyChanged("IsAllDay");
            }
        }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                RaisePropertyChanged("EventName");
            }
        }

        /// <summary>
        /// Gets or sets the start time zone of the event.
        /// </summary>
        public string StartTimeZone
        {
            get { return startTimeZone; }
            set
            {
                startTimeZone = value;
                RaisePropertyChanged("StartTimeZone");
            }
        }

        /// <summary>
        /// Gets or sets the end time zone of the event.
        /// </summary>
        public string EndTimeZone
        {
            get { return endTimeZone; }
            set
            {
                endTimeZone = value;
                RaisePropertyChanged("EndTimeZone");
            }
        }

        /// <summary>
        /// Gets or sets the color associated with the event.
        /// </summary>
        public Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }

        /// <summary>
        /// Gets or sets the recurrence ID of the event.
        /// </summary>
        public object RecurrenceId
        {
            get { return recurrenceId; }
            set
            {
                recurrenceId = value;
                RaisePropertyChanged("RecurrenceId");
            }
        }

        /// <summary>
        /// Gets or sets the recurrence rule for the event.
        /// </summary>
        public string RecurrenceRule
        {
            get { return rRUle; }
            set
            {
                rRUle = value;
                RaisePropertyChanged("RecurrenceRule");
            }
        }

        /// <summary>
        /// Gets or sets the collection of recurrence exception dates for the event.
        /// </summary>
        public ObservableCollection<DateTime> RecurrenceExceptions
        {
            get { return recurrenceExceptionDates; }
            set
            {
                recurrenceExceptionDates = value;
                RaisePropertyChanged("RecurrenceExceptions");
            }
        }

        /// <summary>
        /// Gets or sets the collection of resources associated with the event.
        /// </summary>
        public ObservableCollection<object> Resource
        {
            get { return resource; }
            set
            {
                resource = value;
                RaisePropertyChanged("Resource");
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        protected virtual void RaisePropertyChanged(string propertyName, object oldValue = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}