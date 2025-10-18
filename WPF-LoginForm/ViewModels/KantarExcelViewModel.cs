using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Input;
using ExcelDataReader;
using Microsoft.Win32;
using WPF_LoginForm.Models;

namespace WPF_LoginForm.ViewModels
{
    public class KantarExcelViewModel : ViewModelBase
    {
        private DataTable _dataTable;
        private DataRowView _selectedItem;
        public DataTable ExcelTablo
        {
            get => _dataTable;
            set
            {
                _dataTable = value;
                OnPropertyChanged(nameof(ExcelTablo));
            }
        }

        public ICommand SelectExcelFileCommand { get; }

        public KantarExcelViewModel()
        {
            SelectExcelFileCommand = new RelayCommand(SelectExcelFile);
            

        }

        private void SelectExcelFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                LoadExcelData(filePath);
            }
        }

        private void LoadExcelData(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true // İlk satırı başlık olarak kullan
                        }
                    });

                    ExcelTablo = ds.Tables[0];
                }
            }

            DataTableHelper.UpdateDateColumn(ExcelTablo, 1, 2);
            DataTableHelper.UpdateDateColumn(ExcelTablo, 3, 4);
            ExcelTablo.Columns.RemoveAt(1);
            ExcelTablo.Columns.RemoveAt(2);
            DataTableHelper.RemoveHarfFromColumn(ExcelTablo, 11, "RT");
            DataTableHelper.RemoveHarfFromColumn(ExcelTablo, 11, " ");
            DataTableHelper.RemoveHarfFromColumn(ExcelTablo, 11, "rt");
            DataTableHelper.FormatColumnAsFloat(ExcelTablo, 11);
        }

        public DataRowView SelectedItem
        {
            get
            {
                if (_selectedItem != null)
                {
                    //hesapkesimId = _selectedItem.Row.ItemArray[0];

                }
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));

            }
        }
    }

    public static class DataTableHelper
    {
        public static void UpdateDateColumn(DataTable dataTable, int dateColumnIndex, int timeColumnIndex)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row[dateColumnIndex] != DBNull.Value && row[timeColumnIndex] != DBNull.Value)
                {
                    DateTime dateValue = Convert.ToDateTime(row[dateColumnIndex]);
                    DateTime timeValue = Convert.ToDateTime(row[timeColumnIndex]);
                    DateTime combinedValue = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day, timeValue.Hour, timeValue.Minute, timeValue.Second);
                    row[timeColumnIndex] = combinedValue;
                }
            }
        }

        public static void RemoveHarfFromColumn(DataTable dataTable, int columnIndex, string harf)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row[columnIndex] != DBNull.Value)
                {
                    string cellValue = row[columnIndex].ToString();
                    row[columnIndex] = cellValue.Replace(harf, "").Trim();
                }
            }
        }

        public static void FormatColumnAsFloat(DataTable dataTable, int columnIndex)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row[columnIndex] != DBNull.Value)
                {
                    if (float.TryParse(row[columnIndex].ToString(), out float result))
                    {
                        row[columnIndex] = result.ToString("0.0");
                    }
                }
                else
                {
                    row[columnIndex] = DBNull.Value; // Alternatif çözüm
                }
            }
        }
    }
}
