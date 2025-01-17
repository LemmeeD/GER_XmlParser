﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GER_XmlParser.entities.wrappers.data
{
    public abstract class MappingPair
    {
        //FIELDS
        protected string _path;
        // PROPERTIES
        public string Path { get { return _path; } }

        // CONTRUCTORS

        // METHODS
        public override string ToString()
        {
            return Path.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (obj is MappingPair)
            {
                MappingPair that = obj as MappingPair;
                return Path.Equals(that.Path);
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }
    }
}
