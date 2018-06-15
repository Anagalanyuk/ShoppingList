using System;
using System.Windows.Forms;

namespace ShoppingList
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void Add()
		{
			nameProduct.Text = nameProduct.Text.Trim();
			listProducts.Items.Add(nameProduct.Text);
			nameProduct.Clear();
		}
		private void addButton_Click(object sender, EventArgs e)
		{
			Add();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (listProducts.SelectedIndex >= 0)
			{
				listProducts.Items.RemoveAt(listProducts.SelectedIndex);
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (addButton.Enabled)
				{
					Add();
				}
			}
		}

		private void nameProduct_TextChanged(object sender, EventArgs e)
		{
			newProduct();

		}

		private void newProduct()
		{
			for (int i = 0; i < nameProduct.Text.Length; ++i)
			{
				if (nameProduct.Text[i] != ' ')
				{
					addButton.Enabled = true;
				}
			}
			string clone = nameProduct.Text;
			foreach (string product in listProducts.Items)
			{
				clone = nameProduct.Text.Trim();
				if (product.Equals(clone))
				{
					addButton.Enabled = false;
				}
			}
			if (nameProduct.Text.Length == 0)
			{
				addButton.Enabled = false;
			}
		}

		private void listProducts_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = listProducts.SelectedIndex;
			if (listProducts.SelectedIndex > 0)
			{
				upButton.Enabled = true;
			}
			else
			{
				upButton.Enabled = false;
			}
			if (listProducts.SelectedIndex < listProducts.Items.Count - 1)
			{
				downButton.Enabled = true;
			}
			else
			{
				downButton.Enabled = false;
			}
			deleteButton.Enabled = true;
			newProduct();
		}

		private void UpButton_Click(object sender, EventArgs e)
		{
			var clone = listProducts.Items[listProducts.SelectedIndex - 1];
			listProducts.Items[listProducts.SelectedIndex - 1] = listProducts.Items[listProducts.SelectedIndex];
			listProducts.Items[listProducts.SelectedIndex] = clone;
			listProducts.SelectedIndex = listProducts.SelectedIndex - 1;
		}

		private void DownButton_Click(object sender, EventArgs e)
		{
			var clone = listProducts.Items[listProducts.SelectedIndex + 1];
			listProducts.Items[listProducts.SelectedIndex + 1] = listProducts.Items[listProducts.SelectedIndex];
			listProducts.Items[listProducts.SelectedIndex] = clone;
			listProducts.SelectedIndex = listProducts.SelectedIndex + 1;
		}
	}
}