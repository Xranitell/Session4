using Session4.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4
{
    public partial class InventoryManagmentForm : Form
    {
        public InventoryManagmentForm()
        {
            InitializeComponent();
        }

        private void InventoryManagmentForm_Load(object sender, EventArgs e)
        {
            GridUpdate();
        }


        public void GridUpdate()
        {
            dataGridViewGuna.DataSource = DBManager.GetData("SELECT Assets.AssetSN, Assets.AssetName, EmergencyMaintenances.EMReportDate, { fn CONCAT(Employees.FirstName, Employees.LastName) } AS [Employee Full Name], Departments.Name as Department FROM EmergencyMaintenances left JOIN Assets ON EmergencyMaintenances.AssetID = Assets.ID left JOIN Departments ON Departments.ID = Assets.DepartmentLocationID left JOIN Employees ON Assets.EmployeeID = Employees.ID wHERE  (EmergencyMaintenances.EMEndDate IS NULL) order by PriorityID desc,EMReportDate asc");
            AddNewColumn("Edit", 6);
            AddNewColumn("Remove", 7);
            
        }

        void AddNewColumn(string text,int index)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

            buttonColumn.Name = text;
            buttonColumn.Text = text;
            buttonColumn.UseColumnTextForButtonValue = true;

            if (dataGridViewGuna.Columns[text] == null)
            {
                dataGridViewGuna.Columns.Insert(index, buttonColumn);
            }
            dataGridViewGuna.CellClick += dataGridViewGuna_CellClick;
        }

        private void dataGridViewGuna_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewGuna.Columns["Edit"].Index)
            {

            }
            else if(e.ColumnIndex == dataGridViewGuna.Columns["Remove"].Index)
            {

            }
        }
    }
}
