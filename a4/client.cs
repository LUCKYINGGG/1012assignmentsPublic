

namespace ClientInfor
{
    public class Client
    {
        private string _firstname;
        private string _lastname;
        private int _weight;
        private int _height;

//greedy constructor
        public Client(string firstname, string lastname, int weight, int height)
        {
            _firstname = firstname;
            _lastname = lastname;
            _weight = weight;
            _height = height;
        }

//Properties
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Lastname
        {
            get { return _lastname; }
        }
        
        public int Weight{
            get { return _weight; }
        }

        public int Height{
            get { return _height; }
        }
        
        public double BmiScore
        {
            get { 
                double bmi = _weight / _height * _height * 703;
                return bmi;
                }
        }
        public string BmiStatus
        {
            get { 
                return "status";
            }
        }

        public string FullName
        {
            get { return $"{_lastname}, {_firstname}"; }
        }


    }// end of class

}// end of namespace