using System;
using System.Runtime.Serialization;

namespace StudentPlanner.DataModel
{
    [DataContract]
    public class Assignment
    {
        /// <summary>
        /// The name of the assignment.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The description of the assignment.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// The date that the assignment is due.
        /// </summary>
        [DataMember]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The <see cref="Guid"/> of the assignment.
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }
    }
}
