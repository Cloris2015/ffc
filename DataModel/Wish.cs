using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    [Serializable]
    public class Wish
    {
        public int ID { get; private set; }
        public Wish(int ID):this()
        {
            this.ID = ID;
        }
        public Wish()
        {
            this.Date = DateTime.Now;
            this.Status = WishStatusEnum.New;
        }
        public int UserID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage="Item name is required.")]
        [StringLength(100,MinimumLength=1)]
        public string Item { get; set; }
        public string Note { get; set; }
        public WishStatusEnum Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0: yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        [Display(Name="Last Update")]
        public DateTime? LastUpdate { get; set; }
        [Display(Name = "Last Updated By")]
        public int? LastUpdatedBy { get; set; }
    }
}
