using eus6.WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eus6
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Actulizar : ContentPage
	{
        public Actulizar (string codigo, string nombre, string apellido, string edad)
		{
			InitializeComponent ();
            
       
            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad;
            
        }
       
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                byte[] res = client.UploadValues("http://192.168.100.37/moviles/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);
                DisplayAlert("Alerta", "Dato Eliminado", "Cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                client.UploadValues("http://192.168.100.37/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                DisplayAlert("Alerta", "Dato actulizado correctamente ", "ok");
                 Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        

    }
}