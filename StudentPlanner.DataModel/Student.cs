using System;
using System.Runtime.Serialization;

namespace StudentPlanner.DataModel
{
    [DataContract]
    public class Student
    {
        /// <summary>
        /// The first name of the student.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the student.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// The unique <see cref="Guid"/> of the student.
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }
    }
}
