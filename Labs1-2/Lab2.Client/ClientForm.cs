using System;
using System.Text;
using System.Windows.Forms;
using ModelMessage = Lab2.Models.Message;
using ModelCommandType = Lab2.Models.CommandType;

namespace Lab2.Client
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net.Sockets;

    using Lab2.Models;

    public partial class ClientForm : Form
    {
        private BindingList<FuelRow> _data;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                var _connection = ClientConnection.Instance;

                _connection.Send(new ModelMessage { Type = ModelCommandType.GetAllRow });

                var answer = _connection.ReceiveMessage();

                this.SetData(answer.Content as List<FuelRow>);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Server is not running!");
            }

            //var button = (Button)sender;
            //button.Enabled = false;
        }

        private void SetData(List<FuelRow> fuelRows)
        {
            this._data = new BindingList<FuelRow>(fuelRows);
            this.dataGridView1.DataSource = this._data;
            this.dataGridView1.Columns[1].ReadOnly = true;
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    ClientConnection.Instance.Send(new Message() { Type = CommandType.DeleteRow, Content = row.DataBoundItem as FuelRow });
                    this.dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 1)
            {
                this.dataGridView1.CurrentCell.Value = DateTime.Now;
            }
        }

        private void DataGriView1_UserAddedRow(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (this.dataGridView1.RowCount > 1)
            {
                this.dataGridView1.Columns[1].ReadOnly = false;
                this.dataGridView1.Rows[e.RowIndex].Cells[1].Value = DateTime.Now;
                this.dataGridView1.Columns[1].ReadOnly = true;

                //e. .Row.Cells[1].Value = DateTime.Now;
            }
        }

        //private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        //{
        //    // Saving the 'Selected Date on Calendar' into DataGridView current cell  
        //    this.dataGridView1.CurrentCell.Value = this.oDateTimePicker.Text.ToString();
        //}

        //private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        //{
        //    // Hiding the control after use   
        //    this.oDateTimePicker.Visible = false;
        //}

    }
}
