﻿#pragma checksum "C:\Users\Cody\Source\Repos\RedisExplorerUWP\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D6E39F43D638E1F741E869AB2C0D1C6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedisExplorerUWP
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj, global::System.Collections.IEnumerable value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Collections.IEnumerable) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Collections.IEnumerable), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_SelectedItem(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::RedisExplorerUWP.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBox obj4;
            private global::Windows.UI.Xaml.Controls.TextBox obj5;
            private global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj6;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj4TextDisabled = false;
            private static bool isobj5TextDisabled = false;
            private static bool isobj6ItemsSourceDisabled = false;
            private static bool isobj6SelectedItemDisabled = false;

            private MainPage_obj1_BindingsTracking bindingsTracking;

            public MainPage_obj1_Bindings()
            {
                this.bindingsTracking = new MainPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 61 && columnNumber == 22)
                {
                    isobj4TextDisabled = true;
                }
                else if (lineNumber == 66 && columnNumber == 21)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 49 && columnNumber == 33)
                {
                    isobj6ItemsSourceDisabled = true;
                }
                else if (lineNumber == 50 && columnNumber == 33)
                {
                    isobj6SelectedItemDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // MainPage.xaml line 59
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_4(this.obj4);
                        break;
                    case 5: // MainPage.xaml line 64
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_5(this.obj5);
                        break;
                    case 6: // MainPage.xaml line 38
                        this.obj6 = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)target;
                        this.bindingsTracking.RegisterTwoWayListener_6(this.obj6);
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::RedisExplorerUWP.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::RedisExplorerUWP.MainPage obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_currentNick(obj.currentNick, phase);
                        this.Update_currentConnectionString(obj.currentConnectionString, phase);
                        this.Update_itemList(obj.itemList, phase);
                        this.Update_selectedItem(obj.selectedItem, phase);
                    }
                }
            }
            private void Update_currentNick(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 59
                    if (!isobj4TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj4, obj, null);
                    }
                }
            }
            private void Update_currentConnectionString(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 64
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj5, obj, null);
                    }
                }
            }
            private void Update_itemList(global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_itemList(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 38
                    if (!isobj6ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(this.obj6, obj, null);
                    }
                }
            }
            private void Update_selectedItem(global::RedisExplorerUWP.Model.RedisItem obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_selectedItem(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 38
                    if (!isobj6SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_SelectedItem(this.obj6, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_4_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        this.dataRoot.currentNick = this.obj4.Text;
                    }
                }
            }
            private void UpdateTwoWay_5_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        this.dataRoot.currentConnectionString = this.obj5.Text;
                    }
                }
            }
            private void UpdateTwoWay_6_ItemsSource()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        this.dataRoot.itemList = (global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem>)this.obj6.ItemsSource;
                    }
                }
            }
            private void UpdateTwoWay_6_SelectedItem()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        this.dataRoot.selectedItem = (global::RedisExplorerUWP.Model.RedisItem)this.obj6.SelectedItem;
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class MainPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<MainPage_obj1_Bindings> weakRefToBindingObj; 

                public MainPage_obj1_BindingsTracking(MainPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<MainPage_obj1_Bindings>(obj);
                }

                public MainPage_obj1_Bindings TryGetBindingObject()
                {
                    MainPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                    UpdateChildListeners_itemList(null);
                    UpdateChildListeners_selectedItem(null);
                }

                public void PropertyChanged_(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::RedisExplorerUWP.MainPage obj = sender as global::RedisExplorerUWP.MainPage;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_currentNick(obj.currentNick, DATA_CHANGED);
                                bindings.Update_currentConnectionString(obj.currentConnectionString, DATA_CHANGED);
                                bindings.Update_itemList(obj.itemList, DATA_CHANGED);
                                bindings.Update_selectedItem(obj.selectedItem, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "currentNick":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_currentNick(obj.currentNick, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "currentConnectionString":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_currentConnectionString(obj.currentConnectionString, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "itemList":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_itemList(obj.itemList, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "selectedItem":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_selectedItem(obj.selectedItem, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void UpdateChildListeners_(global::RedisExplorerUWP.MainPage obj)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
                        }
                    }
                }
                public void PropertyChanged_itemList(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_itemList(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem> cache_itemList = null;
                public void UpdateChildListeners_itemList(global::System.Collections.ObjectModel.ObservableCollection<global::RedisExplorerUWP.Model.RedisItem> obj)
                {
                    if (obj != cache_itemList)
                    {
                        if (cache_itemList != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_itemList).PropertyChanged -= PropertyChanged_itemList;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_itemList).CollectionChanged -= CollectionChanged_itemList;
                            cache_itemList = null;
                        }
                        if (obj != null)
                        {
                            cache_itemList = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_itemList;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_itemList;
                        }
                    }
                }
                public void PropertyChanged_selectedItem(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    MainPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::RedisExplorerUWP.Model.RedisItem obj = sender as global::RedisExplorerUWP.Model.RedisItem;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::RedisExplorerUWP.Model.RedisItem cache_selectedItem = null;
                public void UpdateChildListeners_selectedItem(global::RedisExplorerUWP.Model.RedisItem obj)
                {
                    if (obj != cache_selectedItem)
                    {
                        if (cache_selectedItem != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_selectedItem).PropertyChanged -= PropertyChanged_selectedItem;
                            cache_selectedItem = null;
                        }
                        if (obj != null)
                        {
                            cache_selectedItem = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_selectedItem;
                        }
                    }
                }
                public void RegisterTwoWayListener_4(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_4_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_5(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_5_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_6(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid.ItemsSourceProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_6_ItemsSource();
                        }
                    });
                    sourceObject.RegisterPropertyChangedCallback(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid.SelectedItemProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_6_SelectedItem();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 16
                {
                    this.MainSplit = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // MainPage.xaml line 54
                {
                    this.newConnectionDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 4: // MainPage.xaml line 59
                {
                    this.connectionNick = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // MainPage.xaml line 64
                {
                    this.redisInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // MainPage.xaml line 38
                {
                    this.RedisCache = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.RedisCache).SelectionChanged += this.RedisCache_SelectionChanged;
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.RedisCache).Loaded += this.List_Loaded;
                }
                break;
            case 7: // MainPage.xaml line 32
                {
                    this.ManageConnection = (global::Windows.UI.Xaml.Controls.MenuBarItem)(target);
                }
                break;
            case 8: // MainPage.xaml line 33
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element8 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element8).Click += this.OnClick_NewConnection;
                }
                break;
            case 9: // MainPage.xaml line 74
                {
                    this.PaneGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

