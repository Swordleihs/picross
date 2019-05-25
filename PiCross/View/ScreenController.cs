using System.ComponentModel;

namespace View
{
    public class ScreenController : INotifyPropertyChanged
    {
        private Screen currentScreen;
        private MainWindow main;

        public ScreenController(MainWindow main)
        {
            this.currentScreen = new HomeScreen(this);
            this.main = main;
        }

        public Screen CurrentScreen
        {
            get
            {
                return this.currentScreen;
            }
            set
            {
                this.currentScreen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScreen)));
            }
        }

        public MainWindow MainScreen
        {
            get { return this.main; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
