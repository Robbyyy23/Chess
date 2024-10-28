using System.Collections.Generic;

namespace Chess
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;      
            Column = column;
        }

        public Player SquareColor()
        {
            if((Row+Column)%2==0)
            {
                return Player.White;
            }
            return Player.Black;
        }

        public override bool Equals(object obj)
        {
            return obj is Position pozitie &&
                   Row == pozitie.Row &&
                   Column == pozitie.Column;
        }

        public override int GetHashCode()
        {
            int hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public Position Add(Direction dir)
        {
            return new Position(Row + dir.RowDelta, Column + dir.ColumnDelta);
        }

    }
}
