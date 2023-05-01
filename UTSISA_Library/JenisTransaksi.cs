using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class JenisTransaksi
    {
        #region Data Members
        private string kodeJenis;
        private string nama;
        #endregion

        #region Constructors
        public JenisTransaksi(string kodeJenis, string nama)
        {
            this.KodeJenis = kodeJenis;
            this.Nama = nama;
        }
        public JenisTransaksi(string kodeJenis)
        {
            this.KodeJenis = kodeJenis;
        }
        #endregion

        #region Properties
        public string KodeJenis { get => kodeJenis; set => kodeJenis = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion
    }
}
