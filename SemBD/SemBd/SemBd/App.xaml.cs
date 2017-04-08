using Prism.Unity;
using SemBd.Views;
using Xamarin.Forms;
using System.Net.Http;
using Plugin.Connectivity;
using System;

namespace SemBd
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            AtualizarJson();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Clientes");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<DetalhesCliente>();
        }

        private async void AtualizarJson()
        {
            //testa se tem conexao com a internet
            bool conectacto = CrossConnectivity.Current.IsConnected;
            if (conectacto)
            {
                try
                {
                    var JsonFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>();
                    var uri = new Uri("http://67.205.189.8/mhbs/clientes.json");
                    HttpClient myClient = new HttpClient();
                    var response = await myClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        JsonFile.SaveText("clientes.json", content);
                    }
                    
                }
                catch (Exception ex)
                {

                }

            }

        }

        public class Cliente
        {
            public int Codigo { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Site { get; set; }
        }

    }
}
