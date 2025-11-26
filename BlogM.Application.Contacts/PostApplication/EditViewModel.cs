using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogM.Application.Contacts.PostApplication
{
    public class EditViewModel:CreateViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
