using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    internal class Employment
    {
        // An instance of this class will hold data about a person's employment
        // The code of this class is the definition of that data
        // The characteristics (data) of the class
        // Title, SupervisoryLevel, Years of Employment within the company

        // The 4 components of a class definition are
        // data field
        // property
        // constructor
        // behaviour (method)


        // Data field
        // are storage area in your class
        // these are treated as variables
        // these may be public, private, public readonly

        private string _Title;
        private double _Years;

        // Properties
        // These are acess techniques to retrieve or set data in 
        // your class without directly touching the storage data field

        // Fully-implemented property
        // a) a declared storage data (data field)
        // b) a declared property signature
        // c) a coded get "method"
        // d) an optional coded set "method"

        // When: 
        // a) if you're storing the associate data in an explicitly declared data field
        // b) if you're during validation access incoming data
        // c) creating a property that generates output from other data sources
        // within the class (readonly property); this property only get a method

        public string Title
        {
            get
            {
                // Accessor
                // The get "method" will return the contents of a data field(s) as an expression

                return _Title;
            }
            set
            {
                // Mutators
                // The set "method" recieves an incoming value and places it in the associated data field
                // during the setting, you might wish to validate the incoming data
                // during the setting, you might wish do some type of logical processing
                // using the data to set another field
                // The incoming piece of data is referred to using the keyword "value"

                // Ensure that the incoming data is not null or empty or whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                // data is considered valid
                _Title = value;
            }
        }

        // Auto-implemented property
        // These properties differ only in syntax
        // Each property is responsible for a single piece of data
        // These properties do NOT reference a declared private data memver
        // The system generates an internal storage area of the return data type
        // The system manages the internal storage for the accessor and mutator
        // there is NO additional logic applied to the data value

        // Using an enum for this field wiill AUTOMATICALLY restricts the values
        // this property can contain
        public SupervisoryLevel Level { get; set; }


        // This property Years could be coded as either a fully implemented property
        // or as an auto-implemented property

        public double Years
        {
            get { return _Years; }
            set 
            { 
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentNullException("Year cannot be a negative value");
                }
                _Years = value; 
            }
        }


        // Constructors
        // is to initialize the physical object (instance) during its creation
        // the result of creation is ensure that the coder gets an instance in 
        // a known state
        // if ypur class definition has NO constructor coded, then the data members /
        // auto implemented properties are set to the C# default data type value
        
        // You can code one or more constructors in your class definition
        // IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL
        // CONSTRUCTORS USED BY THE CLASS!

        // Generally, if you are going to code your own constructor(s) you code two types
        // Default: this constructor does NOT take in any parameters (it mimics the default system)
        // Greedy: this constructor has list of parameters, one for each property, declare
        //          for incoming data

        // Syntax: accesstype classname([list of parameters]) { constructor code body}

        // IMPORTANT: The constructor DOES NOT have a return datatype
        // You DO NOT call a constructor directly, called using the new operator

        // Default Constructor
        public Employment()
        {
            // constructor body
            // a) empty
            // b) you COULD assign literal value to your properties with this constructor
            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        // Greedy Constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            // constructor body
            // a) a parameter for each property
            // b) you COULD do validation within the constructor instead of the property
            // c) validation for public readonly data members
            //    validation for a property with a private set
            Title = title;
            Level = level;
            Years = years;
        }
        // Behaviours (aka methods)
        // Behaviours are no different than methods elsewhere

        //Syntax: accesstype [static] returndatatype BehaviourName ([list of parameters])
        // { code body}

        // there maybe times you wish to obtain all the data in your instance
        // all at once for display
        // generally to accomplish this, your class overrides the .ToString() method

        public override string ToString()
        {
            // comma seperate value string (csv)
            return $"{Title},{Level},{Years}";
        }

        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            // you could do validation within this method to ensure acceptable value
            if (level < 0)
                throw new Exception("Responsibility Level must be positive.");
            Level = level;
        }
    }
}

