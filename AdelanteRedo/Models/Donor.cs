//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdelanteRedo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class Donor
    {
        public int DonorID { get; set; }
        [Display(Name = "First Name")]

        public string Donor_FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string Donor_LastName { get; set; }
        [Display(Name = "Address")]

        public string Donor_Address { get; set; }
        [Display(Name = "City")]

        public string Donor_City { get; set; }
        [Display(Name = "State")]

        public string Donor_State { get; set; }
        [Display(Name = "Zip Code")]

        public string Donor_Zip { get; set; }
        [Display(Name = "Home Telephone")]

        public string Donor_HomeTele { get; set; }
        [Display(Name = "Cellphone")]

        public string Donor_CellPhone { get; set; }
        [Display(Name = "Email")]

        public string Donor_Email { get; set; }
    }
}
