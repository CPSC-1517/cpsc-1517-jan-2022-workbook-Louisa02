﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Data
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


        // data field
        // are storage area in your class
        // these are treated as variables
        // these may be public, private, public readonly

        private string _Title;
        private double _Years;

        // properties
        // These are acess techniques to retrieve or set data in 
        // your class without directly touching the storage data field

        // fully implemented property
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
                else
                {
                    _Title = value;
                }
            }
        }

        // auto-implemented property
        // These properties differ only in syntax
        // Each property is responsible for a single piece of data
        // These properties do NOT reference a declared private data memver
        // The system generates an internal storage area of the return data typee
        // there is NO additional logic applied to the data value

        public int Level { get; set; }

        // This property Years could be coded as either a fully implemented property
        // or as an auto-implemented property

        public double Years
        {
            get { return _Years; }
            set { _Years = value; }
        }


        // constructors



        // behaviours
    }
}

