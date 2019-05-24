using System.ComponentModel;

namespace View
{
    public class ScreenController : INotifyPropertyChanged
    {
        private Screen currentScreen;

        public ScreenController()
        {
            this.currentScreen = new HomeScreen(this);
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
