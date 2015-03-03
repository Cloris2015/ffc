using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    [Serializable]
    public class User
    {
        [Display(Name = "User ID")] 
        public int ID { get; set; }
        public User()
        {
        }
        public User(int ID)
        {
            this.ID = ID;
        }
        [Required(ErrorMessage="Name is required")]
        [StringLength(60,MinimumLength=1)]
        [Display(Name="User Name")] 
        public string Name { get; set;}
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$",ErrorMessage="Please use ###-###-#### format" )]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")] 
        public DateTime?BOD { get; set; }
    
    }
   
}
