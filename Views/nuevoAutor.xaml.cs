using System.Collections.ObjectModel;

namespace Tarea_1._3_Aplicacion_de_Autor.Views;

public partial class nuevoAutor : ContentPage
{
    //Clase que permite guardar objetos que estan vinculados a un elemento de interface
    ObservableCollection<string> countries;

    Controllers.AutorController controller;
    string nacionalidad;
    public nuevoAutor()
    {
        InitializeComponent();

        controller = new Controllers.AutorController();

        countries = new ObservableCollection<string>
            {
                "Argentina",
                "Belize",
                "Costa Rica",
                "El Salvador",
                "Guatemala",
                "Honduras",
                "Nicaragua",
                "Panama",
                "Mexico",
                "Colombia"
        };

        countryPicker.ItemsSource = countries;
    }

    public nuevoAutor(Controllers.AutorController dbPath)
    {
        InitializeComponent();
        controller = dbPath;

        countries = new ObservableCollection<string>
            {
                "Argentina",
                "Belize",
                "Costa Rica",
                "El Salvador",
                "Guatemala",
                "Honduras",
                "Nicaragua",
                "Panama",
                "Mexico",
                "Colombia"
            };

        countryPicker.ItemsSource = countries;
    }

    private void countryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        nacionalidad = countryPicker.SelectedItem as string;
    }

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {

        string Nombres = txtNombres.Text;

        if (string.IsNullOrEmpty(Nombres))
        {
            await DisplayAlert("Error", "Porfavor ingrese el nombre del autor", "OK");
            return;
        } else if (string.IsNullOrEmpty(nacionalidad)) 
        {
            await DisplayAlert("Error", "Porfavor seleccione la nacionalidad del autor", "OK");
            return;
        }

        var autor = new Models.Autor
        {
            Nombres = txtNombres.Text,
            Nacionalidad = nacionalidad
        };

        try
        {
            if (controller != null)
            {
                if (await controller.storeAutor(autor) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Ingresado con Exito!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Ocurrio un Error", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrio un Error: {ex.Message}", "OK");
        }
    }

    private void btnRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}