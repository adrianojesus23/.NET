namespace Demo
{
    public class POO
    {
        //Fields
        public string _Name;
        public string _Description;
        //Properties
        private String Name { get => _Name; set => _Name = value; }

        private String Description { get => _Description; set => _Description = value; }
        //Constructor

        public POO()
        {

        }
        public POO(string name, string description)
        {
            Name = name;
            Description = description;
        }
        //Method

        public string Get(POO p)
        => $"{p.Name} - {p.Description}";

        public string GetValue(ref string name) => name;

        public enum DayOfYear
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public struct WotkTask
        {
            public string Name;
            public string Description;

            public DateTime GetDate(DateTime dateTime)
            {
                switch (dateTime.DayOfWeek)
                {

                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        return dateTime.ToUniversalTime().Date;
                    case DayOfWeek.Sunday:
                        break;
                    case DayOfWeek.Saturday:
                        break;
                    default:
                        break;
                }
                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                    return dateTime.ToUniversalTime();

                return dateTime.AddDays(1);
            }
            public string GetString() => $"{Name} - {Description}";
        }

    }
}
