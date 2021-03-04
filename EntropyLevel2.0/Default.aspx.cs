using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntropyLevel2._0
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtInput.Text.Length>0)
            {
                PasswordStrength passwordBroker = new PasswordStrength(40); //finger thumb rule
                passwordBroker.CheckEntropy(txtInput.Text);
                lblOutput.Text = passwordBroker.ViewOutput.ToString();
            }
        }
    }
}