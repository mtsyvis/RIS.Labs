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
            this.addRowBox.Enabled = false;
            this.updateChangesButton.Enabled = false;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = ClientConnection.Instance;
                connection.Connect();

                connection.Send(new ModelMessage { Type = ModelCommandType.GetAllRow });

                var answer = connection.ReceiveMessage();

                this.SetData(answer.Content as List<FuelRow>);

                this.addRowBox.Enabled = true;
                this.updateChangesButton.Enabled = true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Server is not running!");
            }

            var button = (Button)sender;
            button.Enabled = false;
        }

        private void SetData(List<FuelRow> fuelRows)
        {
            this._data = new BindingList<FuelRow>(fuelRows);
            this.dataGridView1.DataSource = this._data;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this._data.RaiseListChangedEvents = false;
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

                this._data.RaiseListChangedEvents = false;
            }
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            if (this.fuelTypeTextBox.Text != string.Empty && this.fuelAmountTextBox.Text != string.Empty 
                                                          && double.TryParse(this.fuelAmountTextBox.Text, out var fuelAmount))
            {
                var row = new FuelRow()
                              {
                                  Id = Guid.NewGuid().ToString(),
                                  DateOfDelivery = DateTime.Now,
                                  FuelType = this.fuelTypeTextBox.Text,
                                  Amount = fuelAmount
                              };

                ClientConnection.Instance.Send(new Message { Type = CommandType.AddRow, Content = row });
                this._data.Add(row);
                this._data.RaiseListChangedEvents = false;
            }
        }

        private void UpdateChangesButton_Click(object sender, EventArgs e)
        {
            if (this._data.RaiseListChangedEvents)
            {
                var list = new List<FuelRow>(this._data);
                ClientConnection.Instance.Send(new Message { Type = CommandType.UpdateRow, Content = list });
                this._data.RaiseListChangedEvents = false;
            }
            else
            {
                MessageBox.Show("Nothing to update!");
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this._data.RaiseListChangedEvents = true;
        }
    }
}
