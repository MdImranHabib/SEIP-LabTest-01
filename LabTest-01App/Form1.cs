using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace LabTest_01App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Hashtable bookList = new Hashtable();
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string isbn = textBoxISBN.Text;
            int isbnLength = textBoxISBN.TextLength;
            string bookName = textBoxName.Text;
            int bookNameLength = textBoxName.TextLength;
            if (isbnLength == 13)
            {
                if (bookNameLength > 0)
                {
                    if (!bookList.Contains(isbn))
                    {
                        bookList.Add(isbn, bookName);
                        listBoxShowAll.Items.Add(isbn);
                        listBoxShowAll.Items.Add(bookName);
                    }
                    else
                    {
                        MessageBox.Show("This ISBN number is already exist!");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid book name.\nBook name can not be null.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ISBN number.\nISBN number should be 13 character");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (radioButtonISBN.Checked)
            {
                //textBoxSearch.Clear();
                listBoxSearchData.Items.Clear();

                string isbn = textBoxSearch.Text;

                foreach (DictionaryEntry item in bookList)
                {
                    string key = Convert.ToString(item.Key);
                    if (key == isbn)
                    {
                        listBoxSearchData.Items.Add(item.Value);
                        break;
                    }
                    else
                    {
                        listBoxSearchData.Items.Clear();
                    }
                }
            }

            else if(radioButtonName.Checked)
            {
                //textBoxSearch.Clear();
                listBoxSearchData.Items.Clear();

                string bookName = textBoxSearch.Text;

                foreach (DictionaryEntry item in bookList)
                {
                    string value = Convert.ToString(item.Value);
                    if (value == bookName)
                    {
                        listBoxSearchData.Items.Add(item.Key);
                        break;
                    }
                    else
                    {
                        listBoxSearchData.Items.Clear();
                    }

                }
                
            }
        }
    }
}
