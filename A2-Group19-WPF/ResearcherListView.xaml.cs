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

namespace A2_Group19_WPF
{
	/// <summary>
	/// Interaction logic for ResearcherListView.xaml
	/// </summary>
	public partial class ResearcherListView : UserControl
	{
		/// <summary>
		/// Controller class responsible for this section of the application
		/// </summary>
		private readonly ResearcherController controller;

		/// <summary>
		/// Event handler that fires to redirect the user view a researcher's details
		/// </summary>
		public event EventHandler LoadResearcherDetailsEvent;

		/// <summary>
		/// Retrieve or set the researcher currently selected in the list
		/// </summary>
		public Researcher SelectedResearcherMember
		{
			get => (Researcher)ResearcherList.SelectedItem;
			set => ResearcherList.SelectedItem = value;
		}

		/// <summary>
		/// Initialise the component
		/// </summary>
		public ResearcherListView()
		{
			controller = (ResearcherController)Application.Current.FindResource("ResearcherController");
			InitializeComponent();
		}

		/// <summary>
		/// Filter the researcher list to only show researchers in a particular category
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectCategory(object sender, SelectionChangedEventArgs e)
		{
			controller.CurrentCategoryFilter = (Category)CategoryFilter.SelectedItem;
			controller.ApplyFilters();
		}

		/// <summary>
		/// Filter the researcher list to only show those with names matching specified search text
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FilterByName(object sender, TextChangedEventArgs e)
		{
			controller.CurrentNameFilter = NameFilter.Text;
			controller.ApplyFilters();
		}

		/// <summary>
		/// Handle a request to load the details for a specified researcher
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ResearcherSelectedHandler(object sender, SelectionChangedEventArgs e)
		{
			LoadResearcherDetailsEvent?.Invoke(sender, e);
		}
	}
}
