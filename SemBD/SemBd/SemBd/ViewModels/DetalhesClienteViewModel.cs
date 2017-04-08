using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SemBd.ViewModels
{
    public class DetalhesClienteViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _codigo;
        public string Codigo
        {
            get { return _codigo; }
            set { SetProperty(ref _codigo, value); }
        }

        private string _endereco;
        public string Endereco
        {
            get { return _endereco; }
            set { SetProperty(ref _endereco, value); }
        }

        private string _site;
        public string Site
        {
            get { return _site; }
            set { SetProperty(ref _site, value); }
        }

        public DetalhesClienteViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"];

            if (parameters.ContainsKey("id"))
                Codigo = (string)parameters["id"];

            if (parameters.ContainsKey("endereco"))
                Endereco = (string)parameters["endereco"];

            if (parameters.ContainsKey("site"))
                Site = (string)parameters["site"];

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
