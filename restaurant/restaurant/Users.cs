using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Con = new Functions(); 
            ShowUsers();    
        }
        Functions Con;
        private void ShowUsers()
        {
            try
            {
                string Query = "select * from UsersTb1";
                UsersList.DataSource = Con.GetData(Query);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PasswordTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text =="" || AddTb.Text == "") 
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text; 
                    string Phone = PhoneTb.Text;
                    string Adress = AddTb.Text;
                    string Query = "insert into UsersTb1 values('{0}',{1},{2},'{3},{4}')";
                    Query = string.Format(Query, Name, Gender, Password,Phone,Adress);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Added!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;

        private void UsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = UsersList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = UsersList.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTb.Text = UsersList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = UsersList.SelectedRows[0].Cells[4].Value.ToString();
            AddTb.Text = UsersList.SelectedRows[0].Cells[5].Value.ToString();

            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UsersList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PasswordTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Adress = AddTb.Text;
                    string Query = "update UsersTb1 set UName ='{0}',UGen = '{1}',UPass '{2}',UPhone'{3}',UAdress = '{4}' where UId = {5})";
                    Query = string.Format(Query, Name, Gender, Password, Phone, Adress,key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Uptaded!!!");

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
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Adress = AddTb.Text;
                    string Query = "delete from UsersTb1 where UId = {0})";
                    Query = string.Format(Query,key);
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Deleted!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }
    }
}
