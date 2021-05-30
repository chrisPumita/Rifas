using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;

namespace CONCURSO
{
    class IMPRESORA
    {
        Font _fontdetalle = new Font("Consolas", 8, FontStyle.Regular, GraphicsUnit.Point);
        Font _fontTOTAL = new Font("Consolas", 8, FontStyle.Bold, GraphicsUnit.Point);
        Font font = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
        Font fontBlack = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);
        Font fontCursive = new Font("Arial", 7, FontStyle.Italic, GraphicsUnit.Point);
        Font fontFolio = new Font("Consolas", 25, FontStyle.Bold, GraphicsUnit.Point);
        Font fontFolioGde = new Font("Consolas", 45, FontStyle.Bold, GraphicsUnit.Point);
        Font terminos = new Font("Arial", 7, FontStyle.Italic, GraphicsUnit.Point);
        Font obligaciones = new Font("Consolas", 5, FontStyle.Italic, GraphicsUnit.Point);
        int ancho = Convert.ToInt32(Convert.ToDouble(Properties.Settings.Default.printerWidth) * 3.779527559055);
        int y = 5;
        int marginLeft = 0;
        int interlineado = 12;
        Image img = Properties.Resources.image;

        public void imprimir(string nombre, string monto, string folio, bool corte, PrintPageEventArgs e)
        {
            //Colocar el icono predefinido
            e.Graphics.DrawImage(img, new Rectangle(interlineado+20, 0 , (85), 46));
            y += (interlineado * 3);
            e.Graphics.DrawString("**Rifa Anual 1er Aniversario**", fontBlack, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("  " + folio + "", fontFolio, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado * 5));
            e.Graphics.DrawString("______                     ______", fontBlack, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            y += interlineado * 1;
            e.Graphics.DrawString("GRACIAS " + nombre, fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("Por tu compra de: $" + monto, fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(DateTime.Now.ToShortDateString()+" " + DateTime.Now.ToShortTimeString(), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));

            e.Graphics.DrawString("", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("-Rifaremos regalos el DÍA:", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(" VIERNES 18 DE JUNIO A LA 1:00 PM", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("-Para conocer el ganador sigue nuestras", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("  historias en WhatsApp (55 1080 1566)", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(" o visitanos; publicaremos al ganador(a)", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(" en la entrada de ReCkrea CyberCafé", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            
            e.Graphics.DrawString("      *** MUCHA SUERTE :) ***", fontBlack, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(" == Gracias por tu preferencia ==", fontBlack, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("IMPORTANTE: Es necesario presentar este ", obligaciones, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("   boleto para reclamar el premio", obligaciones, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("", fontBlack, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("8<---------------------------------------", _fontTOTAL, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("", terminos, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawImage(img, new Rectangle(interlineado + 80, y+=interlineado, (85), 46));
            e.Graphics.DrawString(folio + "", fontFolio, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado * 5));
            e.Graphics.DrawString("______                     ______", fontBlack, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("", fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("" + nombre, fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString("Compra: $" + monto, fontCursive, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            e.Graphics.DrawString(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), _fontdetalle, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
            if(corte)
                e.Graphics.DrawString("8<---------------------------------------", _fontTOTAL, Brushes.Black, new RectangleF(marginLeft, y += interlineado, ancho, interlineado));
        }

    }
}
