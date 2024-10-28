using System.Windows.Forms;

namespace Chess
{
    public class ChessCursors
    {
        //public Cursor WhiteCursor { get; private set; }
        public Cursor BlackCursor { get; private set; }

        public ChessCursors()
        {
            //WhiteCursor = LoadCursor("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\aero_arrow_black.cur");
            BlackCursor = LoadCursor("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\aero_arrow_black.cur");
        }
        public Cursor LoadCursor(string filePath)
        {
            return new Cursor(filePath);
        }
    }
}
