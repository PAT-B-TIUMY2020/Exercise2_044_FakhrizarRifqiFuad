using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net;

namespace Exercise2_20180140044_FakhrizarRifqiFuad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DataContract]
        public class Mahasiswa
        {
            private string _nim, _nama, _prodi, _angkatan;
            [DataMember]
            public string nim
            {
                get { return _nim; }
                set { _nim = value; }
            }
            [DataMember]
            public string nama
            {
                get { return _nama; }
                set { _nama = value; }
            }
            [DataMember]
            public string prodi
            {
                get { return _prodi; }
                set { _prodi = value; }
            }
            [DataMember]
            public string angkatan
            {
                get { return _angkatan; }
                set { _angkatan = value; }
            }
        }

        string baseUrl = "http://localhost:1907/";

        public void TampilData()
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

            dtMahasiswa.DataSource = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btDelete.Enabled = false;
            btUpdate.Enabled = false;
            btSearch.Enabled = false;
            textBoxSearch.Enabled = false;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            if (textBoxNim.Text == "")
            {
                MessageBox.Show("NIM Tidak Boleh Kosong.....!!!");
            }
            else
            {
                try
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nim = textBoxNim.Text;
                    mhs.nama = textBoxNama.Text;
                    mhs.prodi = textBoxProdi.Text;
                    mhs.angkatan = textBoxAngkatan.Text;

                    var output = JsonConvert.SerializeObject(mhs);
                    var postdata = new WebClient();
                    postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    string response = postdata.UploadString(baseUrl + "Mahasiswa", output);
                    Console.WriteLine(response);
                    TampilData();
                    MessageBox.Show("Successfull Inserted");
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to Inserted");
                }
            }
        }

        public void Clear()
        {
            textBoxNim.Clear();
            textBoxNama.Clear();
            textBoxProdi.Clear();
            textBoxAngkatan.Clear();

            btInsert.Enabled = true;
            btUpdate.Enabled = false;
            btDelete.Enabled = false;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
                var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

                string nim = textBoxNim.Text;
                if (nim != null || nim != "")
                {
                    var item = data.Where(x => x.nim == textBoxNim.Text).ToList();
                    dtMahasiswa.DataSource = item;
                }
                else
                {
                    dtMahasiswa.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

            try
            {
                string nim = textBoxNim.Text;
                var item = data.Where(x => x.nim == textBoxNim.Text).FirstOrDefault();
                if (item != null)
                {
                    item.nim = textBoxNim.Text;
                    item.nama = textBoxNama.Text;
                    item.prodi = textBoxProdi.Text;
                    item.angkatan = textBoxAngkatan.Text;

                    string output = JsonConvert.SerializeObject(item, Formatting.Indented);
                    var postdata = new WebClient();
                    postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    string response = postdata.UploadString(baseUrl + "UpdateMahasiswa", output);
                    Console.WriteLine(response);
                    TampilData();
                    MessageBox.Show("Successfull Updated");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Updated");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);

            try
            {
                string nim = textBoxNim.Text;
                var item = data.Where(x => x.nim == textBoxNim.Text).FirstOrDefault();
                if (item != null)
                {
                    data.Remove(item);
                    string output = JsonConvert.SerializeObject(item, Formatting.Indented);
                    var postdata = new WebClient();
                    postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    string response = postdata.UploadString(baseUrl + "DeleteMahasiswa", output);
                    Console.WriteLine(response);
                    TampilData();
                    MessageBox.Show("Successfull Deleted");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Deleted");
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            btSearch.Enabled = true;
            btDelete.Enabled = true;
            btUpdate.Enabled = true;
            textBoxSearch.Enabled = true;

            TampilData();
        }

        private void dtMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNim.Text = Convert.ToString(dtMahasiswa.Rows[e.RowIndex].Cells[0].Value);
            textBoxNama.Text = Convert.ToString(dtMahasiswa.Rows[e.RowIndex].Cells[1].Value);
            textBoxProdi.Text = Convert.ToString(dtMahasiswa.Rows[e.RowIndex].Cells[2].Value);
            textBoxAngkatan.Text = Convert.ToString(dtMahasiswa.Rows[e.RowIndex].Cells[3].Value);

            btSearch.Enabled = true;
            btUpdate.Enabled = true;
            btDelete.Enabled = true;
            textBoxSearch.Enabled = true;
        }
    }
}
