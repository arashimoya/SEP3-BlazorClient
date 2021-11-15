namespace ABDOTClient.Shared.Classes
{
    public class Seat
    {
        private int id { set; get; }
        private int Row { set; get; }
        private int Column { set; get; }

        public Seat(int id, int Row, int Column)
        {
            this.id = id;
            this.Row = Row;
            this.Column = Column;
        }
    }
}