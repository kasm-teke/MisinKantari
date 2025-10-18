using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_LoginForm;
using WPF_LoginForm.Controls;
using WPF_LoginForm.Models;

namespace WPF_LoginForm.ViewModels
{
    public class InputBoxViewModel : ViewModelBase
    {
        private string _value;
        private string _prompt;
       

        public string Value
        {
            get => _value;
            set { _value = value; OnPropertyChanged(nameof(Value)); }
        }

        public string Prompt
        {
            get => _prompt;
            set { _prompt = value; OnPropertyChanged(nameof(Prompt)); }
        }

        public ICommand OpenInputBoxCommand { get; }

        public InputBoxViewModel()
        {
            OpenInputBoxCommand = new RelayCommand(OpenInputBox);
        }

        private void OpenInputBox(object obj)
        {
            // Komut çalıştığında yapılacak işlemler
            string result = new DialogService().ShowInputBox("Lütfen bir değer girin:");
            if (!string.IsNullOrWhiteSpace(result))
            {
                // Gelen değeri işleyin
            }
        }
    }
}