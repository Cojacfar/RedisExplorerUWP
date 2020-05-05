﻿using System;
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
           // RedisConnection = ConnectionMultiplexer.Connect((App.Current as App).RedisConnection);
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
        /// Retrieves all keys in the Redis Server, and adds the complete Deserialized supportTicket object into the passed in ObservableCollection
        /// </summary>
        /// <param name="ticketList"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<RedisItem>> GetTickets(ObservableCollection<RedisItem> ticketList)
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

                // return AllSupportTickets;
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
        /// Replaces a ticket in Redis using the supportTicketNumber as the Redis key, and the all the fields of the passed in Support Ticket
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
        /// Use StringSetAsync to create a new entry into Redis with the SupportTicketNumber as the key
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
    }
}
