using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button5.Click += new System.EventHandler(this.button5_Click);
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-IES908U;Initial Catalog=CRUDFormGrid;Integrated Security=True");

        // Method to clear the form fields
        private void ClearForm()
        {
            // Clear all textboxes
            textBox1.Clear();

            // Reset combobox
            comboBox1.SelectedIndex = -1;

            // Reset radio buttons (deselect all)
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Determine gender
                string gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;


                // Determine status
                string status = radioButton4.Checked ? radioButton4.Text : radioButton3.Text;

                // Insert new record
                SqlCommand cmd = new SqlCommand("insert into barno (name, department, gender, stutus) values (@name, @department, @gender, @stutus)", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@department", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@stutus", status);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");

                // Fetch all records from the table
                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM barno", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the fetched data to the DataGridView
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after insertion
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete barno where name= @name", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted");

                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM barno", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after deletion
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string gender = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
                string stutus = radioButton4.Checked ? radioButton4.Text : radioButton3.Text;

                SqlCommand cmd = new SqlCommand("update barno set department=@department,gender=@gender,stutus=@stutus where name= @name", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@department", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@stutus", stutus);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");

                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM barno", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after update
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from barno where name= @name", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Clear form after search
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand fetchCmd = new SqlCommand("SELECT * FROM barno", con);
                SqlDataAdapter adapter = new SqlDataAdapter(fetchCmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
