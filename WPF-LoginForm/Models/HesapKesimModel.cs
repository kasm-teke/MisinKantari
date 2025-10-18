using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Models
{
    public class hesapkesimModel : INotifyPropertyChanged
    {
        private string _id;
        private string _firmahesapkesimKodu;
        private string _tanim;
        private string _revNo;
        private string _teknikBilgiPaketi;
        private string _hesapkesimTuru;
        private string _teknikCizimYolu;
        private string _veri3DYolu;
        private string _tedarikci;
        private string _termin;
        private string _stokMiktari;
        private string _minSiparis;
        private string _tarih;



        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(_id));
                }
            }
        }
        public string FirmahesapkesimKodu
        {
            get { return _firmahesapkesimKodu; }
            set
            {
                if (_firmahesapkesimKodu != value)
                {
                    _firmahesapkesimKodu = value; OnPropertyChanged(nameof(_firmahesapkesimKodu));
                }
            }
        }
        public string Tanim
        {
            get { return _tanim; }
            set
            {
                if (_tanim != value)
                {
                    _tanim = value; OnPropertyChanged(nameof(_tanim));
                }
            }
        }
        public string RevNo
        {
            get { return _revNo; }
            set
            {
                if (_revNo != value)
                {
                    _revNo = value; OnPropertyChanged(nameof(_revNo));
                }
            }
        }
        public string TeknikBilgiPaketi
        {
            get { return _teknikBilgiPaketi; }
            set
            {
                if (_teknikBilgiPaketi != value)
                {
                    _teknikBilgiPaketi = value; OnPropertyChanged(nameof(_teknikBilgiPaketi));
                }
            }
        }
        public string hesapkesimTuru
        {
            get { return _hesapkesimTuru; }
            set
            {
                if (_hesapkesimTuru != value)
                {
                    _hesapkesimTuru = value; OnPropertyChanged(nameof(_hesapkesimTuru));
                }
            }
        }
        public string TeknikCizimYolu
        {
            get { return _teknikCizimYolu; }
            set
            {
                if (_teknikCizimYolu != value)
                {
                    _teknikCizimYolu = value; OnPropertyChanged(nameof(_teknikCizimYolu));
                }
            }
        }
        public string Veri3DYolu
        {
            get { return _veri3DYolu; }
            set
            {
                if (_veri3DYolu != value)
                {
                    _veri3DYolu = value; OnPropertyChanged(nameof(_veri3DYolu));
                }
            }
        }
        public string Tedarikci
        {
            get { return _tedarikci; }
            set
            {
                if (_tedarikci != value)
                {
                    _tedarikci = value; OnPropertyChanged(nameof(_tedarikci));
                }
            }
        }
        public string Termin
        {
            get { return _termin; }
            set
            {
                if (_termin != value)
                {
                    _termin = value; OnPropertyChanged(nameof(_termin));
                }
            }
        }
        public string StokMiktari
        {
            get { return _stokMiktari; }
            set
            {
                if (_stokMiktari != value)
                {
                    _stokMiktari = value; OnPropertyChanged(nameof(_stokMiktari));
                }
            }
        }
        public string MinSiparis
        {
            get { return _minSiparis; }
            set
            {
                if (_minSiparis != value)
                {
                    _minSiparis = value; OnPropertyChanged(nameof(_minSiparis));
                }
            }
        }
        public string Tarih
        {
            get { return _tarih; }
            set
            {
                if (_tarih != value)
                {
                    _tarih = value; OnPropertyChanged(nameof(_tarih));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

    
    }

    public class hesapkesimElementModel
    { 
        public string tanim{ get; set; } 
        public string value { get; set; }

    }


   
}
