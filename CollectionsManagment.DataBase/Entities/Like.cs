﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.DataBase.Entities
{
    public class Like : IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get;set;}
        public User User { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
