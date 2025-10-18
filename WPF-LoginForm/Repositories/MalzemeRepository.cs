using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WPF_LoginForm.Models;
using WPF_LoginForm.Views;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WPF_LoginForm.Repositories
{
    public class hesapkesimRepository : RepositoryBase, IhesapkesimRepository
        {
        public void Add(hesapkesimModel hesapkesimModel)
        {

           


        }


        public void Edit(hesapkesimModel hesapkesimModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<hesapkesimModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public hesapkesimModel GetById(int id)
        {
            hesapkesimModel hesapkesim = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                string commandstring = $"select * from [ENFAPRJDB].dbo.hesapkesim where ID like '%{id}%'; ";
                command.Connection = connection;
                command.CommandText = commandstring;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hesapkesim = new hesapkesimModel()
                        {
                            Id = reader[0].ToString(),
                            FirmahesapkesimKodu = reader[1].ToString(),
                            Tanim = reader[2].ToString(),
                            RevNo = reader[3].ToString(),
                            TeknikBilgiPaketi = reader[4].ToString(),
                            hesapkesimTuru = reader[5].ToString(),
                            TeknikCizimYolu = reader[6].ToString(),
                            Veri3DYolu = reader[7].ToString(),
                            Tedarikci = reader[8].ToString(),
                            Termin = reader[9].ToString(),
                            StokMiktari = reader[10].ToString(),
                            MinSiparis = reader[11].ToString(),
                            Tarih = reader[12].ToString(),

                        };
                    }
                }
            }
            return hesapkesim;
        }
        public hesapkesimModel GetByhesapkesimKodu(string hesapkesimkodu)
        {
            hesapkesimModel hesapkesim = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "select *from [FirmahesapkesimKodu] where hesapkesimkodu=@hesapkesimkodu";
                command.Parameters.Add("@hesapkesimkodu", SqlDbType.NChar).Value = hesapkesimkodu;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hesapkesim = new hesapkesimModel()
                        {
                            Id = reader[0].ToString(),
                            FirmahesapkesimKodu = reader[1].ToString(),
                            Tanim = reader[2].ToString(),
                            RevNo = reader[3].ToString(),
                            TeknikBilgiPaketi = reader[4].ToString(),
                            hesapkesimTuru = reader[5].ToString(),
                            TeknikCizimYolu = reader[6].ToString(),
                            Veri3DYolu = reader[7].ToString(),
                            Tedarikci = reader[8].ToString(),
                            Termin = reader[9].ToString(),
                            StokMiktari= reader[10].ToString(),
                            MinSiparis = reader[11].ToString(),
                            Tarih = reader[12].ToString(),

                        };
                    }
                }
            }
            return hesapkesim;
        }

       


        public DataTable GetTableByhesapkesimKodu( string hesapkesimKodu )
        {
          
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                string commandstring = $"select * from [ENFAPRJDB].dbo.Malzeme where FirmaMalzemeKodu like '%{hesapkesimKodu}%'; ";
                command.Connection = connection;
                command.CommandText = commandstring;
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command.CommandText,connection);

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();
                return dataTable;

            }
            
        }
        public void Remove(hesapkesimModel hesapkesim)
        {
            throw new NotImplementedException();
        }






    }
}
