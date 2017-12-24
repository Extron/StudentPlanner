using System;
using System.Runtime.Serialization;

namespace StudentPlanner.DataModel
{
    [DataContract]
    public class Teacher
    {
        /// <summary>
        /// The teacher's first name.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// The teacher's last name.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// The teacher's prefix.
        /// </summary>
        [DataMember]
        public string Prefix { get; set; }
    }
}
