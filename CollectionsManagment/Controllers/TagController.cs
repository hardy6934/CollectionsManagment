using AutoMapper;
using CollectionsManagment.Buisness.Services;
using CollectionsManagment.Core.Abstractrions;
using CollectionsManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagment.Controllers
{
    public class TagController : Controller
    {
        private readonly IMapper mapper; 

        public TagController(IMapper mapper )
        {
            this.mapper = mapper; 
        }
        //public async Task<IActionResult> GetTagsAsync()
        //{ 

        //}
    }
}
