using BindingBasics.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace BindingBasics.ViewModels
{
    public class ViewModel_MainPage : INotifyPropertyChanged
    {
        #region vars
        Random _r = new Random(DateTime.Now.Second);
        #endregion

        #region properties
        string _message = null;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                UpdateUI();
            }
        }

        //must use ObservableCollection<T> and not List<T>
        // ObservableCollection<T> has a built it INotifiyPropertyChanged
        // so no need to worry calling UpdateUI to refresh/reload the list.
        public ObservableCollection<Model_Person> PersonCollection { get; set; } = new ObservableCollection<Model_Person>();
        #endregion

        #region commands
        public ICommand Command_Greet { get; private set; }
        public ICommand Command_AddRandomName { get; set; }
        public ICommand Command_GreetName { get; private set; }
        #endregion

        #region ctor
        public ViewModel_MainPage()
        {
            if (Command_Greet == null) Command_Greet = new Command(Greet);
            if (Command_GreetName == null) Command_GreetName = new Command<Model_Person>(GreetPerson);
            if (Command_AddRandomName == null) Command_AddRandomName = new Command(AddRandomName);
        }
        #endregion

        #region command methods
        void Greet()
        {
            this.Message = "Hello World";
        }

        public void GreetPerson(Model_Person model)
        {
            this.Message = $"Hello {model.Name}";
        }

        void AddRandomName()
        {
            string[] names = { "Rizal", "Jose", "Juan", "Jayson", "Wala na maisip .." };

            this.PersonCollection.Add(new Model_Person()
            {
                Name = names[_r.Next(0, names.Length - 1)]
            });
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void UpdateUI([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
        #endregion
    }
}