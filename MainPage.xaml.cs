using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RedisExplorerUWP.Model;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Uwp.Helpers;

namespace RedisExplorerUWP
{
    /// <summary>
    /// Main Page containing a view of the Redis Contents with a pane for showing details
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<RedisItem> itemList { get; set; } = new ObservableCollection<RedisItem>();
        public ObservableCollection<ConnectionString> recentConnectionStrings { get; set; }
        public string currentConnectionString = defaultString;
        public string currentNick = defaultNick;
        public RedisItem selectedItem;
        public RedisItem currentItem;
        public ConnectionString selectedConn;
        private Boolean itemsLoaded = false;
        private DataHelper _redisHelper;
        private Boolean createItem = false;
        private string connectionStore = "connectionStore";
        private LocalObjectStorageHelper storageHelper = new LocalObjectStorageHelper();
        static private string defaultString = "Enter Redis Connection String";
        static private string defaultNick = "Enter Nickname for Connection";
        private ConnectionString currentConnection;

        public MainPage()
        {
            _redisHelper = new DataHelper(currentConnection.connectionString);
            this.Loaded += List_Loaded;
            this.InitializeComponent();
            this.MainSplit.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, IsPaneOpenPropertyChanged);
            GetRecentConnections();
            UpdateMenuItems();
        }

        public async void List_Loaded(object sender, RoutedEventArgs e)
        {
            if (itemsLoaded == false)
            {
                itemsLoaded = true;
                itemList = await _redisHelper.GetTickets(itemList);
                GetRecentConnections();
                NotifyPropertyChanged(nameof(itemList));
                Debug.WriteLine("Loaded Tickets");
                Debug.WriteLine($"First Loaded Ticket after Async: {itemList[0].PrimaryKey}");
            }
            Debug.WriteLine("Attempted List_Loaded, but ticketsLoaded was true");
        }

        void RedisCache_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedItem != null)
            {
                Debug.WriteLine($"Service Ticket {selectedItem.PrimaryKey} selected");
                currentItem = selectedItem.Clone();
                NotifyPropertyChanged(nameof(currentItem));
                MainSplit.IsPaneOpen = true;
            }
            else
            {
                Debug.WriteLine("Selected Ticket was null");
            }
        }

        void Button_Close(Object sender, RoutedEventArgs e)
        {
            createItem = false;
            MainSplit.IsPaneOpen = false;
        }

        public async void Button_Delete(Object sender, RoutedEventArgs e)
        {
            Boolean result = await _redisHelper.DeleteTicket(selectedItem.PrimaryKey);
            Debug.WriteLine($"Result of deleting {selectedItem.PrimaryKey} is {result}");
            itemList.Remove(selectedItem);
            MainSplit.IsPaneOpen = false;
        }

        public async void Button_Save(Object sender, RoutedEventArgs e)
        {
            if (createItem == true)
            {
                createItem = false;
                Debug.WriteLine("Performing Create Ticket Operation");
                var createResult = await _redisHelper.AddNew(currentItem);
                Debug.WriteLine($"Result of Redis AddTicket: {createResult}");
                itemList.Add(currentItem);
                NotifyPropertyChanged(nameof(itemList));
            } else if (selectedItem.PrimaryKey == currentItem.PrimaryKey)
            {
                    await _redisHelper.EditItem(selectedItem);
                    var index = itemList.IndexOf(selectedItem);
                    Debug.WriteLine($"Updated ticket {selectedItem.PrimaryKey}");
                    itemList[index] = currentItem;
                    NotifyPropertyChanged(nameof(itemList));
                    MainSplit.IsPaneOpen = false;
             } else {
                Debug.WriteLine($"Editted ticket had a different ticket number! Selected: {selectedItem.PrimaryKey}, Current: {currentItem.PrimaryKey}");
            }

           
        }

        public void Button_Create(Object sender, RoutedEventArgs e)
        {
            createItem = true;
            currentItem = new RedisItem
            {
                PrimaryKey = "0"
            };
            NotifyPropertyChanged(nameof(currentItem));
        }

        private void IsPaneOpenPropertyChanged(DependencyObject sender, DependencyProperty dp)
        {
            if (this.MainSplit.IsPaneOpen)
            {
                this.MainSplit.OpenPaneLength = this.ActualWidth * .4;
            }
        }

        public async void OnClick_NewConnection(Object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await newConnectionDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                if (currentConnectionString != defaultString)
                {
                    var newConnection = new ConnectionString
                    {
                        connectionString = currentConnectionString,
                        nickname = currentNick
                    };

                    recentConnectionStrings.Add(newConnection);
                    UpdateMenuItems();
                    await storageHelper.SaveFileAsync(connectionStore, recentConnectionStrings);
                }
            }
            else
            {

            }
        }

        private void GetRecentConnections()
        {
            if (storageHelper.KeyExists(connectionStore))
            {
                recentConnectionStrings = storageHelper.Read<ObservableCollection<ConnectionString>>(connectionStore);
            } else
            {
                recentConnectionStrings = new ObservableCollection<ConnectionString>();
            }

        }

        private void UpdateMenuItems()
        {
            ManageConnection.Items.Clear();
            var newItem = new MenuFlyoutItem();
            newItem.Text = "New Connection";
            newItem.Click += OnClick_NewConnection;
            ManageConnection.Items.Add(newItem);

            var seperator = new MenuFlyoutSeparator();
            ManageConnection.Items.Add(seperator);

            foreach (var item in recentConnectionStrings)
            {
                newItem = new MenuFlyoutItem
                {
                    Text = item.nickname,
                    Name = item.connectionString
                };
                newItem.Click += OnCLick_RecentConnection;
                ManageConnection.Items.Add(newItem);
            }


            
        }

        public void OnCLick_RecentConnection(Object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem selected = sender as MenuFlyoutItem;
            selectedConn = new ConnectionString
            {
                nickname = selected.Text,
                connectionString = selected.Name
            };

            currentConnection = selectedConn;
            _redisHelper.updateConnection(currentConnection.connectionString);
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
