using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdoEnhanceCalc.Forms
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public static string Show(string prompt, string title="Input Box", string defaultText="")
        {
            var inputBox = new InputBox();
            inputBox.PromptLabel.Text = prompt;
            inputBox.Text = title;
            inputBox.InputTextBox.Text = defaultText;

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                return inputBox.InputTextBox.Text;
            }
            return null;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
