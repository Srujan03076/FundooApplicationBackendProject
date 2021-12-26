using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
   public class UserRegistration
    {
        /// <summary>
        /// /// Gets or sets the object named Id of the UserRegistration class
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// /// Gets or sets the object named Firstname of the UserRegistration class
        /// </summary>
        /// 
        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        /// <summary>
        /// /// Gets or sets the object named Lastname of the UserRegistration class
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        /// <summary>
        /// /// Gets or sets the object named EmailId of the UserRegistration class
        /// </summary>
        [Required(ErrorMessage = "EmailId is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmaiId:")]

        public string EmailId { get; set; }

        /// <summary>
        /// /// Gets or sets the object named Password of the UserRegistration class
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password contain six Character")]
        public string Password { get; set; }

    }
}
