using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFListe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Osoba> Osobe = new ObservableCollection<Osoba>();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = new Osoba();
			BindingGroup = new BindingGroup();

			Imenik.ItemsSource = Osobe;
		}

		private void Unos(object sender, RoutedEventArgs e)
		{
			Editor ed = new Editor();
			ed.Owner = this;
			
			if (ed.ShowDialog().Value)
			{
				Osobe.Add(ed.DataContext as Osoba);
			}
		}

		private void Izmena(object o, RoutedEventArgs zklj)
		{
			if (Imenik.SelectedItem != null)
			{
				Editor ed = new Editor();
				ed.Owner = this;
				ed.DataContext = Imenik.SelectedItem;
				ed.ShowDialog();
			}
		}

		private void Obrisi(object sender, RoutedEventArgs e)
		{
			Osobe.Remove(Imenik.SelectedItem as Osoba);
		}

		private void Selekcija(object sender, SelectionChangedEventArgs e)
		{
			if (Imenik.SelectedItem != null) 
			{
				DataContext = Imenik.SelectedItem;
			}
		}
	}
}
