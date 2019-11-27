namespace Lab2.Client
{
    using System.Windows.Forms;

    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.addRowBox = new System.Windows.Forms.GroupBox();
            this.addRowButton = new System.Windows.Forms.Button();
            this.f = new System.Windows.Forms.Label();
            this.fuelAmountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fuelTypeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateChangesButton = new System.Windows.Forms.Button();
            this.filterBox = new System.Windows.Forms.GroupBox();
            this.startAmountLabel = new System.Windows.Forms.Label();
            this.startAmountTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.endAmountTextBox = new System.Windows.Forms.TextBox();
            this.filterDataButton = new System.Windows.Forms.Button();
            this.cancelFilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.addRowBox.SuspendLayout();
            this.filterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(855, 12);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(122, 23);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(304, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(515, 362);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Location = new System.Drawing.Point(855, 96);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(122, 23);
            this.deleteRowButton.TabIndex = 4;
            this.deleteRowButton.Text = "Delete Row";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.DeleteRowButton_Click);
            // 
            // addRowBox
            // 
            this.addRowBox.Controls.Add(this.addRowButton);
            this.addRowBox.Controls.Add(this.f);
            this.addRowBox.Controls.Add(this.fuelAmountTextBox);
            this.addRowBox.Controls.Add(this.label2);
            this.addRowBox.Controls.Add(this.fuelTypeTextBox);
            this.addRowBox.Controls.Add(this.label1);
            this.addRowBox.Enabled = false;
            this.addRowBox.Location = new System.Drawing.Point(12, 2);
            this.addRowBox.Name = "addRowBox";
            this.addRowBox.Size = new System.Drawing.Size(286, 179);
            this.addRowBox.TabIndex = 7;
            this.addRowBox.TabStop = false;
            this.addRowBox.Text = "Add Fuel Row";
            // 
            // addRowButton
            // 
            this.addRowButton.Location = new System.Drawing.Point(6, 146);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(75, 23);
            this.addRowButton.TabIndex = 12;
            this.addRowButton.Text = "Add Row";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // f
            // 
            this.f.AutoSize = true;
            this.f.Location = new System.Drawing.Point(7, 76);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(66, 13);
            this.f.TabIndex = 11;
            this.f.Text = "Fuel Amount";
            // 
            // fuelAmountTextBox
            // 
            this.fuelAmountTextBox.Location = new System.Drawing.Point(6, 97);
            this.fuelAmountTextBox.Name = "fuelAmountTextBox";
            this.fuelAmountTextBox.Size = new System.Drawing.Size(274, 20);
            this.fuelAmountTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fuel Type";
            // 
            // fuelTypeTextBox
            // 
            this.fuelTypeTextBox.Location = new System.Drawing.Point(6, 41);
            this.fuelTypeTextBox.Name = "fuelTypeTextBox";
            this.fuelTypeTextBox.Size = new System.Drawing.Size(274, 20);
            this.fuelTypeTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-52, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // updateChangesButton
            // 
            this.updateChangesButton.Location = new System.Drawing.Point(855, 148);
            this.updateChangesButton.Name = "updateChangesButton";
            this.updateChangesButton.Size = new System.Drawing.Size(122, 23);
            this.updateChangesButton.TabIndex = 8;
            this.updateChangesButton.Text = "Update changes";
            this.updateChangesButton.UseVisualStyleBackColor = true;
            this.updateChangesButton.Click += new System.EventHandler(this.UpdateChangesButton_Click);
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.cancelFilterButton);
            this.filterBox.Controls.Add(this.filterDataButton);
            this.filterBox.Controls.Add(this.label4);
            this.filterBox.Controls.Add(this.endAmountTextBox);
            this.filterBox.Controls.Add(this.startAmountLabel);
            this.filterBox.Controls.Add(this.startAmountTextBox);
            this.filterBox.Location = new System.Drawing.Point(12, 188);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(286, 176);
            this.filterBox.TabIndex = 9;
            this.filterBox.TabStop = false;
            this.filterBox.Text = "Filter Box";
            // 
            // startAmountLabel
            // 
            this.startAmountLabel.AutoSize = true;
            this.startAmountLabel.Location = new System.Drawing.Point(7, 23);
            this.startAmountLabel.Name = "startAmountLabel";
            this.startAmountLabel.Size = new System.Drawing.Size(68, 13);
            this.startAmountLabel.TabIndex = 11;
            this.startAmountLabel.Text = "Start Amount";
            // 
            // startAmountTextBox
            // 
            this.startAmountTextBox.Location = new System.Drawing.Point(6, 44);
            this.startAmountTextBox.Name = "startAmountTextBox";
            this.startAmountTextBox.Size = new System.Drawing.Size(274, 20);
            this.startAmountTextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "End Amount";
            // 
            // endAmountTextBox
            // 
            this.endAmountTextBox.Location = new System.Drawing.Point(6, 97);
            this.endAmountTextBox.Name = "endAmountTextBox";
            this.endAmountTextBox.Size = new System.Drawing.Size(274, 20);
            this.endAmountTextBox.TabIndex = 12;
            // 
            // filterDataButton
            // 
            this.filterDataButton.Location = new System.Drawing.Point(6, 138);
            this.filterDataButton.Name = "filterDataButton";
            this.filterDataButton.Size = new System.Drawing.Size(75, 23);
            this.filterDataButton.TabIndex = 14;
            this.filterDataButton.Text = "Filter Data";
            this.filterDataButton.UseVisualStyleBackColor = true;
            this.filterDataButton.Click += new System.EventHandler(this.FilterDataButton_Click);
            // 
            // cancelFilterButton
            // 
            this.cancelFilterButton.Location = new System.Drawing.Point(205, 138);
            this.cancelFilterButton.Name = "cancelFilterButton";
            this.cancelFilterButton.Size = new System.Drawing.Size(75, 23);
            this.cancelFilterButton.TabIndex = 15;
            this.cancelFilterButton.Text = "Cancel";
            this.cancelFilterButton.UseVisualStyleBackColor = true;
            this.cancelFilterButton.Click += new System.EventHandler(this.CancelFilterButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 476);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.updateChangesButton);
            this.Controls.Add(this.addRowBox);
            this.Controls.Add(this.deleteRowButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ConnectButton);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.addRowBox.ResumeLayout(false);
            this.addRowBox.PerformLayout();
            this.filterBox.ResumeLayout(false);
            this.filterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteRowButton;
        private GroupBox addRowBox;
        private Label label2;
        private TextBox fuelTypeTextBox;
        private Label label1;
        private Label f;
        private TextBox fuelAmountTextBox;
        private Button addRowButton;
        private Button updateChangesButton;
        private GroupBox filterBox;
        private Button filterDataButton;
        private Label label4;
        private TextBox endAmountTextBox;
        private Label startAmountLabel;
        private TextBox startAmountTextBox;
        private Button cancelFilterButton;
    }
}

