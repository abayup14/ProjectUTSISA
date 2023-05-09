using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSISA_Library
{
    public class JenisPengguna
    {
        #region Data Members
        private string kodeJenis;
        private string nama;
        #endregion

        #region Constructors
        public JenisPengguna(string kodeJenis, string nama)
        {
            this.KodeJenis = kodeJenis;
            this.Nama = nama;
        }
        public JenisPengguna(string kodeJenis)
        {
            this.KodeJenis = kodeJenis;
        }
        #endregion

        #region Properties
        public string KodeJenis { get => kodeJenis; set => kodeJenis = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region Method
        public override string ToString()
        {
            return this.Nama;
        }
        #endregion
    }
}
