using APP_PyFinal_SebastianS.Views;

namespace APP_PyFinal_SebastianS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaProyectosPage());
        }
    }
}
