namespace ProgrammingPracticeCourseWork
{
    public class Galaxy
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string age;
        public string Age 
        { 
            get => this.age; 
            set
            {
                double ag;
                if (double.TryParse(value.Remove(value.Length - 1, 1), out ag) && (char.ToLower(value[value.Length - 1]) == 'm' || char.ToLower(value[value.Length - 1]) == 'b'))
                {
                    this.age = value;
                }
                else
                {
                    this.age = "unknown";
                }
            }
        }
        public Galaxy(){}
    }
}