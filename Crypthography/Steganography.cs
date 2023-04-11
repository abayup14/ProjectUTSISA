using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting.Hosting;


namespace Crypthography
{
    public class Steganography
    {
        private ScriptEngine engine;
        private ScriptScope scope;

        public Steganography()
        {
            Engine = Python.CreateEngine();
            Scope = Engine.CreateScope();
        }

        public ScriptEngine Engine { get => engine; set => engine = value; }
        public ScriptScope Scope { get => scope; set => scope = value; }
    }
}
