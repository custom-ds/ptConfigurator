using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoTrack_Configurator
{
    class Symbol
    {
        string _description;
        string _symbolChars;

        public string Description { get { return _description; } set { _description = value; } }

        public string SymbolChars { get { return _symbolChars; } set { _symbolChars = value; } }

        public Symbol(string symbolChars, string description)
        {
            this._symbolChars = symbolChars;
            this._description = description;
        }
    }

}
