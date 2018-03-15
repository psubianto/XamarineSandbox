using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinFormSandbox
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public string IncidentNo { get; set; }
        public string WarrantNo { get; set; }
        public ICommand SearchWarrantCommand { get; }

        public ObservableCollection<Warrant> WarrantList = new ObservableCollection<Warrant>();
        public Warrant WarrantSelected { get; set; }


        public MainPageViewModel()
        {
            IncidentNo = "201705030186";
            WarrantNo = "852741321";

            SearchWarrantCommand = new Command(ExecuteSearchWarrantCommand);
            WarrantList.Add( new Warrant() { WarrantNo = "No valid warrant", WarrantDate = new DateTime(1900, 1, 1) } );
        }

        private void ExecuteSearchWarrantCommand()
        {
            WarrantList.Clear();
            WarrantList.Add(new Warrant() { WarrantNo = "8527413215", WarrantDate = new DateTime(2017, 5, 3) });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Warrant
    {
        public string WarrantNo { get; set; }
        public DateTime? WarrantDate { get; set; }
    }
}
