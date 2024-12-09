using System;
using System.Windows.Forms;

namespace mysoftware
{
    public partial class Form1 : Form
    {
        private string currentSelection = "Civilian"; // Track current DomainUpDown selection

        // Civilian data storage
        private string civilianAttackValue;
        private string civilianHpValue;
        private string civilianSpeedValue;
        private string civilianCSpeedValue;

        // Fishing Boat data storage
        private string fishingBoatAttackValue;
        private string fishingBoatHpValue;
        private string fishingBoatSpeedValue;
        private string fishingBoatCSpeedValue;

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
                // Save current Civilian values
                civilianAttackValue = AttackValue.Text;
                civilianHpValue = HpValue.Text;
                civilianSpeedValue = Speed.Value.ToString();
                civilianCSpeedValue = CSpeed.Value.ToString();
            }
            else if (currentSelection == "Fishing Boat")
            {
                selectedFishingBoatRadioButton = GetSelectedRadioButton(fishingBoatRadioButtons);
                // Save current Fishing Boat values
                fishingBoatAttackValue = AttackValue.Text;
                fishingBoatHpValue = HpValue.Text;
                fishingBoatSpeedValue = Speed.Value.ToString();
                fishingBoatCSpeedValue = CSpeed.Value.ToString();
            }
        }

        private void RestoreSavedSelection()
        {
            // Restore the saved RadioButton selection for the current domain
            if (currentSelection == "Civilian")
            {
                if (selectedCivilianRadioButton != null)
                    selectedCivilianRadioButton.Checked = true;
                // Restore Civilian values
                AttackValue.Text = civilianAttackValue;
                HpValue.Text = civilianHpValue;
                Speed.Value = int.TryParse(civilianSpeedValue, out var spd) ? spd : 0;
                CSpeed.Value = int.TryParse(civilianCSpeedValue, out var cspd) ? cspd : 0;
            }
            else if (currentSelection == "Fishing Boat")
            {
                if (selectedFishingBoatRadioButton != null)
                    selectedFishingBoatRadioButton.Checked = true;
                // Restore Fishing Boat values
                AttackValue.Text = fishingBoatAttackValue;
                HpValue.Text = fishingBoatHpValue;
                Speed.Value = int.TryParse(fishingBoatSpeedValue, out var spd) ? spd : 0;
                CSpeed.Value = int.TryParse(fishingBoatCSpeedValue, out var cspd) ? cspd : 0;
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

        // Event Handlers for AttackValue, HpValue, Speed, CSpeed changes
        private void AttackValue_TextChanged_1(object sender, EventArgs e)
        {
            if (currentSelection == "Civilian")
            {
                civilianAttackValue = AttackValue.Text;
            }
            else if (currentSelection == "Fishing Boat")
            {
                fishingBoatAttackValue = AttackValue.Text;
            }
        }

        private void HpValue_TextChanged_1(object sender, EventArgs e)
        {
            if (currentSelection == "Civilian")
            {
                civilianHpValue = HpValue.Text;
            }
            else if (currentSelection == "Fishing Boat")
            {
                fishingBoatHpValue = HpValue.Text;
            }
        }

        private void Speed_ValueChanged(object sender, EventArgs e)
        {
            if (currentSelection == "Civilian")
            {
                civilianSpeedValue = Speed.Value.ToString();
            }
            else if (currentSelection == "Fishing Boat")
            {
                fishingBoatSpeedValue = Speed.Value.ToString();
            }
        }

        private void CSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (currentSelection == "Civilian")
            {
                civilianCSpeedValue = CSpeed.Value.ToString();
            }
            else if (currentSelection == "Fishing Boat")
            {
                fishingBoatCSpeedValue = CSpeed.Value.ToString();
            }
        }

        // Other existing event handlers can remain unchanged.
    





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