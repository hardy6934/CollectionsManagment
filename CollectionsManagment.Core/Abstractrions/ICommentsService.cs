﻿using CollectionsManagment.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsManagment.Core.Abstractrions
{
    public interface ICommentsService
    {
        Task<int> CreateCommentAsync(CommentDTO dto);
    }
}
