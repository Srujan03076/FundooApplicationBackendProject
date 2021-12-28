using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ResponseModel
{
    /// <summary>
    /// This is a LoginResponse class
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Gets or sets the Firstname
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the Lirstname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        public string EmailId { get; set; }
        /// <summary>
        /// Gets or sets the Createat and make it nullable
        /// </summary>
        public DateTime? Createat { get; set; }
        /// <summary>
        /// Gets or sets the Modifiedeat and make it nullable
        /// </summary>
        public DateTime? Modifiedat { get; set; }
        /// <summary>
        /// Gets or sets the token
        /// </summary>
        public string  token { get; set; }

    }
}
