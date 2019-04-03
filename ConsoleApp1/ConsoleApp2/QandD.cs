using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class QandD
    {
        public QandD()
        {
            var ausdruck = true && true;    // bedingte Auswertung
            ausdruck = true & false;        // Prüfung läuft bis zum Ende durch

            ausdruck = true | false;
            ausdruck = true || false;

            bool x = true;
            bool y = !x;

            x = !x;

        }
    }
}
