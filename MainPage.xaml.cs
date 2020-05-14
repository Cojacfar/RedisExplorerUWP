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
using System.Collections.Generic;

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
                itemList = await _redisHelper.GetItems(itemList);
                GetRecentConnections();
                NotifyPropertyChanged(nameof(itemList));
                Debug.WriteLine("Loaded Tickets");
                Debug.WriteLine($"First Loaded Ticket after Async: {itemList[0].PrimaryKey}");
            }
            Debug.WriteLine("Attempted List_Loaded, but ticketsLoaded was true");
        }

        public async void Update_Columns()
        {
            List<string> redisKeys = await _redisHelper.GuessSchema(currentConnection);
            RedisCache.HeaderTemplate.SetValue
            //  <TextBlock Text="ID" Margin="8,0" Width="300" Foreground="{ThemeResource SystemAccentColor}" />
            //           <DataTemplate x:DataType="local:RedisItem">
            //  < StackPanel Orientation = "Horizontal" HorizontalAlignment = "Center" >

                            //         < TextBlock Name = "SupportTicketNumber"
                            //          Text = "{x:Bind SupportTicketNumber}"
                            //          Width = "300" Margin = "8,0" />

                            //        < TextBlock Name = "ItemName"
                            //          Text = "{x:Bind CreatedOn}"
                            //          Width = "auto" Margin = "8,0" />

                            //        < TextBlock Text = "{x:Bind Severity}"
                            //         Width = "auto" Margin = "8,0" />

                            //        < TextBlock Text = "{x:Bind SLAMet}"
                            //         Width = "auto" Margin = "8,0" />

                            //        < TextBlock Text = "{x:Bind SLAExpiry}"
                            //         Width = "auto" Margin = "8,0" />

                            //    </ StackPanel >

                            //</ DataTemplate >

                  //          < AppBarButton Icon = "ClosePane" Label = "Close" Click = "Button_Close" Grid.Row = "0" Grid.Column = "3" HorizontalAlignment = "Right" HorizontalContentAlignment = "Right" />
             
                  //           < TextBlock Name = "NumberHeader"
                  //  TextAlignment = "Left"
                  //  Text = "Support Ticket Number:"
                  //  Width = "200"
                  //  Height = "auto"
                  //  Grid.Row = "0" Grid.Column = "0" />
  
                  //< TextBox Name = "SupportTicketNumber"
                  //  TextAlignment = "Left"
                  //  Text = "{x:Bind currentTicket.SupportTicketNumber, Mode=TwoWay}"
                  //  Width = "auto" Height = "auto"
                  //  Grid.Row = "0" Grid.Column = "1" Grid.ColumnSpan = "2"
                  //      />
    
                  //  < TextBlock Name = "CreatedHeader"
                  //  TextAlignment = "Left"
                  //  Text = "Created On:"
                  //  Width = "auto"
                  //  Height = "auto"
                  //  Grid.Row = "1" Grid.Column = "0" />
  
                  //< CalendarDatePicker Name = "CreatedOn"
                  //  Date = "{x:Bind currentTicket.CreatedOn, Mode=TwoWay, Converter={ StaticResource DateConverter }}"
                  //  DateFormat = "{}{month.integer}/{day.integer}/{year.full}"
                  //  Width = "auto"
                  //  Grid.Row = "1" Grid.Column = "1" Grid.ColumnSpan = "2" />
    
                  //  < TextBlock Name = "SeverityHeader"
                  //  TextAlignment = "Left"
                  //  Text = "Severity:"
                  //  Width = "auto"
                  //  Height = "auto"
                  //  Grid.Row = "2" Grid.Column = "0" />
  
                  //< TextBox
                  //  TextAlignment = "Left"
                  //  Text = "{x:Bind currentTicket.Severity, Mode=TwoWay}"
                  //  Width = "auto"
                  //  Grid.Row = "2" Grid.Column = "1" Grid.ColumnSpan = "2" />
    
                  //  < TextBlock Name = "SLACreatedHeader"
                  //  TextAlignment = "Left"
                  //  Text = "SLA Created:"
                  //  Width = "auto"
                  //  Height = "auto"
                  //  Grid.Row = "3" Grid.Column = "0" />
  
                  //< CalendarDatePicker
                  //  Name = "SLACreated"
                  //  Date = "{x:Bind currentTicket.SLACreated, Mode=TwoWay, Converter={ StaticResource DateConverter }}"
                  //  DateFormat = "{}{month.integer}/{day.integer}/{year.full}"
                  //  Width = "auto"
                  //  Grid.Row = "3" Grid.Column = "1" Grid.ColumnSpan = "2" />
    
                  //  < TextBlock Name = "SLAMetHeader"
                  //  TextAlignment = "Left"
                  //  Text = "SLA Met:"
                  //  Width = "auto"
                  //  Height = "auto"
                  //  Grid.Row = "4" Grid.Column = "0" />
  
                  //< TextBox
                  //  TextAlignment = "Left"
                  //  Text = "{x:Bind currentTicket.SLAMet, Mode=TwoWay}"
                  //  Width = "auto"
                  //  Grid.Row = "4" Grid.Column = "1" Grid.ColumnSpan = "2" />
    
                  //  < TextBlock Name = "SLAExpiryHeader"
                  //  TextAlignment = "Left"
                  //  Text = "SLA Expiry:"
                  //  Width = "auto"
                  //  Height = "auto"
                  //  Grid.Row = "5" Grid.Column = "0" />
  
                  //< CalendarDatePicker
                  //  Name = "SLAExpiry"
                  //  Date = "{x:Bind currentTicket.SLAExpiry, Mode=TwoWay, Converter={ StaticResource DateConverter }}"
                  //  DateFormat = "{}{month.integer}/{day.integer}/{year.full}"
                  //  Width = "auto"
                  //  Grid.Row = "5" Grid.Column = "1" Grid.ColumnSpan = "2" />
    
                  //  < StackPanel Orientation = "Horizontal" Grid.Row = "6" Grid.Column = "0" Grid.ColumnSpan = "4" >
           
                  //             < AppBarButton Icon = "Save" Label = "Save" Click = "Button_Save" />
                
                  //                  < AppBarButton Icon = "Delete" Label = "Delete" Click = "Button_Delete" />
                     
                  //                       < AppBarButton Icon = "Add" Label = "Create New" Click = "Button_Create" />
                          
                  //                        </ StackPanel >
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
                    currentConnection = newConnection;
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
