using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "GAGAL";
            SqlConnection sqlcon = new SqlConnection("Data Source=LAPTOP-N38C71DV; Initial Catalog=\"TI UMY\"; Persist Security Info=True; User ID=sa; Password=Kawan123");
            string query = String.Format("Insert into dbo.Mahasiswa values ('{0}', '{1}', '{2}', '{3}')", mhs.nim, mhs.nama, mhs.prodi, mhs.angkatan);
            SqlCommand sqlcom = new SqlCommand(query, sqlcon); //yang dikirim ke sql

            try
            {
                sqlcon.Open(); //membuka connection sql

                Console.WriteLine(query);

                sqlcom.ExecuteNonQuery(); //mengeksekusi untuk memasukkan data

                sqlcon.Close();

                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-N38C71DV; Initial Catalog=\"TI UMY\"; Persist Security Info=True; User ID=sa; Password=Kawan123");
            string query = "select NIM, Nama, Prodi, Angkatan from dbo.Mahasiswa";
            SqlCommand com = new SqlCommand(query, con); // yang dikirim ke sql

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader(); //mendapatkan data yang telah dieksekusi, dari select. Hasil query ditaruh di reader

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nim = reader.GetString(0); // 0 itu array pertama // ini diambil dari IService
                    mhs.nama = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);

                    mahas.Add(mhs);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mahas; // output
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-N38C71DV; Initial Catalog=\"TI UMY\"; Persist Security Info=True; User ID=sa; Password=Kawan123");
            string query = String.Format("select NIM, Nama, Prodi, Angkatan from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader(); //mendapatkan data yang telah dieksekusi, dari select. Hasil query ditaruh di reader

                while (reader.Read())
                {
                    mhs.nim = reader.GetString(0); // 0 itu array pertama // ini diambil dari IService
                    mhs.nama = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }

        public string DeleteMahasiswa(string nim)
        {
            string msg = "GAGAL";
            SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-N38C71DV; Initial Catalog=\"TI UMY\"; Persist Security Info=True; User ID=sa; Password=Kawan123");
            string query = String.Format("Delete from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand cmd = new SqlCommand(query, con2); //yang dikirim ke sql

            try
            {
                con2.Open(); //membuka connection sql

                Console.WriteLine(query);

                cmd.ExecuteNonQuery(); //mengeksekusi untuk memasukkan data

                con2.Close();

                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public string UpdateMahasiswa(string nim, string nama, string prodi, string angkatan)
        {
            string msg = "GAGAL";
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-N38C71DV; Initial Catalog=\"TI UMY\"; Persist Security Info=True; User ID=sa; Password=Kawan123");
            string query = "update dbo.Mahasiswa set Nama = '" + nama + "', Prodi = '" + prodi + "', Angkatan = '" + angkatan + "'" +
                " where NIM = '" + nim + "' ";
            SqlCommand cmd2 = new SqlCommand(query, conn); //yang dikirim ke sql

            try
            {
                conn.Open(); //membuka connection sql

                Console.WriteLine(query);

                cmd2.ExecuteNonQuery(); //mengeksekusi untuk memasukkan data

                conn.Close();

                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        /*public string HitungMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();

            SqlConnection sqlcon2 = new SqlConnection("Data Source=LAPTOP-N38C71DV; Initial Catalog=\"TI UMY\"; Persist Security Info=True; User ID=sa; Password=Kawan123");
            string query = "select count (*) from Mahasiswa";
            SqlCommand sqlcom = new SqlCommand(query, sqlcon2); //yang dikirim ke sql

            try
            {
                sqlcon2.Open(); //membuka connection sql
                
                SqlDataReader reader = sqlcom.ExecuteReader(); //mengeksekusi untuk memasukkan data

                sqlcon2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }

            return mahas;
        }*/
    }
}
