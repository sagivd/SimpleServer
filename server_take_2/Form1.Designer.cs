namespace server_take_2
{
    partial class Form1
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
            this.textBoxRX = new System.Windows.Forms.TextBox();
            this.textBoxTX = new System.Windows.Forms.TextBox();
            this.listViewConn = new System.Windows.Forms.ListView();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.radioButtonUDP = new System.Windows.Forms.RadioButton();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.radioButtonSSL = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxEcho = new System.Windows.Forms.CheckBox();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRX
            // 
            this.textBoxRX.Location = new System.Drawing.Point(51, 114);
            this.textBoxRX.Multiline = true;
            this.textBoxRX.Name = "textBoxRX";
            this.textBoxRX.Size = new System.Drawing.Size(249, 89);
            this.textBoxRX.TabIndex = 0;
            this.textBoxRX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRX_KeyPress);
            // 
            // textBoxTX
            // 
            this.textBoxTX.Location = new System.Drawing.Point(51, 232);
            this.textBoxTX.Multiline = true;
            this.textBoxTX.Name = "textBoxTX";
            this.textBoxTX.Size = new System.Drawing.Size(249, 89);
            this.textBoxTX.TabIndex = 1;
            // 
            // listViewConn
            // 
            this.listViewConn.CheckBoxes = true;
            this.listViewConn.Location = new System.Drawing.Point(51, 380);
            this.listViewConn.Name = "listViewConn";
            this.listViewConn.Size = new System.Drawing.Size(249, 99);
            this.listViewConn.TabIndex = 2;
            this.listViewConn.UseCompatibleStateImageBehavior = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(319, 114);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(319, 232);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClearList
            // 
            this.buttonClearList.Location = new System.Drawing.Point(319, 380);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 5;
            this.buttonClearList.Text = "Clear";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
            // 
            // radioButtonUDP
            // 
            this.radioButtonUDP.AutoSize = true;
            this.radioButtonUDP.Checked = true;
            this.radioButtonUDP.Location = new System.Drawing.Point(51, 34);
            this.radioButtonUDP.Name = "radioButtonUDP";
            this.radioButtonUDP.Size = new System.Drawing.Size(48, 17);
            this.radioButtonUDP.TabIndex = 6;
            this.radioButtonUDP.TabStop = true;
            this.radioButtonUDP.Text = "UDP";
            this.radioButtonUDP.UseVisualStyleBackColor = true;
            this.radioButtonUDP.CheckedChanged += new System.EventHandler(this.radioButtonUDP_CheckedChanged);
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.Location = new System.Drawing.Point(51, 57);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(46, 17);
            this.radioButtonTCP.TabIndex = 7;
            this.radioButtonTCP.Text = "TCP";
            this.radioButtonTCP.UseVisualStyleBackColor = true;
            this.radioButtonTCP.CheckedChanged += new System.EventHandler(this.radioButtonTCP_CheckedChanged);
            // 
            // radioButtonSSL
            // 
            this.radioButtonSSL.AutoSize = true;
            this.radioButtonSSL.Location = new System.Drawing.Point(51, 80);
            this.radioButtonSSL.Name = "radioButtonSSL";
            this.radioButtonSSL.Size = new System.Drawing.Size(45, 17);
            this.radioButtonSSL.TabIndex = 8;
            this.radioButtonSSL.Text = "SSL";
            this.radioButtonSSL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP Address: 192.168.1.1";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(177, 42);
            this.textBoxPort.MaxLength = 6;
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxPort.TabIndex = 10;
            this.textBoxPort.Text = "9001";
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxPort_TextChanged);
            this.textBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(319, 40);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(75, 23);
            this.buttonListen.TabIndex = 11;
            this.buttonListen.Text = "Start Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(319, 69);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxEcho
            // 
            this.checkBoxEcho.AutoSize = true;
            this.checkBoxEcho.Location = new System.Drawing.Point(177, 74);
            this.checkBoxEcho.Name = "checkBoxEcho";
            this.checkBoxEcho.Size = new System.Drawing.Size(87, 17);
            this.checkBoxEcho.TabIndex = 13;
            this.checkBoxEcho.Text = "Echo Enable";
            this.checkBoxEcho.UseVisualStyleBackColor = true;
            this.checkBoxEcho.CheckedChanged += new System.EventHandler(this.checkBoxEcho_CheckedChanged);
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Location = new System.Drawing.Point(319, 410);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(75, 23);
            this.buttonAddClient.TabIndex = 14;
            this.buttonAddClient.Text = "Add Client";
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 509);
            this.Controls.Add(this.buttonAddClient);
            this.Controls.Add(this.checkBoxEcho);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonSSL);
            this.Controls.Add(this.radioButtonTCP);
            this.Controls.Add(this.radioButtonUDP);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listViewConn);
            this.Controls.Add(this.textBoxTX);
            this.Controls.Add(this.textBoxRX);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRX;
        private System.Windows.Forms.TextBox textBoxTX;
        private System.Windows.Forms.ListView listViewConn;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.RadioButton radioButtonUDP;
        private System.Windows.Forms.RadioButton radioButtonTCP;
        private System.Windows.Forms.RadioButton radioButtonSSL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxEcho;
        private System.Windows.Forms.Button buttonAddClient;
    }
}

