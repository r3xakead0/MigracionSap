using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System;
using System.Globalization;
using System.Text;
using System.IO;
using System.Reflection;

namespace MigracionSap.Presentacion
{
    public class General 
    {
        
        //Titulo de la Aplicacion
        private static string TitleApplication = "Migracion de Documentos";

        public static void PointerLoad(Form form)
        {
            form.Cursor = Cursors.WaitCursor;
        }

        public static void PointerReady(Form form)
        {
            form.Cursor = Cursors.Arrow;
        }

        #region Mensajes

        public static void ErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, TitleApplication, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CriticalMessage(string mensaje)
        {
            MessageBox.Show(mensaje, TitleApplication, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void InformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, TitleApplication, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ConfirmationMessage(string mensaje)
        {

            DialogResult rpta = MessageBox.Show(mensaje, TitleApplication, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rpta == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        public static void FormatDatagridview(ref DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.AllowDrop = false;
            dgv.RowHeadersVisible = false;
        }

        public static void AutoWidthColumn(ref DataGridView dgv, string columnName, bool scroll = true)
        {

            int width = dgv.Width - (scroll == true ? 20 : 3);

            if (dgv.RowHeadersVisible == true)
                width = width - dgv.RowHeadersWidth;

            for (int c = 0; c <= dgv.ColumnCount - 1; c++)
            {
                if (c != dgv.Columns[columnName].Index)
                {
                    if (dgv.Columns[c].Visible)
                    {
                        width = width - dgv.Columns[c].Width;
                    }
                }
            }

            dgv.Columns[columnName].Width = width;

        }

        public static string GetNameOfDay(int day)
        {
            string nombreDia = "";

            switch (day)
            {
                case 1:
                    nombreDia = "Lunes";
                    break;
                case 2:
                    nombreDia = "Martes";
                    break;
                case 3:
                    nombreDia = "Miercoles";
                    break;
                case 4:
                    nombreDia = "Jueves";
                    break;
                case 5:
                    nombreDia = "Viernes";
                    break;
                case 6:
                    nombreDia = "Sabado";
                    break;
                default:
                    nombreDia = "Domingo";
                    break;
            }

            return nombreDia;
        }

        public static int GetWeekNumber(DateTime date)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public static string GetNameOfMonth(int month)
        {
            string nameMonth = "";

            switch (month)
            {
                case 1:
                    nameMonth = "Enero";
                    break;
                case 2:
                    nameMonth = "Febrero";
                    break;
                case 3:
                    nameMonth = "Marzo";
                    break;
                case 4:
                    nameMonth = "Abril";
                    break;
                case 5:
                    nameMonth = "Mayo";
                    break;
                case 6:
                    nameMonth = "Junio";
                    break;
                case 7:
                    nameMonth = "Julio";
                    break;
                case 8:
                    nameMonth = "Agosto";
                    break;
                case 9:
                    nameMonth = "Septiembre";
                    break;
                case 10:
                    nameMonth = "Octubre";
                    break;
                case 11:
                    nameMonth = "Noviembre";
                    break;
                default:
                    nameMonth = "Diciembre";
                    break;
            }

            return nameMonth;
        }

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }

        public static DateTime ParseStringToDatetime(string dateString, string formatDate = "dd/MM/yyyy")
        {
            return DateTime.ParseExact(dateString, formatDate, CultureInfo.InvariantCulture);
        }

        public static string ParseMinutesToHours(int minutes, string formatDate = @"HH:mm")
        {
            string strValor = "";

            var span = TimeSpan.FromMinutes(minutes);
            strValor = string.Format("{0:00}:{1:00}", (int)span.TotalHours, span.Minutes);
            
            return strValor;
        }

        
        public static void DatagridviewToCsv(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
            {
                if (dGV.Columns[j].Visible == true)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            }
            stOutput += sHeaders + "\r\n";

            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";

                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                {
                    if (dGV.Columns[j].Visible == true)
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                }

                stOutput += stLine + "\r\n";
            }

            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(output, 0, output.Length); //write the encoded file
                    bw.Flush();
                    bw.Close();
                }
                fs.Close();
            }

        }

        public static string GetTitle()
        {
            return TitleApplication;
        }

        public static string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString(); ;
        }

    }
}
