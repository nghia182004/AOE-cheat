using System.Windows.Forms;

namespace mysoftware
{
    public partial class Form1 : Form
    {
        private string currentSelection = "Civilian"; // Track current DomainUpDown selection
        private RadioButton[] civilianRadioButtons; // Array for "Civilian" RadioButtons
        private RadioButton[] fishingBoatRadioButtons; // Array for "Fishing Boat" RadioButtons
        private RadioButton selectedCivilianRadioButton; // To store the selected Civilian RadioButton
        private RadioButton selectedFishingBoatRadioButton; // To store the selected Fishing Boat RadioButton

        public Form1()
        {
            InitializeComponent();
            InitializeDomainUpDown(); // Initialize DomainUpDown items
            InitializeRadioButtonGroups(); // Group RadioButtons
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateRadioButtonsVisibility("Civilian"); // Set initial visibility
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            string selectedItem = Collectors.Text;

            // Only update visibility if selection changes
            if (selectedItem != currentSelection)
            {
                SaveCurrentSelection(); // Save the current selection
                currentSelection = selectedItem;
                UpdateRadioButtonsVisibility(selectedItem);
                RestoreSavedSelection(); // Restore the saved selection for the new domain
            }
        }

        private void InitializeDomainUpDown()
        {
            // Add items to DomainUpDown
            Collectors.Items.Add("Civilian");
            Collectors.Items.Add("Fishing Boat");
            Collectors.SelectedIndex = 0; // Default selection
        }

        private void InitializeRadioButtonGroups()
        {
            // Group "Civilian" RadioButtons
            civilianRadioButtons = new RadioButton[] { radioButton1, radioButton2, radioButton3, radioButton4 };

            // Group "Fishing Boat" RadioButtons
            fishingBoatRadioButtons = new RadioButton[] { radioButton5 /* Add more if needed */ };
        }

        private void UpdateRadioButtonsVisibility(string selection)
        {
            // Handle "Civilian"
            if (selection == "Civilian")
            {
                SetRadioButtonsVisibility(civilianRadioButtons, true);
                SetRadioButtonsVisibility(fishingBoatRadioButtons, false);
            }
            // Handle "Fishing Boat"
            else if (selection == "Fishing Boat")
            {
                SetRadioButtonsVisibility(civilianRadioButtons, false);
                SetRadioButtonsVisibility(fishingBoatRadioButtons, true);
            }
        }

        private void SetRadioButtonsVisibility(RadioButton[] radioButtons, bool isVisible)
        {
            foreach (var rb in radioButtons)
            {
                rb.Visible = isVisible;
            }
        }

        private void SaveCurrentSelection()
        {
            // Save the selected RadioButton for the current domain
            if (currentSelection == "Civilian")
            {
                selectedCivilianRadioButton = GetSelectedRadioButton(civilianRadioButtons);
            }
            else if (currentSelection == "Fishing Boat")
            {
                selectedFishingBoatRadioButton = GetSelectedRadioButton(fishingBoatRadioButtons);
            }
        }

        private void RestoreSavedSelection()
        {
            // Restore the saved RadioButton selection for the current domain
            if (currentSelection == "Civilian" && selectedCivilianRadioButton != null)
            {
                selectedCivilianRadioButton.Checked = true;
            }
            else if (currentSelection == "Fishing Boat" && selectedFishingBoatRadioButton != null)
            {
                selectedFishingBoatRadioButton.Checked = true;
            }
        }

        private RadioButton GetSelectedRadioButton(RadioButton[] radioButtons)
        {
            foreach (var rb in radioButtons)
            {
                if (rb.Checked)
                {
                    return rb;
                }
            }
            return null;
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Logic for radioButton1 (if needed)
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Logic for radioButton2 (if needed)
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Logic for radioButton3 (if needed)
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // Logic for radioButton4 (if needed)
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            // Logic for radioButton5 (if needed)
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HpValue_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void AttackValue_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Speed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CSpeed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}