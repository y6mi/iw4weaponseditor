using System;
using System.IO;
using System.Windows.Forms;

namespace IW4WeaponsEditor
{
    public partial class Form1 : Form
    {
        private string filePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // code if needed
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    DisplayModels();
                }
            }
        }

        private void DisplayModels()
        {
            if (string.IsNullOrEmpty(filePath)) return;

            try
            {
                var content = File.ReadAllText(filePath);
                txtFileContent.Text = filePath;

                for (int i = 1; i <= 9; i++)
                {
                    ExtractAndDisplayModel(content, "gunmodel", i, GetGunModelTextBox(i));
                    ExtractAndDisplayModel(content, "worldmodel", i, GetWorldModelTextBox(i));
                }

                ExtractAndDisplayAnimation(content, "idleanim", animidle);
                ExtractAndDisplayAnimation(content, "emptyidleanim", animidleempty);
                ExtractAndDisplayAnimation(content, "fireanim", animfire);
                ExtractAndDisplayAnimation(content, "lastShotAnim", animfirelast);
                ExtractAndDisplayAnimation(content, "meleeAnim", animmelee);
                ExtractAndDisplayAnimation(content, "meleeChargeAnim", animmeleecharge);
                ExtractAndDisplayAnimation(content, "reloadAnim", animreload);
                ExtractAndDisplayAnimation(content, "reloadEmptyAnim", animemptyreload);
                ExtractAndDisplayAnimation(content, "raiseAnim", animraise);
                ExtractAndDisplayAnimation(content, "dropAnim", animdrop);
                ExtractAndDisplayAnimation(content, "firstRaiseAnim", animfirstraise);
                ExtractAndDisplayAnimation(content, "quickRaiseAnim", animquickraise);
                ExtractAndDisplayAnimation(content, "quickDropAnim", animquickdrop);
                ExtractAndDisplayAnimation(content, "emptyRaiseAnim", animemptyraise);
                ExtractAndDisplayAnimation(content, "sprintInAnim", animsprintin);
                ExtractAndDisplayAnimation(content, "emptydropanim", animemptydrop); 
                ExtractAndDisplayAnimation(content, "sprintLoopAnim", animsprintloop);
                ExtractAndDisplayAnimation(content, "sprintOutAnim", animsprintout);
                ExtractAndDisplayAnimation(content, "adsFireAnim", animadsfire);
                ExtractAndDisplayAnimation(content, "adsLastShotAnim", animadslastshot);
                ExtractAndDisplayAnimation(content, "adsUpAnim", animadsup);
                ExtractAndDisplayAnimation(content, "adsDownAnim", animadsdown);

                ExtractAndDisplayAnimation(content, "firetime", firetime);
                ExtractAndDisplayAnimation(content, "rechambertime", rechambertime);
                ExtractAndDisplayAnimation(content, "rechamberBoltTime", bolttime);
                ExtractAndDisplayAnimation(content, "holdFireTime", holdfiretime);
                ExtractAndDisplayAnimation(content, "meleeTime", meleetime);
                ExtractAndDisplayAnimation(content, "meleeChargeTime", meleechargetime);
                ExtractAndDisplayAnimation(content, "reloadTime", reloadtime);
                ExtractAndDisplayAnimation(content, "reloadShowRocketTime", reloadrockettime);
                ExtractAndDisplayAnimation(content, "reloadEmptyTime", reloademptytime);
                ExtractAndDisplayAnimation(content, "reloadAddTime", reloadstart);
                ExtractAndDisplayAnimation(content, "reloadStartTime", reloadstart);
                ExtractAndDisplayAnimation(content, "reloadStartAddTime", reloadstartadd);
                ExtractAndDisplayAnimation(content, "reloadEndTime", reloadendtime);
                ExtractAndDisplayAnimation(content, "dropTime", droptime);
                ExtractAndDisplayAnimation(content, "raiseTime", raisetime);
                ExtractAndDisplayAnimation(content, "altDropTime", altdroptime);
                ExtractAndDisplayAnimation(content, "altRaiseTime", altraisetime);
                ExtractAndDisplayAnimation(content, "quickDropTime", quickdroptime);
                ExtractAndDisplayAnimation(content, "quickRaiseTime", quickraisetime);
                ExtractAndDisplayAnimation(content, "firstRaiseTime", firstraisetime);
                ExtractAndDisplayAnimation(content, "raiseTime", emptyraisetime);
                ExtractAndDisplayAnimation(content, "sprintInTime", sprintintime);
                ExtractAndDisplayAnimation(content, "sprintOutTime", sprintouttime);
                ExtractAndDisplayAnimation(content, "sprintLoopTime", sprintlooptime);
                ExtractAndDisplayAnimation(content, "emptydroptime", emptydroptime);

            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtractAndDisplayModel(string content, string modelPrefix, int modelNumber, TextBox textBox)
        {
            string keyword = modelNumber == 1 ? $"{modelPrefix}\\" : $"{modelPrefix}{modelNumber}\\";

            var startIndex = content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

            if (startIndex != -1)
            {
                startIndex += keyword.Length;
                var endIndex = content.IndexOf("\\", startIndex);
                if (endIndex != -1)
                {
                    var modelText = content.Substring(startIndex, endIndex - startIndex).Trim();
                    if (textBox != null)
                    {
                        textBox.Text = modelText;
                    }
                }
            }
        }

        private void ExtractAndDisplayAnimation(string content, string animationPrefix, TextBox textBox)
        {
            string keyword = $"{animationPrefix}\\";

            var startIndex = content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

            if (startIndex != -1)
            {
                startIndex += keyword.Length;
                var endIndex = content.IndexOf("\\", startIndex);
                if (endIndex != -1)
                {
                    var animationText = content.Substring(startIndex, endIndex - startIndex).Trim();
                    if (textBox != null)
                    {
                        textBox.Text = animationText;
                    }
                }
            }
        }

        private TextBox GetGunModelTextBox(int modelNumber)
        {
            switch (modelNumber)
            {
                case 1: return gunmodel;
                case 2: return GunModel2;
                case 3: return GunModel3;
                case 4: return GunModel4;
                case 5: return GunModel5;
                case 6: return GunModel6;
                case 7: return GunModel7;
                case 8: return GunModel8;
                case 9: return GunModel9;
                default: return null;
            }
        }

        private TextBox GetWorldModelTextBox(int modelNumber)
        {
            switch (modelNumber)
            {
                case 1: return WorldModel;
                case 2: return WorldModel2;
                case 3: return WorldModel3;
                case 4: return WorldModel4;
                case 5: return WorldModel5;
                case 6: return WorldModel6;
                case 7: return WorldModel7;
                case 8: return WorldModel8;
                case 9: return WorldModel9;
                default: return null;
            }
        }

        private string UpdateModelContent(string content, string modelPrefix, Func<int, TextBox> getTextBox)
        {
            for (int i = 1; i <= 9; i++)
            {
                string keyword = i == 1 ? $"{modelPrefix}\\" : $"{modelPrefix}{i}\\";

                var startIndex = content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

                if (startIndex != -1)
                {
                    startIndex += keyword.Length;
                    var endIndex = content.IndexOf("\\", startIndex);
                    if (endIndex != -1)
                    {
                        var oldContent = content.Substring(startIndex, endIndex - startIndex);
                        var newContent = getTextBox(i).Text;
                        content = content.Substring(0, startIndex) + newContent + content.Substring(endIndex);
                    }
                }
            }
            return content;
        }

        private string UpdateAnimationContent(string content, string animationPrefix, TextBox textBox)
        {
            string keyword = $"{animationPrefix}\\";

            var startIndex = content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

            if (startIndex != -1)
            {
                startIndex += keyword.Length;
                var endIndex = content.IndexOf("\\", startIndex);
                if (endIndex != -1)
                {
                    var oldContent = content.Substring(startIndex, endIndex - startIndex);
                    var newContent = textBox.Text;
                    content = content.Substring(0, startIndex) + newContent + content.Substring(endIndex);
                }
            }
            return content;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath)) return;

            try
            {
                var content = File.ReadAllText(filePath);
                content = UpdateModelContent(content, "gunmodel", GetGunModelTextBox);
                content = UpdateModelContent(content, "worldmodel", GetWorldModelTextBox);
                content = UpdateAnimationContent(content, "idleanim", animidle);
                content = UpdateAnimationContent(content, "emptyidleanim", animidleempty);
                content = UpdateAnimationContent(content, "fireanim", animfire);
                content = UpdateAnimationContent(content, "lastShotAnim", animfirelast);
                content = UpdateAnimationContent(content, "meleeAnim", animmelee);
                content = UpdateAnimationContent(content, "meleeChargeAnim", animmeleecharge);
                content = UpdateAnimationContent(content, "reloadAnim", animreload);
                content = UpdateAnimationContent(content, "reloadEmptyAnim", animemptyreload);
                content = UpdateAnimationContent(content, "raiseAnim", animraise);
                content = UpdateAnimationContent(content, "dropAnim", animdrop);
                content = UpdateAnimationContent(content, "firstRaiseAnim", animfirstraise);
                content = UpdateAnimationContent(content, "quickRaiseAnim", animquickraise);
                content = UpdateAnimationContent(content, "quickDropAnim", animquickdrop);
                content = UpdateAnimationContent(content, "emptyRaiseAnim", animemptyraise);
                content = UpdateAnimationContent(content, "emptyDropAnim", animemptydrop);
                content = UpdateAnimationContent(content, "sprintInAnim", animsprintin);
                content = UpdateAnimationContent(content, "sprintLoopAnim", animsprintloop);
                content = UpdateAnimationContent(content, "sprintOutAnim", animsprintout);
                content = UpdateAnimationContent(content, "adsFireAnim", animadsfire);
                content = UpdateAnimationContent(content, "adsLastShotAnim", animadslastshot);
                content = UpdateAnimationContent(content, "adsUpAnim", animadsup);
                content = UpdateAnimationContent(content, "firetime", firetime);
                content = UpdateAnimationContent(content, "rechambertime", rechambertime);
                content = UpdateAnimationContent(content, "rechamberBoltTime", bolttime);
                content = UpdateAnimationContent(content, "holdFireTime", holdfiretime);
                content = UpdateAnimationContent(content, "meleeTime", meleetime);
                content = UpdateAnimationContent(content, "meleeChargeTime", meleechargetime);
                content = UpdateAnimationContent(content, "reloadTime", reloadtime);
                content = UpdateAnimationContent(content, "reloadShowRocketTime", reloadrockettime);
                content = UpdateAnimationContent(content, "reloadEmptyTime", reloademptytime);
                content = UpdateAnimationContent(content, "reloadAddTime", reloadstart);
                content = UpdateAnimationContent(content, "reloadStartTime", reloadstart);
                content = UpdateAnimationContent(content, "reloadStartAddTime", reloadstartadd);
                content = UpdateAnimationContent(content, "reloadEndTime", reloadendtime);
                content = UpdateAnimationContent(content, "dropTime", droptime);
                content = UpdateAnimationContent(content, "raiseTime", raisetime);
                content = UpdateAnimationContent(content, "altDropTime", altdroptime);
                content = UpdateAnimationContent(content, "altRaiseTime", altraisetime);
                content = UpdateAnimationContent(content, "quickDropTime", quickdroptime);
                content = UpdateAnimationContent(content, "quickRaiseTime", quickraisetime);
                content = UpdateAnimationContent(content, "firstRaiseTime", firstraisetime);
                content = UpdateAnimationContent(content, "raiseTime", emptyraisetime); 
                content = UpdateAnimationContent(content, "sprintInTime", sprintintime);
                content = UpdateAnimationContent(content, "sprintOutTime", sprintouttime);
                content = UpdateAnimationContent(content, "sprintLoopTime", sprintlooptime);
                content = UpdateAnimationContent(content, "emptydroptime", emptydroptime);
                
                File.WriteAllText(filePath, content); 
                MessageBox.Show("File saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers for GunModel textboxes
        private void GunModel2_TextChanged(object sender, EventArgs e) { }
        private void GunModel3_TextChanged(object sender, EventArgs e) { }
        private void GunModel4_TextChanged(object sender, EventArgs e) { }
        private void GunModel5_TextChanged(object sender, EventArgs e) { }
        private void GunModel6_TextChanged(object sender, EventArgs e) { }
        private void GunModel7_TextChanged(object sender, EventArgs e) { }
        private void GunModel8_TextChanged(object sender, EventArgs e) { }
        private void GunModel9_TextChanged(object sender, EventArgs e) { }

        // Event handlers for WorldModel textboxes
        private void WorldModel2_TextChanged(object sender, EventArgs e) { }
        private void WorldModel3_TextChanged(object sender, EventArgs e) { }
        private void WorldModel4_TextChanged(object sender, EventArgs e) { }
        private void WorldModel5_TextChanged(object sender, EventArgs e) { }
        private void WorldModel6_TextChanged(object sender, EventArgs e) { }
        private void WorldModel7_TextChanged(object sender, EventArgs e) { }
        private void WorldModel8_TextChanged(object sender, EventArgs e) { }
        private void WorldModel9_TextChanged(object sender, EventArgs e) { }

        private void StateTiming_Click(object sender, EventArgs e)
        {

        }

        private void firetime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
