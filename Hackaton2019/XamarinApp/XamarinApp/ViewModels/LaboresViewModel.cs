using MvvmHelpers;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class LaboresViewModel : BaseViewModel
    {

        public LaboresViewModel()
        {
            Title = "Labores";
             Labores = new ObservableCollection<LaborGroup>();
            CargarLabores();
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }
        private ObservableCollection<LaborGroup> _labores;
        public ObservableCollection<LaborGroup> Labores
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


        public ICommand OpenWebCommand { get; }

        public void CargarLabores()
        {
            var fase1 = new LaborGroup
                {
                         new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor A"
                         },
                          new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor AAA"
                         },
                           new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor AAAA"
                         }
                };
            fase1.Heading = "Fase 1";

            var fase2 = new LaborGroup
                {
                         new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor B"
                         },
                          new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor BBB"
                         },
                           new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor BBBB"
                         }
                };
            fase2.Heading = "Fase 2";

            var fase3 = new LaborGroup
                {
                         new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor C"
                         },
                          new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor CCC"
                         },
                           new LaborModel
                         {
                             Id=1,
                             Nombre = "Labor CCCCC"
                         }
                };
            fase3.Heading = "Fase 3";

            Labores = new ObservableCollection<LaborGroup>
            {
                fase1,
                fase2,
                fase3
            };
        }
    }
}