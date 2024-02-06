
namespace Tarea_1._3_Aplicacion_de_Autor
{
    public partial class App : Application
    {
        public static Controllers.AutorController AutorController { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            AutorController = new Controllers.AutorController();
        }
    }
}
