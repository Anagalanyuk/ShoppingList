using System;
using System.Windows.Forms;

namespace ShoppingList
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MainForm());

			MainForm view = new MainForm();
			ShoppingListService service = new ShoppingListService();

			ShoppingListPresenter presenter = new ShoppingListPresenter(view, service);
			presenter.Run();
		}
	}
}