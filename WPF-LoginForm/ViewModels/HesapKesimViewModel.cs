using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;
using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing.Printing;
using System.Data.Entity;
using System.Collections.ObjectModel;
using WPF_LoginForm.Views;
using System.Data.Entity.Core.Metadata.Edm;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using WPF_LoginForm.Controls;


namespace WPF_LoginForm.ViewModels
{
    public class HesapKesimViewModel : ViewModelBase
    {
        IDialogService _dialogService=new DialogService();

       

        private string _searchText;
        private IhesapkesimRepository hesapkesimRepository;
        private DataTable _hesapkesimtablo;
        private DataRowView _selectedItem;
        private object hesapkesimId;
        private hesapkesimModel _paylasilanhesapkesimModel;
        private ViewModelBase _hesapkesimDetayModel;



        public ViewModelBase hesapkesimDetayModel
        {
            get { return _hesapkesimDetayModel;}
            set { _hesapkesimDetayModel = value;
            OnPropertyChanged(nameof(hesapkesimDetayModel));}
        }

        public DataRowView SelectedItem
        {
            get
            {
                if (_selectedItem != null)
                {
                    hesapkesimId = _selectedItem.Row.ItemArray[0];

                }
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));

            }
        }

        public DataTable hesapkesimTablo
        {
            get { return _hesapkesimtablo; }
            set
            {
                _hesapkesimtablo = value;
                OnPropertyChanged(nameof(hesapkesimTablo));
            }
        }

        




        public string SearchText 
        {
            get
            {
                return _searchText;
            }
            set
            {

                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                if (SearchText.Length >= 3)
                {
                    SearchCommand.Execute(SearchText);
                }
               
            }
        }

        public hesapkesimModel PaylasilanhesapkesimModel 
        { 
            get
            
            { return _paylasilanhesapkesimModel; 
            } 
            set {  _paylasilanhesapkesimModel = value;
            OnPropertyChanged(nameof(PaylasilanhesapkesimModel));  }
        }

        public ICommand OpenhesapkesimDetayCommand { get; private set; }

        public ICommand SearchCommand { get; }
        public ICommand AddCommand {  get; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }



       

        public HesapKesimViewModel()
        {
          
            hesapkesimRepository = new hesapkesimRepository();
            SearchCommand = new ViewModelCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
            AddCommand = new ViewModelCommand(AddhesapkesimCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeletehesapkesimCommand);
            EditCommand = new ViewModelCommand(ExecuteEdithesapkesimCommand);
            
           




        }


      



        private bool CanExecuteSearchCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(SearchText) || SearchText.Length < 3 )
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteSearchCommand(object obj)
        {           
            hesapkesimTablo=hesapkesimRepository.GetTableByhesapkesimKodu(SearchText);
        }

        private void AddhesapkesimCommand(object obj)
        {
            hesapkesimRepository.Add(PaylasilanhesapkesimModel);
        }


        private void ExecuteDeletehesapkesimCommand(object obj)
        {
            hesapkesimRepository.Remove(PaylasilanhesapkesimModel);
        }


        private void ExecuteEdithesapkesimCommand(Object obj)
        {

            

            

            _dialogService.ShowDialog<hesapkesimDetayViewModel>(result =>
            {
                var test = result;
            });


        }
       
      
    }
}
