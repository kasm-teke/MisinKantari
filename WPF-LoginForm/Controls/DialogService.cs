using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_LoginForm.Views;


namespace WPF_LoginForm.Controls
{
   

    public interface IDialogService
    {
        void ShowDialog(string n, string xtitle, Action<string> callback );
        void ShowDialog<TViewModel>(Action<string> callback);

    }   
    class DialogService : IDialogService
    {

        static Dictionary<Type,Type> _mappings = new Dictionary<Type,Type>();

        public static void RegisterDialog<Tview,TviewModel>()
        {
            _mappings.Add(typeof(TviewModel), typeof(Tview));

        }

        public string ShowInputBox(string prompt)
        {
            var inputBox = new OpenInputBox(prompt);
            if (inputBox.ShowDialog() == true)
            {
                return inputBox.Value;
            }
            return null;
        }

        public void ShowDialog(string n , string xtitle, Action<string> c)
        {
            var type = Type.GetType($"WPF_LoginForm.Views.{n}");
            ShowDialogInternal(type, c);
        }

        public void ShowDialog<TViewModel>(Action<string> c)
        {
            var type = _mappings[typeof(TViewModel)]; 
            ShowDialogInternal(type, c);    

        }



        private static void ShowDialogInternal(Type t, Action<string> c)
        {
            var dialog = new DialogViewWindow();
          

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                c(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            dialog.Content = Activator.CreateInstance(t);
           
            dialog.ShowDialog();
        }

       
    }
}
