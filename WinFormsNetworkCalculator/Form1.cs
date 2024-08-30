namespace WinFormsNetworkCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // comboBox initialisieren:
            // dropDownStyle dropDownList
            comboBoxCidr.SelectedIndex = 6;
        }

        private void buttonCalculateNetwork_Click(object sender, EventArgs e)
        {
            string address = textBoxAddress.Text;
            string cidr = comboBoxCidr.Text;

            // 1. address output
            long ipv4 = IP4Helper.GetDez(address);
            string dezOctet = IP4Helper.GetDezOctet(ipv4);
            string binOctet = IP4Helper.GetBinOctet(ipv4);

            WriteString("Address:", dezOctet, binOctet);
        }

        // write line to the listBox
        private void WriteString(string description, string dezOctet="", string binOctet="")
        {
            string row = $"{description,20}    {dezOctet,-20} {binOctet}";
            listBoxResults.Items.Add(row);
        }
    }
}
