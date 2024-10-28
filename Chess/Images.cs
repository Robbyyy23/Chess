using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    public class Images
    {
        private readonly Dictionary<PieceType, Image> whiteSources;
        private readonly Dictionary<PieceType, Image> blackSources;

        public Images()
        {
            whiteSources = new Dictionary<PieceType, Image>
        {
            { PieceType.Pawn, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\WP.png") },
            { PieceType.Bishop, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\WB.png") },
            { PieceType.Knight, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\WN.png") },
            { PieceType.Rook, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\WR.png") },
            { PieceType.Queen, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\WQ.png") },
            { PieceType.King, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\WK.png") },
        };

            blackSources = new Dictionary<PieceType, Image>
        {
            { PieceType.Pawn, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\BP.png") },
            { PieceType.Bishop, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\BB.png") },
            { PieceType.Knight, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\BN.png") },
            { PieceType.Rook, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\BR.png") },
            { PieceType.Queen, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\BQ.png") },
            { PieceType.King, LoadImage("C:\\Program Files (x86)\\Proiectare\\Chess\\Chess\\Resources\\Poze piese\\BK.png") },
        };
        }


        private  Image LoadImage(string filePath)
        {
            return Image.FromFile(filePath);
        }

        public Image GetImage(Player color, PieceType type)
        {
            switch (color)
            {
                case Player.White:
                    return whiteSources.ContainsKey(type) ? whiteSources[type] : null;
                case Player.Black:
                    return blackSources.ContainsKey(type) ? blackSources[type] : null;
                default:
                    return null;
            }
        }
        public  Image GetImage(Piece piece)
        {
            if (piece == null) return null;
            return GetImage(piece.Color, piece.Type);
        }

        
    }

}
