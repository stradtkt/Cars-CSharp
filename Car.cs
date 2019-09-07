namespace Cars
{
    public class Car
    {
        public int id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }

        internal static Car ParseFromCsv(string line)
        {
            var columns = line.Split(',');
            return new Car()
            {
                id = int.Parse(columns[0]),
                Year = int.Parse(columns[1]),
                Make = columns[2],
                Model = columns[3],
                City = int.Parse(columns[4]),
                Highway = int.Parse(columns[5])
            };
        }
    }
}