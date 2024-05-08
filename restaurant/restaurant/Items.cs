using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
            GetCategories();
        }
        Functions Con;
        private void ShowItems()
        {
            try
            {
                string Query = "select * from ItemTb1";
               ItemsList.DataSource = Con.GetData(Query);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void GetCategories()
        {
            string Query = "select *from CategoryTb1";
            CatCb.ValueMember = Con.GetData(Query).Columns[" CatCode"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Category = CatCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Text);
                    string Query = "insert into ItemTb1 values('{0}',{1},{2})";
                    Query = string.Format(Query, Name, Category,Price);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Added!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();

            if (CatCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Category = CatCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Text);
                    string Query = "update  ItemTb1 set ItName = '{0}',ItPrice= {1}, ItCategory = {2} where ItNum = {3})";
                    Query = string.Format(Query, Name, Category, Price,key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Updated!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Category = CatCb.SelectedValue.ToString();
                    int Price = Convert.ToInt32(PriceTb.Text);
                    string Query = "delete from ItemTb1 where ItNum = {0})";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Deletetd!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UserLbl_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }
    }
}
