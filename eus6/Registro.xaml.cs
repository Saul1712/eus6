using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eus6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();

        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();

                //parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                WebClient client = new WebClient();
                client.UploadValues("http://192.168.100.37/moviles/post.php", "POST", parametros);
                await DisplayAlert("Alerta", "Dato insertado correctamente ", "ok");
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

    }

}