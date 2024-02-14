using Tarea_1._3_Aplicacion_de_Autor.Views;

namespace Tarea_1._3_Aplicacion_de_Autor
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnVerAutores_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new verAutores());
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new nuevoAutor());
        }

        private void btnMapas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.pageMapas());
        }
    }

}
