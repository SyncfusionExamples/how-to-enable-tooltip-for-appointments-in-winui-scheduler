namespace SfSchedulerDemo_WinUI_
{
    using Microsoft.UI.Xaml.Media;
    using Syncfusion.UI.Xaml.Scheduler;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Windows.UI;

    public class SchdulerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or Sets schedule appointment collection.
        /// </summary>
        private ScheduleAppointmentCollection scheduleAppointments;
        private ObservableCollection<string> schedulerViewType;
        private ObservableCollection<string> resourceGroupType;

        /// <summary>
        /// Gets or sets the collection of view types for the scheduler.
        /// </summary>
        public ObservableCollection<string> SchedulerViewType
        {
            get
            {
                return schedulerViewType;
            }
            set
            {
                schedulerViewType = value;
                RaisePropertyChanged("Scheduler_ViewType");
            }
        }

        /// <summary>
        /// Gets or sets the collection of group types for resources in the scheduler.
        /// </summary>
        public ObservableCollection<string> ResourceGroupType
        {
            get
            {
                return resourceGroupType;
            }
            set
            {
                resourceGroupType = value;
                RaisePropertyChanged("Resource_GroupType");
            }
        }

        /// <summary>
        /// Gets or sets the collection of appointments for the scheduler.
        /// </summary>
        public ScheduleAppointmentCollection Appointments
        {
            get
            {
                return scheduleAppointments;
            }
            set
            {
                scheduleAppointments = value;
                this.RaisePropertyChanged("Appointments");
            }
        }

        /// <summary>
        /// Gets or sets the display date for the scheduler.
        /// </summary>
        public DateTime DisplayDate { get; set; }

        private ObservableCollection<object> resources;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the collection of resources for the scheduler.
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadOnDemandViewModel" /> class.
        /// </summary>
        public SchdulerViewModel()
        {
            this.InitializeResources();
            DisplayDate = new DateTime(2020, 8, 5);
            this.Appointments = this.GenerateScheduleAppointments();
            this.SchedulerViewType = new ObservableCollection<string>() { "Month", "Day", "Week", "Work Week", "Timeline Day", "Timeline Week", "Timeline Month", };
            this.ResourceGroupType = new ObservableCollection<string>() { "Date", "Resource", "None" };
        }

        #region Methods

        /// <summary>
        /// Method to check whether the load on demand command can be invoked or not.
        /// </summary>
        /// <param name="sender">QueryAppointmentsEventArgs object.</param>
        private bool CanExecuteOnDemandLoading(object sender)
        {
            return true;
        }

        private void InitializeResources()
        {
            Random random = new Random();
            this.Resources = new ObservableCollection<object>();
            var nameCollection = new List<string>() { "Sophia", "Daniel", "Kinsley Elena", "James William", "Emilia", "Brooklyn", "Chawla" };
            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

            for (int i = 0; i < 7; i++)
            {
                SchedulerResource employee = new SchedulerResource();
                employee.Name = nameCollection[i];
                employee.Background = brush[i];
                employee.Id = i.ToString();
                Resources.Add(employee);
            }
        }

        /// <summary>
        /// Method to generate scheduler appointments based on current visible date range.
        /// </summary>
        /// <param name="dateRange">Current visible date range.</param>
        private ScheduleAppointmentCollection GenerateScheduleAppointments()
        {
            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xA2, 0xC1, 0x39)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x00, 0x73)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0xA1, 0xE2)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xF0, 0x96, 0x09)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0x33)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAB, 0xA9)));
            brush.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xE6, 0x71, 0xB8)));

            var subjectCollection = new ObservableCollection<string>();
            subjectCollection.Add("Business Meeting");
            subjectCollection.Add("Conference");
            subjectCollection.Add("Medical check up");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Project Status Discussion");
            subjectCollection.Add("Client Meeting");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Yoga Therapy");
            subjectCollection.Add("GoToMeeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");

            var appointments = new ScheduleAppointmentCollection();
            var startTime = new DateTime(2020, 7, 1, 0, 0, 0);

            for (int i = 0; i < 30; i++)
            {
                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[1],
                    AppointmentBackground = brush[1],
                    ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" }
                });

                startTime = startTime.AddDays(1);

                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[2],
                    AppointmentBackground = brush[2],
                    ResourceIdCollection = new ObservableCollection<object> { "0", "2", "3" }
                });

                startTime = startTime.AddDays(1);

                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[3],
                    AppointmentBackground = brush[3],
                    ResourceIdCollection = new ObservableCollection<object> { "1", "3", "4" }
                });

                startTime = startTime.AddDays(1);
            }

            startTime = new DateTime(2020, 8, 1, 0, 0, 0);
            for (int i = 0; i < 30; i++)
            {
                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[1],
                    AppointmentBackground = brush[1],
                    ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" }
                });

                startTime = startTime.AddDays(1);

                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[2],
                    AppointmentBackground = brush[2],
                    ResourceIdCollection = new ObservableCollection<object> { "0", "2", "3" }
                });

                startTime = startTime.AddDays(1);

                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[3],
                    AppointmentBackground = brush[3],
                    ResourceIdCollection = new ObservableCollection<object> { "1", "3", "4" }
                });

                startTime = startTime.AddDays(1);
            }

            startTime = new DateTime(2020, 9, 1, 0, 0, 0);
            for (int i = 0; i < 30; i++)
            {
                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[1],
                    AppointmentBackground = brush[1],
                    ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" }
                });

                startTime = startTime.AddDays(1);

                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[2],
                    AppointmentBackground = brush[2],
                    ResourceIdCollection = new ObservableCollection<object> { "0", "2", "3" }
                });

                startTime = startTime.AddDays(1);

                appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = subjectCollection[3],
                    AppointmentBackground = brush[3],
                    ResourceIdCollection = new ObservableCollection<object> { "1", "3", "4" }
                });

                startTime = startTime.AddDays(1);
            }

            startTime = new DateTime(2020, 7, 27, 0, 0, 0);
            appointments.Add(new ScheduleAppointment
            {
                StartTime = startTime,
                EndTime = startTime.AddHours(1),
                Subject = subjectCollection[1],
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 255, 165, 0)),
                ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" },
                IsAllDay = true,
            });

            appointments.Add(new ScheduleAppointment
            {
                StartTime = startTime,
                EndTime = startTime.AddHours(1),
                Subject = subjectCollection[1],
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)),
                ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" },
                IsAllDay = true,
            });

            appointments.Add(new ScheduleAppointment
            {
                StartTime = startTime,
                EndTime = startTime.AddDays(3),
                Subject = subjectCollection[1],
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255)),
                ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" },
            });

            appointments.Add(new ScheduleAppointment
            {
                StartTime = startTime.Date.AddHours(5),
                EndTime = startTime.Date.AddDays(1).AddHours(3),
                Subject = subjectCollection[1],
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 144, 238, 144)),
                ResourceIdCollection = new ObservableCollection<object> { "0", "1", "2" },
            });

            return appointments;
        }
        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        /// <param name="oldValue">The old value of the property.</param>
        protected virtual void RaisePropertyChanged(string propertyName, object oldValue = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}