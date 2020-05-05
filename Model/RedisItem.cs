using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace RedisExplorerUWP.Model
{
    /// <summary>
    /// Model for items stored in the Redis Cache we are connecting
    /// </summary>
    public class RedisItem : INotifyPropertyChanged
    {
        public string PrimaryKey { get; set; }
        public RedisItem Clone()
        {
            return (RedisItem)this.MemberwiseClone();
        }

        /// <summary>
        /// The JSON data retrieved by querying the Redis Cache. This is a Dictionary as we do not know what the keys will be ahead of time for any given cache. 
        /// </summary>
        public Dictionary<string, string> redisJSON;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
