using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditForm : Form
    {
        private int currentIndex = 0;
        private DataTable data = new DataTable();

        private int currentID = -1;

        public Table[] tables = new Table[]
        {
            new Table()
            {
                Label = "Items",
                Name = "items",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Name",
                        Name = "name",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Manufacturer",
                        Name = "manufacturer",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Description",
                        Name = "description",
                        Type = InputType.TEXT
                    },
                    new Input()
                    {
                        Label = "Price",
                        Name = "price",
                        Type = InputType.DECIMAL
                    }
                }
            },
            new Table()
            {
                Label = "Stock",
                Name = "stock",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Amount",
                        Name = "amount",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Item ID",
                        Name = "items_id",
                        Type = InputType.INT
                    }
                }
            },
            new Table()
            {
                Label = "Users",
                Name = "users",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Username",
                        Name = "username",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Email",
                        Name = "email",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Password",
                        Name = "password",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Type",
                        Name = "type",
                        Type = InputType.INT
                    }
                }
            },
            new Table()
            {
                Label = "Reviews",
                Name = "reviews",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Rating",
                        Name = "rating",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Title",
                        Name = "title",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Description",
                        Name = "description",
                        Type = InputType.TEXT
                    },
                    new Input()
                    {
                        Label = "User ID",
                        Name = "user_id",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Item ID",
                        Name = "item_id",
                        Type = InputType.INT
                    }
                }
            },
            new Table()
            {
                Label = "Item Specifications",
                Name = "item_specifications",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Name",
                        Name = "name",
                        Type = InputType.VARCHAR
                    },
                    new Input()
                    {
                        Label = "Value",
                        Name = "value",
                        Type = InputType.TEXT
                    },
                    new Input()
                    {
                        Label = "Item ID",
                        Name = "item_id",
                        Type = InputType.INT
                    }
                }
            },
            new Table()
            {
                Label = "Invoice Lines",
                Name = "invoice_lines",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Amount",
                        Name = "amount",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Price",
                        Name = "price",
                        Type = InputType.DECIMAL
                    },
                    new Input()
                    {
                        Label = "Tax",
                        Name = "tax",
                        Type = InputType.CHAR
                    },
                    new Input()
                    {
                        Label = "Invoice ID",
                        Name = "invoice_id",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Item ID",
                        Name = "item_id",
                        Type = InputType.INT
                    }
                }
            },
            new Table()
            {
                Label = "Sales",
                Name = "sales",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "User ID",
                        Name = "user_id",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Invoice ID",
                        Name = "invoice_id",
                        Type = InputType.INT
                    }
                }
            },
            new Table()
            {
                Label = "Sale Item",
                Name = "sale_item",
                Inputs = new Input[]
                {
                    new Input()
                    {
                        Label = "Item ID",
                        Name = "item_id",
                        Type = InputType.INT
                    },
                    new Input()
                    {
                        Label = "Sale ID",
                        Name = "sale_id",
                        Type = InputType.INT
                    }
                }
            }
        };

        SqlConnection connection = new SqlConnection("Data Source=RACUNAR202\\SQLEXPRESS;Initial Catalog=store;Integrated Security=True");

        public EditForm()
        {
            InitializeComponent();

            TableSelect.DataSource = tables;
            TableSelect.DisplayMember = "Label";
            TableSelect.ValueMember = "Name";

            InputsTableLayout.AutoSize = true;
            InputsTableLayout.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            InputsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void LoadData()
        {
            var table = tables[TableSelect.SelectedIndex];

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {table.Name}", connection);
            data = new DataTable();
            adapter.Fill(data);
        }

        private void UpdateInputFields()
        {
            if (data.Rows.Count == 0)
                return;

            var dataRow = data.Rows[currentIndex];

            var table = tables[TableSelect.SelectedIndex];

            currentID = (int)dataRow[0];

            for (int i = 0; i < table.Inputs.Length; i++)
            {
                var input = table.Inputs[i];
                var inputControl = InputsTableLayout.Controls[(i * 2) + 1];
                var fieldIndex = i + 1;

                switch (input.Type)
                {
                    case InputType.INT:
                        (inputControl as NumericUpDown).Value = int.Parse(dataRow[fieldIndex].ToString());
                        break;
                    case InputType.DECIMAL:
                        (inputControl as DecimalBox).Text = dataRow[fieldIndex].ToString();
                        break;
                    case InputType.VARCHAR:
                    case InputType.TEXT:
                        (inputControl as TextBox).Text  = dataRow[fieldIndex].ToString();
                        break;
                    case InputType.CHAR:
                        (inputControl as CheckBox).Checked = dataRow[fieldIndex].ToString() == "1";
                        break;
                }
            }
        }

        private void UpdateDisplay()
        {
            if (currentIndex >= data.Rows.Count - 1 || currentID == -1) NextButton.Enabled = false;
            else NextButton.Enabled = true;
            if (currentIndex == 0 || currentID == -1) PreviousButton.Enabled = false;
            else PreviousButton.Enabled = true;

            UpdateButton.Enabled = currentID != -1;
            DeleteButton.Enabled = currentID != -1;

            ItemCountLabel.Text = $"{currentIndex + 1} / {data.Rows.Count}";
        }

        private void TableSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();

            var inputs = tables[TableSelect.SelectedIndex].Inputs;

            InputsTableLayout.Controls.Clear();
            InputsTableLayout.RowCount = inputs.Length;

            for (int i = 0; i < inputs.Length; i++)
            {
                var input = inputs[i];

                var label = new Label();
                label.Text = input.Label;

                Control inputBox = new TextBox();
                switch (input.Type)
                {
                    case InputType.INT:
                        inputBox = new NumericUpDown();
                        break;
                    case InputType.DECIMAL:
                        inputBox = new DecimalBox();
                        break;
                    case InputType.VARCHAR:
                    case InputType.TEXT:
                        inputBox = new TextBox();
                        break;
                    case InputType.CHAR:
                        inputBox = new CheckBox();
                        break;
                }

                InputsTableLayout.Controls.Add(label, 0, i);
                InputsTableLayout.Controls.Add(inputBox, 1, i);
            }

            currentID = -1;
            currentIndex = 0;
            UpdateInputFields();
            UpdateDisplay();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            currentIndex--;

            UpdateInputFields();
            UpdateDisplay();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currentIndex++;

            UpdateInputFields();
            UpdateDisplay();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            var table = tables[TableSelect.SelectedIndex];

            var query = $"INSERT INTO {table.Name} VALUES (";
            
            for (int i = 0; i < table.Inputs.Length; i++)
            {
                var input = table.Inputs[i];
                var inputControl = InputsTableLayout.Controls[(i * 2) + 1];

                switch (input.Type)
                {
                    case InputType.INT:
                        query += (inputControl as NumericUpDown).Value + ", ";
                        break;
                    case InputType.DECIMAL:
                        query += (inputControl as DecimalBox).Text + ", ";
                        break;
                    case InputType.VARCHAR:
                    case InputType.TEXT:
                        query += "'" + (inputControl as TextBox).Text + "', ";
                        break;
                    case InputType.CHAR:
                        query += ((inputControl as CheckBox).Checked ? "1" : "0") + ", ";
                        break;
                }
            }

            query = query.TrimEnd(' ').TrimEnd(',');
            query += ");";

            var cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            LoadData();
            currentIndex = data.Rows.Count - 1;
            UpdateInputFields();
            UpdateDisplay();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var table = tables[TableSelect.SelectedIndex];

            var query = $"UPDATE {table.Name} SET ";

            for (int i = 0; i < table.Inputs.Length; i++)
            {
                var input = table.Inputs[i];
                var inputControl = InputsTableLayout.Controls[(i * 2) + 1];

                switch (input.Type)
                {
                    case InputType.INT:
                        query += input.Name + " = " + (inputControl as NumericUpDown).Value + ", ";
                        break;
                    case InputType.DECIMAL:
                        query += input.Name + " = " + (inputControl as DecimalBox).Text + ", ";
                        break;
                    case InputType.VARCHAR:
                    case InputType.TEXT:
                        query += input.Name + " = " + "'" + (inputControl as TextBox).Text + "', ";
                        break;
                    case InputType.CHAR:
                        query += input.Name + " = " + ((inputControl as CheckBox).Checked ? "1" : "0") + ", ";
                        break;
                }
            }

            query = query.TrimEnd(' ').TrimEnd(',');
            query += $" WHERE id = {currentID};";

            var cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            LoadData();
            UpdateInputFields();
            UpdateDisplay();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var table = tables[TableSelect.SelectedIndex];

            var query = $"DELETE {table.Name} WHERE id = " + currentID;

            var cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            currentID = -1;
            currentIndex = 0;
            LoadData();
            UpdateInputFields();
            UpdateDisplay();
        }
    }
}
