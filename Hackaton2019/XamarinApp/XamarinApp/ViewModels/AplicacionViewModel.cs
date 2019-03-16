using Acr.UserDialogs;
using MvvmHelpers;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    public class AplicacionViewModel : BaseViewModel
    {
        private readonly IUserDialogs _userDialogs;

       public Command AplicarRecetaCommand => new Command(async () => await ExecuteAplicarReceta());

        private ObservableCollection<OrderInfo> _productosPorReceta;
        public ObservableCollection<OrderInfo> ProductosPorReceta
        {
            get => _productosPorReceta;
            set => SetProperty(ref _productosPorReceta, value);
        } 

        private RecetaModel _recetaSeleccionada;
        public RecetaModel RecetaSeleccionada
        {
            get => _recetaSeleccionada;
            set => SetProperty(ref _recetaSeleccionada, value);
        }

        public Command CambioRecetaCommand => new Command(ExecuteCambioReceta);

        private async Task ExecuteAplicarReceta()
        {
            await _userDialogs.AlertAsync("Receta aplicada correctamente");
        }

        public AplicacionViewModel()
        {
            _userDialogs = UserDialogs.Instance;
            ProductosPorReceta = new ObservableCollection<OrderInfo>();
        }

        private void ExecuteCambioReceta()
        {
            ProductosPorReceta.Add(new OrderInfo("ADECROP", "10", "ml"));
            ProductosPorReceta.Add(new OrderInfo("BIOVERIA", "3", "ml"));
            ProductosPorReceta.Add(new OrderInfo("CRECR", "5", "ml"));
        }
    }

    public class OrderInfo
    {
        private string customerID;
        private string customer;
        private string shipCity;

        public string CustomerID
        {
            get { return customerID; }
            set { this.customerID = value; }
        }

        public string Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public string ShipCity
        {
            get { return shipCity; }
            set { this.shipCity = value; }
        }

        public OrderInfo(string customerId, string customer, string shipCity)
        {
            this.CustomerID = customerId;
            this.Customer = customer;
            this.ShipCity = shipCity;
        }
    }
}
