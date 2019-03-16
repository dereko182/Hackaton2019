using SharedModels;
using Syncfusion.DataSource;
using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LaboresPage : ContentPage
    {
        public LaboresPage(LaboresViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            listView.DataSource.SortDescriptors.Add(new SortDescriptor() { PropertyName = "Nombre", Direction = ListSortDirection.Ascending });
            listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "Fase",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as LaborModel);
                    return item.Fase;
                },
            });

            listView.SelectionChanging += ListView_SelectionChanging;
            listView.Loaded += ListView_Loaded;
            listView.PropertyChanged += ListView_PropertyChanged;
        }

        private void ListView_SelectionChanging(object sender, ItemSelectionChangingEventArgs e)
        {
            GroupResult actualGroup = null;
            object key = null;
            var selectedItems = listView.SelectedItems;

            //To Cancel the Deselection
            if (e.RemovedItems.Count > 0 && selectedItems.Contains(e.RemovedItems[0]))
            {
                e.Cancel = true;
                return;
            }

            //To return when SelectedItems is zero
            if (e.AddedItems.Count <= 0)
                return;

            var itemData = (e.AddedItems[0] as LaborModel);

            var descriptor = listView.DataSource.GroupDescriptors[0];
            if (descriptor.KeySelector == null)
            {
                var pbCollection = new PropertyInfoCollection(itemData.GetType());
                key = pbCollection.GetValue(itemData, descriptor.PropertyName);
            }
            else
                key = descriptor.KeySelector(itemData);

            for (int i = 0; i < listView.DataSource.Groups.Count; i++)
            {
                var group = listView.DataSource.Groups[i];

                if ((group.Key != null && group.Key.Equals(key)) || group.Key == key)
                {
                    actualGroup = group;
                    break;
                }
            }

            if (selectedItems.Count > 0)
            {
                foreach (var item in actualGroup.Items)
                {
                    var groupItem = item;

                    if (selectedItems.Contains(groupItem))
                    {
                        listView.SelectedItems.Remove(groupItem);
                        break;
                    }
                }
            }
        }

        private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            listView.CollapseAll();
        }

        private void ListView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ItemsSource")
            {
                listView.CollapseAll();
            }
        }
    }
}