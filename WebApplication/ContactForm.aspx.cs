using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using DAL;

namespace WebApplication
{
    public partial class ContactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Contact mycontact = new Contact();
            mycontact.FirstName = this.TextBox1.Text;
            mycontact.Lastname = this.TextBox2.Text;
            mycontact.Address = this.TextBox3.Text;
            mycontact.City = this.TextBox4.Text;
            mycontact.State = this.TextBox5.Text;
            mycontact.ZipCode = this.TextBox6.Text;

            ContactManager cm = new ContactManager();
            cm.Insert(mycontact);

            

        }
    }
}