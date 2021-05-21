namespace ProgrammingPracticeCourseWork
{
    public class Star : Galaxy
    {
        public string ParentName { get; set; }
        public string clas;
        public string Clas
        {
            get => this.clas;
            set
            {
                int temperature;
                double luminosity, weight, size;
                string[] ds = value.Split(' ');
                if (double.TryParse(ds[0], out weight) && double.TryParse(ds[1], out size) && int.TryParse(ds[2], out temperature) && double.TryParse(ds[3], out luminosity))
                {
                    size = size/2.00;
                    string dt = $" ({weight.ToString("0.00")}, {size.ToString("0.00")}, {temperature}, {luminosity.ToString("0.00")})";
                    if(weight >= 16 && size >= 6.6 && temperature >= 30000 && luminosity >= 30000)
                    {
                        this.clas = "O";
                    }
                    else if(2.1 <= weight && weight < 16 && 1.8 <= size && size < 6.6 && 10000 <= temperature && temperature < 30000 && 25 <= luminosity && luminosity < 30000)
                    {
                        this.clas = "B";
                    }
                    else if(1.4 <= weight && weight < 2.1 && 1.4 <= size && size < 1.8 && 7500 <= temperature && temperature < 10000 && 5 <= luminosity && luminosity < 25)
                    {
                        this.clas = "A";
                    }
                    else if(1.04 <= weight && weight < 1.4 && 1.15 <= size && size < 1.4 && 6000 <= temperature && temperature < 7500 && 1.5 <= luminosity && luminosity < 5)
                    {
                        this.clas = "F";
                    }
                    else if(0.8 <= weight && weight < 1.04 && 0.96 <= size && size < 1.15 && 5200 <= temperature && temperature < 6000 && 0.6 <= luminosity && luminosity < 1.5)
                    {
                        this.clas = "G";
                    }
                    else if(0.45 <= weight && weight < 0.8 && 0.7 <= size && size < 0.96 && 3700 <= temperature && temperature < 5200 && 0.08 <= luminosity && luminosity < 0.6)
                    {
                        this.clas = "K";
                    }
                    else if(0.08 <= weight && weight < 0.45 && 0.7 >= size && 2400 <= temperature && temperature < 3700 && 0.08 >= luminosity)
                    {
                        this.clas = "M";
                    }
                    else 
                    {
                        this.clas = "unknown";
                    }
                    this.clas += dt;
                }
                else 
                {
                    this.clas = "unknown";
                }
                value = this.clas;
            }
        }
        public Star(){}
    }
}