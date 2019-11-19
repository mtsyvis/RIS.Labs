using System;
using System.Text;
using System.Windows.Forms;
using ModelMessage = Lab2.Models.Message;
using ModelCommandType = Lab2.Models.CommandType;

namespace Lab2.Client
{
    using System.Collections.Generic;
    using System.Net.Sockets;

    using Lab2.Models;

    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            var _connection = ClientConnection.Instance;

            _connection.Send(new ModelMessage { Type = ModelCommandType.GetAllRow });

            var answer = _connection.ReceiveMessage();

            this.SetData(answer.Content as List<FuelRow>);

            //var button = (Button)sender;
            //button.Enabled = false;
        }

        private void SetData(List<FuelRow> fuelRows)
        {
            this.dataGridView1.DataSource = fuelRows;
        }
    }
}
