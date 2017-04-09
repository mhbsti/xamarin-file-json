using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using static SemBd.App;

namespace SemBd.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<Cliente> _clientes;
        public List<Cliente> Clientes
        {
            get { return _clientes; }
            set { SetProperty(ref _clientes, value); }
        }

        private readonly INavigationService _navigationService;
        public DelegateCommand<Cliente> ClienteSelectCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            //carregando nosso Json
            var content = DependencyService.Get<ISaveAndLoad>().LoadText("clientes.json");
            // Convertendo nosso json para uma lista de objetos
            Clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);



            _navigationService = navigationService;
            this.ClienteSelectCommand = new DelegateCommand<Cliente>((cliente) =>
            {
                // estamos passando os dados via deep link.
                navigationService.NavigateAsync($"DetalhesCliente?title={cliente.Nome}&id={cliente.Codigo}&endereco={cliente.Endereco}&site={cliente.Site}");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"];
        }
    }
}
