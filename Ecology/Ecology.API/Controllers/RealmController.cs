using System.Linq;
using AutoMapper;
using Ecology.API.Models;
using Ecology.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealmController : ControllerBase
    {
        private readonly IRealmService realmService;
        private readonly IMapper mapper;

        public RealmController(IRealmService realmService, IMapper mapper)
        {
            this.realmService = realmService;
            this.mapper = mapper;
        }

        // GET: api/Realm
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<RealmViewModel> realms = this.mapper.ProjectTo<RealmViewModel>(this.realmService.GetRealms());

            return this.Ok(realms);
        }
    }
}
