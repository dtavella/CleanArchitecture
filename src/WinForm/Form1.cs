using Core.Dtos;
using System.Net.Http.Json;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void cmbCountry_DropDown(object sender, EventArgs e)
        {
            var client = new HttpClient();

            var dtos = await client.GetFromJsonAsync<List<ItemDto>>("https://localhost:7153/api/country");

            cmbCountry.DataSource = dtos;
            cmbCountry.ValueMember = nameof(ItemDto.Id);
            cmbCountry.DisplayMember = nameof(ItemDto.Name);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            txtCheck.AppendText("click");
        }
    }
}