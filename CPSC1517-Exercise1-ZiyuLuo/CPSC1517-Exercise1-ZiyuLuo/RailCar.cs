using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    internal class RailCar
    {
        private int _Capacity;
        private int _LightWeight;
        private int _LoadLimit;
        private string _SerialNumber;
        
        public int Capacity
        {
            get { return _Capacity; }
            set 
            {
                if (value > _LoadLimit)
                {
                    throw new ArgumentException("Capacity must be less than the Load Limit.");
                }
                _Capacity = value; 
            }
        }

        public int LightWeight
        {
            get { return _LightWeight; }
            set 
            { 
                if (value <= 0)
                {
                    throw new Exception("Light Weight must be a positive and non-zero whole number.");
                }
                _LightWeight = value; 
            }
        }

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set 
            { 
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Serial Number cannot be null, empty or just whitespace.");
                }
                _SerialNumber = value;
            }
        }

        public int LoadLimit
        {
            get { return _LoadLimit; }
            set 
            { 
                if (value <= 0)
                {
                    throw new Exception("Load Limit must be a positive and non-zero whole number");
                }
                _LoadLimit = value; 
            } 
        }

        public RailCarType CarType { get; set; }


    }
}
