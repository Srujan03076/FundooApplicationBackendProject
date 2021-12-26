using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.UserModel
{
    /// <summary>
    /// This is a UserLogin class 
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
