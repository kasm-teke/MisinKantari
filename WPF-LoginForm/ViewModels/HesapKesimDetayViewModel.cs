using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;
using WPF_LoginForm.Views;

namespace WPF_LoginForm.ViewModels
{
    public class hesapkesimDetayViewModel : ViewModelBase
    {
       

       


        private  hesapkesimModel _paylasilanhesapkesimModel;

        public  hesapkesimModel PaylasilanhesapkesimModel
        {
            get { return _paylasilanhesapkesimModel; }
            set
            {
                _paylasilanhesapkesimModel = value;
              OnPropertyChanged(nameof(PaylasilanhesapkesimModel));
               
            }
           

        }

      

        public hesapkesimDetayViewModel()
        {

            PaylasilanhesapkesimModel = new hesapkesimModel();



        }
    }
}
