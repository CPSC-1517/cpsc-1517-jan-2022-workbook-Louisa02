using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    internal class Engine
    {
        private int _HP;
        private string _Model;
        private string _SerialNumber;
        private int _Weight;

        public int HP 
        { 
            get
            { return _HP; }
            set
            {
                if (value > 5500 || value < 3500)
                {
                    throw new ArgumentException("Horse Power must be a positive whole number between 3500 and 5500.");
                }
                _HP = value;
            }
        }
        public string Model
        {
            get 
            { return _Model; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model cannot be empty, null or whitespace.");
                }
                _Model = value;
            }
        }
        public string SerialNumber 
        { 
            get { return _SerialNumber; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Serial Number cannot be empty, null or whitespace.");
                }
                _SerialNumber = value;
            }
        }
        public  int Weight 
        { 
            get { return _Weight; }
            set
            { 
                if (value <= 0)
                {
                    throw new Exception("Weight must be a positive and non-zero whole number.");
                }
                _Weight = value; 
            }
        }

        public Engine(int hp, string model, string serialNumber, int weight)
        {
            HP = hp;
            Model = model;
            SerialNumber = serialNumber;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{HP},{Model},{SerialNumber},{Weight}";
        }


    }
}
