using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace RedisExplorerUWP.Model
{
    public class RedisItem : INotifyPropertyChanged
    {
        public string PrimaryKey { get; set; }
        public RedisItem Clone()
        {
            return (RedisItem)this.MemberwiseClone();
        }
        public Dictionary<string, string> redisJSON;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
