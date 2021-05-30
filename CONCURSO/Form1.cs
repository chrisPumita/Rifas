using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONCURSO
{
    public partial class Form1 : Form
    {
        decimal MIN_COMRPA = 30;
        PrintPageEventArgs e;

        string _nombre;
        string _folio;
        string _monto;
        bool _corte;

        public Form1()
        {
            InitializeComponent();
            cboNombres.SelectedIndex = 0;
            limpia();
        }

        private void limpia()
        {
            txtNombre.Clear();
            numCompra.Value = numCompra.Minimum;
            txtNombre.Focus();
            this.Text = "ReCkrea 1er Aniversario - " + Properties.Settings.Default.folio + " boletos generados";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generarBoleto();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numCompra.Focus();
            }
        }

        private void numCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generarBoleto();
            }
        }

        private void generarBoleto() 
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (numCompra.Value >= MIN_COMRPA)
                {
                    decimal compra = numCompra.Value;
                    int NoTicket = Convert.ToInt32(Math.Floor(compra / MIN_COMRPA));

                    for (int i = 0; i < NoTicket; i++)
                    {
                        if (addCliente(txtNombre.Text, numCompra.Value))
                        {
                            //imprimir boleto
                            this._corte = false;
                            this._nombre = txtNombre.Text;
                            this._monto = numCompra.Value.ToString();
                            this._folio = Properties.Settings.Default.folio.ToString();

                            if ((i+1)!=NoTicket)
                                this._corte = true;
                            printDocument1 = new PrintDocument();
                            PrinterSettings ps = new PrinterSettings();
                            //  elejir la impresora a donde se va a imprimir
                            ps.DefaultPageSettings.PrinterSettings.PrinterName = Properties.Settings.Default.printerTicket;
                            printDocument1.PrinterSettings = ps;
                            printDocument1.PrintPage += imprimirBoleto;
                            printDocument1.Print();
                            MessageBox.Show("Porfavor corte el boleto " + (i+1) + " de "+ NoTicket);
                        }
                    }
                    limpia();
                }
                else
                {
                    MessageBox.Show("El minimo de compra debe ser de $" + MIN_COMRPA);
                    numCompra.Focus();
                }
            }
            else
            {
                MessageBox.Show("Porfavor escriba el nombre del participante");
                txtNombre.Focus();
            }

        }


        //// FUNCIONES PRINCIPALES
        public bool addCliente(string nombre, decimal monto)
        {
            try 
	        {	       
                StreamWriter fichero;
                int folio = consultaFolioAnterior() + 1 ;
                //fichero = File.CreateText("registroConcurso.txt");
                //fichero.WriteLine(consultaFolioAnterior()+"\t$"+monto+"\t"+nombre);
                //fichero.Close();
                fichero = File.AppendText("registroConcurso.txt");
                fichero.WriteLine("" + cboNombres .SelectedItem.ToString()+ "\t" + folio + "\t$" + monto + "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\t" + nombre);
                fichero.Close();
                guardaFolioNuevo(folio);
                return true;
	        }
	        catch (Exception)
	        {
		        return false;
	        }
        }

        private int consultaFolioAnterior()
        {
            return Properties.Settings.Default.folio;
        }
        private void guardaFolioNuevo(int folio)
        {
            Properties.Settings.Default.folio = folio;
            Properties.Settings.Default.Save();
        }

        private void imprimirBoleto(object sender, PrintPageEventArgs e)
        {
            IMPRESORA printer = new IMPRESORA();
            printer.imprimir(_nombre, _monto, _folio, _corte, e);
        }
    }


}
