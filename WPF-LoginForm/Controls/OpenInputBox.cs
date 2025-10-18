using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows;

namespace WPF_LoginForm.Controls
{


public class OpenInputBox : Window
{
    public string Value { get; private set; }

    public OpenInputBox(string prompt)
    {
        Title = "Girdi Kutusu";
        Width = 300;
        Height = 150;

        var stackPanel = new StackPanel();
        stackPanel.Children.Add(new TextBlock { Text = prompt, Margin = new Thickness(10) });

        var textBox = new TextBox { Margin = new Thickness(10) };
        stackPanel.Children.Add(textBox);

        var button = new Button { Content = "Tamam", Width = 60, Margin = new Thickness(10) };
        button.Click += (s, e) =>
        {
            Value = textBox.Text;
            DialogResult = true;
            Close();
        };
        stackPanel.Children.Add(button);

        Content = stackPanel;
    }
}
}