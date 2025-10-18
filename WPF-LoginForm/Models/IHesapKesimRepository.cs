using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.Models
{
    public interface IhesapkesimRepository
    {
        //bool AuthenticateUser(NetworkCredential credential);
        void Add(hesapkesimModel hesapkesimModel);
        void Edit(hesapkesimModel hesapkesimModel);
        void Remove(hesapkesimModel hesapkesimModel);
        hesapkesimModel GetById(int id);
        hesapkesimModel GetByhesapkesimKodu(string hesapkesimkodu);
        DataTable GetTableByhesapkesimKodu(string hesapkesimkodu);
        IEnumerable<hesapkesimModel> GetByAll();
        //...
    }
}
