

namespace ClientInfor
{
    public class Client
    {
        private string _firstname;
        private string _lastname;
        private int _weight;
        private int _height;

        //non-greedy constructor
        public Client()
        {
            Firstname = "Demo";
            Lastname = "One";
            Weight = 1;
            Height = 1;
        }

        //greedy constructor
        public Client(string firstname, string lastname, int weight, int height)
        {
            Firstname = firstname;
            Lastname = lastname;
            Weight = weight;
            Height = height;
        }

        //Properties
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firstname is required. Must not be empty or blank.");
                }
                _firstname = char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Lastname is required. Must not be empty or blank.");
                }
                _lastname = char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }

        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be a positive value (0 or greater)");
                }
                _weight = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be a positive value (0 or greater)");
                }
                _height = value;
            }
        }
        // Read only properties
        public double BmiScore
        {
            get
            {
                double bmi = Convert.ToDouble(Weight) / (Height * Height) * 703;
                return bmi;
            }
        }
        public string BmiStatus
        {
            get
            {
                string status = "";
                if (BmiScore >= 40)
                {
                    status = "Obese";
                }
                if (BmiScore >= 25.0 && BmiScore <= 39.9)
                {
                    status = "Overweight";
                }
                if (BmiScore >= 18.5 && BmiScore <= 24.9)
                {
                    status = "Normal";
                }
                else
                {
                    status = "Underweight";
                }
                return status;
            }
        }
        // method
        public string FullName
        {
            get
            {
                return $"{Lastname}, {Firstname}";
            }
        }
    }// end of class

}// end of namespace