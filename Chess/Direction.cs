namespace Chess
{
    public class Direction
    {

        public  Direction Nord => new Direction(-1, 0);
        public  Direction Sud => new Direction(1, 0);
        public  Direction Est => new Direction(0, 1);
        public  Direction West => new Direction(0, -1);
        public Direction NordEst => new Direction(-1, 1);
        public Direction NordWest => new Direction(-1, -1);
        public Direction SudEst => new Direction(1, 1);
        public Direction SudWest => new Direction(1, -1);
        public int RowDelta {  get; }
        public int ColumnDelta { get; }
        public Direction(int rowDelta, int columnDelta) 
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }
        public Direction CreateDirection(int rowDelta, int columnDelta)
        {
            return new Direction(rowDelta, columnDelta);
        }
        public Direction Add(Direction other)
        {
            return new Direction(RowDelta + other.RowDelta, ColumnDelta + other.ColumnDelta);
        }

        public Direction Multiply(int scalar)
        {
            return new Direction(scalar * RowDelta, scalar * ColumnDelta);
        }
    }
}
