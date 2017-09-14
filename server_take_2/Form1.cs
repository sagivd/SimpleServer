using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace server_take_2
{
    public enum Protocol_t
    {
        PROTO_TCP,
        PROTO_UDP,
        PROTO_SSL,
    };

    public partial class Form1 : Form
    {
        delegate void update_RX_text_delegate(string str);
        delegate void add_client_to_list_delegate(ListViewItem itm);

        private static Form1 form = null;
        public Protocol_t selectedProto;
        ConnectionManager CM;

        public Form1()
        {
            InitializeComponent();
            selectedProto = Protocol_t.PROTO_UDP;
            CM = new ConnectionManager(this);

            listViewConn.View = View.Details;
            listViewConn.Columns.Add("IP Address", 150);
            listViewConn.Columns.Add("Port", 100);

            form = this;
        }

        private void radioButtonTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTCP.Checked)
                selectedProto = Protocol_t.PROTO_TCP;
        }

        private void radioButtonUDP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUDP.Checked)
                selectedProto = Protocol_t.PROTO_UDP;
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxPort.Text, "  ^ [0-9]"))
            {
                textBoxPort.Text = "";
            }
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxRX.Text = "";
        }

        private void textBoxRX_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!CM.is_listening)
            {
                return;
            }

            CM.sendTextToClients(textBoxTX.Text);
    
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            CM.startListening();
            buttonListen.Enabled = false;
            buttonStop.Enabled = true;
            radioButtonTCP.Enabled = false;
            radioButtonUDP.Enabled = false;
            radioButtonSSL.Enabled = false;
            textBoxPort.Enabled = false;
        }

        public bool got_port(out UInt16 port)
        {
            if (UInt16.TryParse(textBoxPort.Text, out port))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void stat_updateRXTextBox(string str)
        {
            if (form != null)
                form.textBoxRX.Text += str;
        }

        public void updateRXTextBox(string str)
        {
            if (InvokeRequired)
            {
                this.Invoke(new update_RX_text_delegate(stat_updateRXTextBox), new object[] { str });
                return;
            }

            textBoxRX.Text += str;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CM.stopListening();
            buttonStop.Enabled = false;
            buttonListen.Enabled = true;
        }

        static private void stat_addNewClient(ListViewItem itm)
        {
            if (form == null)
                return;

            itm.Checked = true;
            form.listViewConn.Items.Add(itm);
        }

        public void addNewClient(ListViewItem itm)
        {
            if (InvokeRequired)
            {
                this.Invoke(new add_client_to_list_delegate(stat_addNewClient), new object[] { itm });
                return;
            }

            itm.Checked = true;
            listViewConn.Items.Add(itm);
        }

        public bool clientIsInList(ListViewItem itm)
        {
            return listViewConn.Items.Contains(itm);
        }

        public ListView.CheckedListViewItemCollection getActiveClients()
        {
            return listViewConn.CheckedItems;
        }

        private void buttonClearList_Click(object sender, EventArgs e)
        {
            listViewConn.Items.Clear();
        }
        
    }

    public class UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
        public Form1 p;
        public AutoResetEvent a;
        public ConnectionManager c;
    }

    public class ConnectionManager
    {
        Form1 parent;
        public bool is_listening;
        bool stop;
        UdpClient listener;
        Thread listenThread;
        IPEndPoint listenEndPoint;
        static AutoResetEvent autoEvent = new AutoResetEvent(false);
        List<IPEndPoint> clientList;
        UdpState stateHandler;

        public ConnectionManager(Form1 parent)
        {
            this.parent = parent;

            is_listening = false;
            stop = false;

            clientList = new List<IPEndPoint>();
        }
        
        public void startListening()
        {
            if (is_listening)
            {
                // should not be here
                MessageBox.Show("already listening");
                return;
            }

            listenThread = new Thread(new ThreadStart(listenThreadMethodUDP));
            listenThread.IsBackground = true;
            listenThread.Start();
            is_listening = true;
        }

        private void listenThreadMethodUDP()
        {
            UInt16 listenPort;

            if (parent.selectedProto == Protocol_t.PROTO_UDP)
            {
                if (!parent.got_port(out listenPort))
                {
                    MessageBox.Show("invalid port");
                    return;
                }
            }
            else
            {
                //not supported
                MessageBox.Show("not supported");
                return;
            }

            listener = new UdpClient(listenPort);
            listenEndPoint = new IPEndPoint(IPAddress.Any, listenPort);

            stateHandler = new UdpState();
            stateHandler.p = parent;
            stateHandler.u = listener;
            stateHandler.e = listenEndPoint;
            stateHandler.a = autoEvent;
            stateHandler.c = this;

            
            do
            {
                listener.BeginReceive(new AsyncCallback(ReceiveCallback), stateHandler);
                autoEvent.WaitOne(Timeout.Infinite);
            } while(!stop);

            listener.Close();
            is_listening = false;
        }

        public bool clientNotInList(ref ListViewItem itm)
        {
            return !parent.clientIsInList(itm);
        }

        public void addClientToList(ref ListViewItem itm)
        {
            parent.addNewClient(itm);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            ConnectionManager CM = (ConnectionManager)((UdpState)ar.AsyncState).c;
            UdpClient localListener = (UdpClient)((UdpState)ar.AsyncState).u;
            IPEndPoint localListenEndPoint = (IPEndPoint)((UdpState)ar.AsyncState).e;
            Form1 parent = (Form1)((UdpState)ar.AsyncState).p;
            AutoResetEvent autoEvent = (AutoResetEvent)((UdpState)ar.AsyncState).a;

            try
            {
                Byte[] receiveBytes = localListener.EndReceive(ar, ref localListenEndPoint);

                string[] arr = new string[2];
                arr[0] = localListenEndPoint.Address.ToString();
                arr[1] = localListenEndPoint.Port.ToString();

                ListViewItem itm = new ListViewItem(arr);

                if (CM.clientNotInList(ref itm))
                {
                    CM.addClientToList(ref itm);
                }

                string receiveString = Encoding.ASCII.GetString(receiveBytes);
                parent.updateRXTextBox(receiveString);
                autoEvent.Set();
            }
            catch (ObjectDisposedException e)
            {
                // The socket was already closed here.
                return;
            }
        }

        public void stopListening()
        {
            stop = true;
            autoEvent.Set();
        }

        public void sendTextToClients(String text)
        {
            // What if were not using UDP??
            UdpClient listener = stateHandler.u;
            byte[] send_buffer = Encoding.ASCII.GetBytes(text);
            
            ListView.CheckedListViewItemCollection activeClients = parent.getActiveClients();

            IPEndPoint clientEP;

            foreach (ListViewItem client in activeClients)
            {
                client.SubItems.
                clientEP = new IPEndPoint((IPAddress)client.GetSubItemAt(0,0), (int)client.GetSubItemAt(1,0));
            }

            listener.
        }
    }
}
