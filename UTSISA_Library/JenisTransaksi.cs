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
        private int kodeJenis;
        private string nama;
        #endregion

        #region Constructors
        public JenisTransaksi(int kodeJenis, string nama)
        {
            this.KodeJenis = kodeJenis;
            this.Nama = nama;
        }
        public JenisTransaksi(int kodeJenis)
        {
            this.KodeJenis = kodeJenis;
        }
        public override string ToString()
        {
            return this.Nama;
        }
        #endregion

        #region Properties
        public int KodeJenis { get => kodeJenis; set => kodeJenis = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion
    }
}
