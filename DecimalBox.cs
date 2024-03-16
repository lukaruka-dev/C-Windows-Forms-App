using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class DecimalBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back
                & e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private string currentText;

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text.Length > 0)
            {
                float result;
                bool isNumeric = float.TryParse(this.Text, out result);

                if (isNumeric)
                {
                    currentText = this.Text;
                }
                else
                {
                    this.Text = currentText;
                    this.Select(this.Text.Length, 0);
                }
            }
            base.OnTextChanged(e);
        }
    }
}
