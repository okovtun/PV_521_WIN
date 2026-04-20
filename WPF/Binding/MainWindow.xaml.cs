using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Binding
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public MainWindow()
		{
			DataContext = this;
			InitializeComponent();
		}
		public event PropertyChangedEventHandler PropertyChanged;
		string boundText;
		public string BoundText
		{
			get => boundText;
			set
			{
				boundText = value;
				OnPropertyChanged();
			}
		}
		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			//PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(BoundText)));
//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BoundText"));
// ? (Null-conditional operator) - используется при доступе к полям объекта, или элементам массива.
// obj?.member - если (obj == null), оператор '?' вернет 'null', в противном случае - значение поля 'member'.
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
		}

		private void BtnSet_Click(object sender, RoutedEventArgs e)
		{
			BoundText = "Default";
			txtInput.Focus();
		}
	}
}
