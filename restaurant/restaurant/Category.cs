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
    public partial class Category : Form
    {
        Functions Con;
        public Category()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();   
        }
        private void ShowCategories()
        {
            try
            {
                string Query = "select * from CategoryTb1";
                CategoriesList.DataSource = Con.GetData(Query);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "" || DescTb.Text == "") 
            {
                MessageBox.Show("Missing Data!!!");
             }
            else
            {
                try
                {
                    string Category = CatNameTb.Text;
                    string Desc = DescTb.Text;  
                    string Query = "insert into CategoryTb1 values('{0}',{1}')";
                    Query = string.Format(Query, Category, Desc);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Added!!!");

                }
                catch (Exception Ex) 
                {
                 MessageBox.Show(Ex.Message);     
                }
            }
        }
        int key = 0;    
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            DescTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            if(CatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "" || DescTb.Text == "") 
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Category = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "Update CategoryTb1 set CatName '{0}',CatDesc{1}'where CatCode={2}";
                    Query = string.Format(Query, Category, Desc,key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Updated!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)             {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Category = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "Delete from CategoryTb1 where CatCode ={0}";
                    Query = string.Format(Query,key );
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Deleted!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Category_Load(object sender, EventArgs e)
        {

        }
    }
}
