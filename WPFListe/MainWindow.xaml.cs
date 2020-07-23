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
			BindingGroup.CommitEdit();
			//(Osoba)DataContext izaziva exception ako nije u stanju da razume DataContext kao Osobu
			//DataContext as Osoba stvara null vrednost ako nije u stanju da razume DataContext kao Osobu
			
			if (DataContext is Osoba o)
			{
				//is, ovaj gore u ifu :), radi iducu liniju kao II korak
				//Osoba o = DataContext as Osoba;
				if (!Osobe.Contains(o))
				{
					Osobe.Add(o);
				}
			}
			DataContext = new Osoba();
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
