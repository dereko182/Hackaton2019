using Acr.UserDialogs;
using MvvmHelpers;
using SharedModels;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using XamarinApp.Interfaces;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class LaboresViewModel : BaseViewModel
    {
        private readonly ILaborService _laborService;
        private readonly IUserDialogs _userDialogs;

        public LaboresViewModel()
        {
            Title = "Labores";
            _laborService = DependencyService.Get<ILaborService>();
            _userDialogs = UserDialogs.Instance;
            Labores = new ObservableRangeCollection<LaborModel>();
            CargarDatosCommand = new Command(async () => await CargarDatos());
            SelectionChangedCommand = new Command<ItemSelectionChangedEventArgs>(async (x) => await ExecuteCambiarEstado(x));
        }


        public Command<ItemSelectionChangedEventArgs> selectionChangedCommand;

        public Command<ItemSelectionChangedEventArgs> SelectionChangedCommand
        {
            get { return selectionChangedCommand; }
            set { selectionChangedCommand = value; }
        }

        private async Task ExecuteCambiarEstado(ItemSelectionChangedEventArgs obj)
        {
            var labor = obj.AddedItems[0] as LaborModel;

            if (labor.Fase.Equals("Fertilización"))
                await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new AplicacionPage()));

            var estadoNuevo = SiguienteEstado(labor.Estado);
            var res = await _userDialogs.ConfirmAsync(
                      $"¿Está seguro de cambiar el estado a {estadoNuevo}.",
                      "Cambiar estado", "Aceptar", "Cancelar");

            var datos = new LaborSimpleModel
            {
                Id = labor.Id,
                Estado = estadoNuevo
            };

            if (res)
            {
                var cambioEstadoRealizado = await _laborService.CambiarEstado(datos);
                if (cambioEstadoRealizado)
                    await _userDialogs.AlertAsync("Cambio realizado correctamente");
                else
                    await _userDialogs.AlertAsync("No se pudo realizar el cambio de estado.");
            }
        }

        private ObservableRangeCollection<LaborModel> _labores;
        public ObservableRangeCollection<LaborModel> Labores
        {
            get
            {
                return _labores;
            }
            set
            {
                _labores = value;
                base.OnPropertyChanged();
            }
        }


        public ICommand CargarDatosCommand { get; }


        public async Task CargarDatos()
        {
            var labores = await _laborService.ObtenerTodos();

            if (labores != null)
                Labores.AddRange(labores);
        }

        private string SiguienteEstado(string estado)
        {
            var estados = new Dictionary<string, string>()
            {
                { "En espera","Realizando" },
                { "Realizando","Terminado" },
                { "Cancelado","Terminado" }
            };
            return estados[estado];
        }



        public void CargarLaboresMock()
        {
            Labores = new ObservableRangeCollection<LaborModel> {
                         new LaborModel
                         {
                             Nombre = "Pega de surcos y bordos",
                             Estado = "En proceso",
                             Fecha = "03/Abril/2019",
                             Fase = "Preparacion de terreno"
                         },
                          new LaborModel
                         {
                             Nombre = "Canalizacón y bordeo" ,
                             Estado = "Cancelado",
                             Fecha = "03/Abril/2019",
                             Fase = "Preparacion de terreno"
                         },
                           new LaborModel
                         {
                             Nombre = "Surcado",
                             Estado = "En espera",
                             Fecha = "05/Abril/2019",
                             Fase = "Preparacion de terreno"
                         },
                          new LaborModel
                        {
                            Nombre = "Anális de suelo",
                            Estado = "En espera",
                            Fecha = "06/Abril/2019",
                            Fase = "Fertilización"
                        },
                             new LaborModel
                        {
                            Nombre = "Ferilización de presiembra",
                            Estado = "En espera",
                            Fecha = "07/Abril/2019",
                            Fase = "Fertilización"
                        },
                                new LaborModel
                        {
                            Nombre = "Permiso de siembra",
                            Estado = "En espera",
                            Fecha = "08/Abril/2019",
                            Fase = "Siembra"
                        },
                                   new LaborModel
                        {
                            Nombre = "Sembrar",
                            Estado = "En espera",
                            Fecha = "09/Abril/2019",
                            Fase = "Siembra"
                        },

        };
        }

    }
}