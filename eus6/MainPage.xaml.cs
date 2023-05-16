using eus6.WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eus6
{
    public partial class MainPage : ContentPage
    {
          

        private const string Url = "http://192.168.100.37/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<eus6.WS.Datos> _post;
        public MainPage()
        {

            InitializeComponent();
            Obtener();
           
        }
        public async void Obtener()
        {
            var content = await client.GetStringAsync(Url);
            List<eus6.WS.Datos> posts = JsonConvert.DeserializeObject<List<eus6.WS.Datos>>(content);
            _post = new ObservableCollection<eus6.WS.Datos>(posts);
            MyListView.ItemsSource = posts;
        }

        private void bntGet_Clicked(object sender, EventArgs e)
        {
            var mensaje = "BIENVENIDO";
            DependencyService.Get<Mensaje>().longAlert(mensaje);
            Navigation.PushAsync(new Registro());
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string codigo = (e.SelectedItem as Datos).codigo.ToString();
            string nombre = (e.SelectedItem as Datos).nombre;
            string apellido = (e.SelectedItem as Datos).apellido;
            string edad = (e.SelectedItem as Datos).edad.ToString();
            Navigation.PushAsync(new Actulizar(codigo, nombre, apellido, edad));
        }
    }
}
