using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using RedisExplorerUWP;
using System.Collections.Generic;
using System.Linq;
using RedisExplorerUWP.Model;
using System.Collections.ObjectModel;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace RedisExplorerUWP.Model
{
    /// <summary>
    /// Class to help get data in and out of Redis Cache
    /// </summary>
    class DataHelper
    {
        private ConnectionMultiplexer RedisConnection;
        public DataHelper(string connectionString)
        {
            CreateConnection(connectionString);
        }

        public void CreateConnection(string connectionString)
        {
            RedisConnection = ConnectionMultiplexer.Connect(connectionString);
        }

        /// <summary>
        /// Updates the ConnectionMultiplexer associated to the RedisHelper to the parameter
        /// </summary>
        /// <param name="connectionString"></param>
        public void updateConnection(string connectionString)
        {
            CreateConnection(connectionString);
        }
        /// <summary>
        /// Retrieves all keys in the Redis Server, and adds the complete Deserialized redisItem object into the passed in ObservableCollection
        /// </summary>
        /// <param name="ticketList"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<RedisItem>> GetItems(ObservableCollection<RedisItem> ticketList)
        {
            try
            {
                IDatabase cache = RedisConnection.GetDatabase();
                IDatabase db = RedisConnection.GetDatabase();

                var endPoint = RedisConnection.GetEndPoints().First();
                RedisKey[] keys = RedisConnection.GetServer(endPoint).Keys(pattern: "*").ToArray();

                foreach (var key in keys)
                {
                    try
                    {
                        var CacheValue = await cache.StringGetAsync(key);
                        if (!string.IsNullOrEmpty(CacheValue))
                        {
                            Debug.WriteLine($"Retrieved from Redis: {JsonConvert.DeserializeObject(CacheValue)}");
                            RedisItem tempObject = new RedisItem()
                            {
                                PrimaryKey = key,
                                redisJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(CacheValue)
                            };
                            
                            ticketList.Add(tempObject);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Exception retriving individual Cache Value: " + ex.Message);

                    }
                }

                return ticketList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Get all redis entries exception: " + ex.Message);
                throw new RedisConnectionException(ConnectionFailureType.UnableToConnect, "Unable to connect to retrieve all support tickets");
            }
        }

        public async Task<Boolean> DeleteTicket(string primaryKey)
        {
            try
            {
                IDatabase cache = RedisConnection.GetDatabase();
                Debug.WriteLine($"Deleting Ticket # {primaryKey}");
                await cache.KeyDeleteAsync(primaryKey);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DataHelper.DeleteSupportTicket({primaryKey}): {ex.Message} - {ex.StackTrace}");
                return false;
            }
        }
        /// <summary>
        /// Replaces a ticket in Redis using the primaryKey as the Redis key, and the all the fields of the passed in redis Item
        /// </summary>
        /// <param name="redisItem"></param>
        /// <returns></returns>
        public async Task<Boolean> EditItem(RedisItem redisItem)
        {
            try
            {
                IDatabase cache = RedisConnection.GetDatabase();
                Debug.WriteLine($"Updating Item {redisItem.PrimaryKey}");
                await cache.StringSetAsync(redisItem.PrimaryKey, JsonConvert.SerializeObject(redisItem.redisJSON));

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DataHelper.EditItem ({redisItem.PrimaryKey}): {ex.Message} - {ex.StackTrace}");
                return false;
            }
        }

        /// <summary>
        /// Use StringSetAsync to create a new entry into Redis with the PrimaryKey as the key
        /// </summary>
        /// <param name="supportTicket"></param>
        /// <returns></returns>
        public async Task<Boolean> AddNew(RedisItem redisItem)
        {
            try
            {
                IDatabase cache = RedisConnection.GetDatabase();
                await cache.StringSetAsync(redisItem.PrimaryKey, JsonConvert.SerializeObject(redisItem.redisJSON));

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DataHelper.AddNew({redisItem.PrimaryKey}): {ex.Message} - {ex.StackTrace}");
                return false;
            }
        }

        /// <summary>
        /// Inspecting first 10 keys from the Redis Cache to check the Schema of their entries to know what to display as columns. Storing this into the passed connection object. 
        /// 
        /// Right now, this is just checking the first one. It may be required to check more if people are using multiple schemas in their cache
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public async Task<List<string>> GuessSchema(ConnectionString connection)
        {
            IDatabase cache = RedisConnection.GetDatabase();
            var endPoint = RedisConnection.GetEndPoints().First();
            IServer server = RedisConnection.GetServer(endPoint);
            var keys = server.Keys(pattern: "*", pageSize: 10).ToArray();
            var response = await cache.StringGetAsync(keys[0]);

            Dictionary<string, string> JSONdict = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            List<string> JsonKeys = JSONdict.Keys.ToList();
            connection.JSONKeys = JsonKeys;
            return JsonKeys;

        }
    }
}
