using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
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

        private void GetLibraryPath()
        {
            string filePath = Directory.GetCurrentDirectory();
            string parentFilePath = Directory.GetParent(filePath).Parent.FullName;

            var searchPaths = Engine.GetSearchPaths();

            searchPaths.Add(parentFilePath + @"\lib");

            Engine.SetSearchPaths(searchPaths);
        }

        public bool InstallModule(string moduleName)
        {
            string command = "pip install " + moduleName;

            GetLibraryPath();

            Engine.ImportModule("os");

            Scope.SetVariable("args", command);

            Engine.Execute("import os; os.system(args)", Scope);

            return true;
        }
    }
}
