using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewApp.Core;
using ViewApp.Models;

namespace ViewApp
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            DisplayPersons();
        }

        private void DisplayPersons()
        {
            //Привязка данных к DGV
            var bindingList = new BindingList<Person>(XmlModule.persons);
            BindingSource source = new BindingSource(bindingList, null);
            dgv_PersonList.DataSource = source;


            dgv_PersonList.Columns["Id"].HeaderText = "Id";
            dgv_PersonList.Columns["LastName"].HeaderText = "Фамилия";
            dgv_PersonList.Columns["Name"].HeaderText = "Отчество";
            dgv_PersonList.Columns["ClassId"].HeaderText = "Категория";
            dgv_PersonList.Columns["Shootings"].HeaderText = "Промахов";
            dgv_PersonList.Columns["PenaltyLaps"].HeaderText = "Штрафные";

            dgv_PersonList.Columns["Shootings"].Visible = false;
            dgv_PersonList.Columns["PenaltyLaps"].Visible = false;

            dgv_PersonList.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_OneTwoThree_Click(object sender, EventArgs e)
        {
            
        }
    }
}
