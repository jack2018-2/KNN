using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp10
{
    public class Classes
    {
        public string Classname;
        public int NumericValue;
        //public int dispersion;

        public Classes(string name, int v)
        {
            Classname = name;
            NumericValue = v;
        }
    }


    public class ClassesComparer : IEqualityComparer<Classes>
    {
        public bool Equals(Classes x, Classes y)
        {
            return x.Classname == y.Classname;
        }

        public int GetHashCode(Classes obj)
        {
            return obj.Classname.GetHashCode();// ^ typedObj.NumericValue.GetHashCode();
        }
    }
}
