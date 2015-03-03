using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Serializable]
    public class UserRight
    {
        public int UserID { get; set; }
        public RightEnum Right { get; set; }
    }
}
