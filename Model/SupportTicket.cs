using System;
using System.ComponentModel;


namespace RedisExplorerUWP.Model
{

    public class SupportTicket : INotifyPropertyChanged
    {
        public string SupportTicketNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Severity { get; set; }
        public DateTime SLACreated { get; set; }
        public DateTime SLAExpiry { get; set; }
        public string SLAMet { get; set; }

        public SupportTicket Clone()
        {
            return (SupportTicket)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
