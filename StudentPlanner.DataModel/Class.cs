using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StudentPlanner.DataModel
{
    [DataContract]
    public class Class
    {
        /// <summary>
        /// The name of the class.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// A list of <see cref="Student"/>s that are enrolled in the class.
        /// </summary>
        public List<Student> EnrolledStudents { get; set; }

        /// <summary>
        /// The <see cref="Teacher"/> of the class.
        /// </summary>
        public Teacher Teacher { get; set; }
    }
}
