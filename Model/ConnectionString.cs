using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExplorerUWP.Model
{
    /// <summary>
    /// Represents Recent Redis Connections saved in local storage
    /// </summary>
    public class ConnectionString : INotifyPropertyChanged
    {
        public string connectionString { get; set; }
        public string nickname { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
