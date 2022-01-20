using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Person
    {
        // example of a composite class
        // a composite class uses other classes in its definition
        // a composite class is recognized with the phrase "has a" class
        // this class Person "has a"  resident address


        // an inherited class extends another class in its definition
        // an iherited class is recognized with the phrase "is a " class
        // assume a general class called Transportation
        //     public class Vehicle: Transportation
        //     public class Bike: Transportation
        //     public class Bike: Transportation
        //     public class Boat: Transportation

        // each instance of this class will represent an individual
        // This class will define the following characteristics of a person
        // First Name, Last Name, the current resident address, list of employment positions

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get 
            { 
                return _FirstName; 
            }
            set
            {
                if(Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("First name is required.");
                }
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("Last name is required.");
                }
                _LastName = value;
            }
        }

        // composite actually uses other class as a property/field within
        // the definition of the class being defined
        public ResidentAddress Address;

        // composition
        public List<Employment> EmploymentPositions { get; set; }

        /* public Person()
        {
            // if an instance of List<T> is not created and assigned then
            // the property will have an initial value of null

            EmploymentPositions = new List<Employment>();

            // Option 1
            // Since FirstName and LastName need to have values
            // you can assgin default literals to the properties

            FirstName = "Unknown";
            LastName = "Unknown";
        } */

        // Option 2
        // DO NOT code a "default" constructor
        // CODE ONLY the "greedy" constructor
        // if only a greedy constructor exits for the class, the ONLY
        // way to possibly create an instance for the class within
        // the program is to use the constructor when the class instance is created
        
        public Person(string firstName, string lastName, List<Employment> employmentsPositions, ResidentAddress address)
        {
            FirstName = firstName;
            LastName = lastName;
            if (employmentsPositions != null)
                EmploymentPositions = employmentsPositions;
            else
                // allows a null value and the class to have an empty List<T>
                EmploymentPositions = new List<Employment>();
            Address = address;
        }

    }
}
