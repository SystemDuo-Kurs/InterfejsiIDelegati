using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace InterfejsiIDelegati
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Osoba o = new Osoba { Ime = "Pera" };
		public MainWindow()
		{
			InitializeComponent();
			DataContext = o;

			o.DogodilaSePromena += Nesto;
		}

		private void Klik(object sender, RoutedEventArgs e)
		{
			o.Ime = "Nesto drugo";
		}
		private void Nesto(string nst)
		{
			MessageBox.Show($"Promenilo se {nst}!");
		}
	}
	public class Osoba : INotifyPropertyChanged
	{
		private string _ime;
		public string Ime 
		{ 
			get => _ime; 
			set
			{
				_ime = value;
				DogodilaSePromena?.Invoke("Ime");
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ime"));
			}
		}

		public event Action<string> DogodilaSePromena;
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
