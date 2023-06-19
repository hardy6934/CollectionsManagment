using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.DataTransferObjects
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
    }
}
