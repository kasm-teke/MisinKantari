using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_LoginForm.Views;

namespace WPF_LoginForm.Views
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           switch ((ApplicationPage)value) 
            {
                case ApplicationPage.AnaMenuPage: return new AnaMenuView();
                case ApplicationPage.hesapkesimPage: return new hesapkesimView();
                case ApplicationPage.SiparisPage: return new SiparisView();
                case ApplicationPage.KantarExcelPage: return new KantarExcelView();
                case ApplicationPage.FaturaPage: return new FitatGirisView();
                case ApplicationPage.AyarlarPage: return new AyarlarView();
                //case ApplicationPage.hesapkesimDetayPage: return new hesapkesimDetayView();


                default: Debugger.Break(); return null;

            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
