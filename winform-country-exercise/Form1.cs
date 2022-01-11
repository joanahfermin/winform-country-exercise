using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace winform_country_exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCountry();
        }

        /// <summary>
        /// Populate the list view with all the contents of the Country table
        /// </summary>
        private void InitializeCountry()
        {
            //Remove all contents of the list view as we will repopulate
            lvCountry.Items.Clear();

            //Connect to the database.  Let's use "using" so we are guaranteed connection is closed later.
            using (SqlConnection cnn = DButil.getConnection())
            {
                //Prepare the query to retrieve all contents of the table
                SqlCommand cmd = new SqlCommand("Select CountryId, CountryName from My_Country", cnn);
                //Execute the query and get the data reader object.
                SqlDataReader dr = cmd.ExecuteReader();

                //Loop through all the contents of the data reader
                while (dr.Read())
                {
                    //Get the value of the columns in the current row
                    string countryId = dr["CountryId"].ToString();
                    string countryName = dr["CountryName"].ToString();
                    
                    //Prepare list view item object withe the column values and add to the list view
                    ListViewItem item = new ListViewItem(countryId);
                    item.SubItems.Add(countryName);
                    lvCountry.Items.Add(item);
                }
            }
        }
        
        /// <summary>
        /// Add new row to the country table from the contents of the textbox.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Store the country name from the textbox to a local variable
            string countryName = tbCountryName.Text;

            //Connect to the database
            using (SqlConnection cnn = DButil.getConnection())
            {
                //Prepare the Insert SQL statement
                SqlCommand cmd = new SqlCommand("insert into My_Country(CountryName) values(@param1)", cnn);
                //Supply the value of the country name using parameter.  This is more secure than using concatenation in our SQL statement.
                cmd.Parameters.AddWithValue("@param1", countryName);
                cmd.ExecuteNonQuery();

                //Clear the text box
                tbCountryName.Clear();
            }

            //After inserting new value, we call to refresh our list view with latest contents of the table.
            InitializeCountry();
        }
    }
}
