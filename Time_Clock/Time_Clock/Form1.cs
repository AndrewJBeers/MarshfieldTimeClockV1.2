using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._CIS260_TimeclockDataSet);

        }

        private void employeeBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._CIS260_TimeclockDataSet);

        }

        private void employeeBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._CIS260_TimeclockDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CIS260_TimeclockDataSet.Log_Table' table. You can move, or remove it, as needed.
            this.log_TableTableAdapter.Fill(this._CIS260_TimeclockDataSet.Log_Table);
            // TODO: This line of code loads data into the '_CIS260_TimeclockDataSet.Employee_Role' table. You can move, or remove it, as needed.
            this.employee_RoleTableAdapter.Fill(this._CIS260_TimeclockDataSet.Employee_Role);
            // TODO: This line of code loads data into the '_CIS260_TimeclockDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this._CIS260_TimeclockDataSet.Employee);

        }
    }
}
