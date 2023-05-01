using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace UTSISA_Library
{
    public class Cetak
    {
        #region Data Members
        private Font fontType;
        private StreamReader printToFile;
        private float marginLeft, marginRight, marginTop, marginBottom;
        #endregion

        #region Constructors
        public Cetak(Font fontType, string pathToFile, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            this.FontType = fontType;
            this.PrintToFile = new StreamReader(pathToFile);
            this.MarginLeft = marginLeft;
            this.MarginRight = marginRight;
            this.MarginTop = marginTop;
            this.MarginBottom = marginBottom;
        }
        #endregion

        #region Properties
        public Font FontType { get => fontType; set => fontType = value; }
        public StreamReader PrintToFile { get => printToFile; set => printToFile = value; }
        public float MarginLeft { get => marginLeft; set => marginLeft = value; }
        public float MarginRight { get => marginRight; set => marginRight = value; }
        public float MarginTop { get => marginTop; set => marginTop = value; }
        public float MarginBottom { get => marginBottom; set => marginBottom = value; }
        #endregion

        #region Methods
        private void CetakTeks(object sender, PrintPageEventArgs e)
        {
            int maxRow = (int)((e.MarginBounds.Height - MarginTop - MarginBottom) / FontType.GetHeight(e.Graphics));

            float y = MarginTop;

            int rowNum = 0;

            string rowText = printToFile.ReadLine();

            while (rowNum < maxRow && rowText != null)
            {
                y = MarginTop + (rowNum * FontType.GetHeight(e.Graphics));

                e.Graphics.DrawString(rowText, FontType, Brushes.Black, MarginLeft, y);

                rowNum++;

                rowText = printToFile.ReadLine();
            }

            if (rowText != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public void SentToPrinter()
        {
            PrintDocument p = new PrintDocument();

            p.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            p.PrintPage += new PrintPageEventHandler(CetakTeks);

            p.Print();

            PrintToFile.Close();
        }
        #endregion
    }
}
