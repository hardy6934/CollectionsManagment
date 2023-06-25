﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Location { get; set; }
        public string? FilePath { get; set; }

        public int AccountId { get; set; } 
        public string AccountEmail { get; set; }

        public int RoleId { get; set; } 
        public string RoleName { get; set; }
         
        public List<CollectionDTO>? CollectionsDTO { get; set; }
    }
}
