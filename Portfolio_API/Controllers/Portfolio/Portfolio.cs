using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Services.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [ApiController]
    [Route("api/[controller]")]
    public class Portfolio : ControllerBase
    {
        private readonly IPortfolioExperienceService _expService;
        private readonly IPortfolioTechStackService _techStackService;
    }
}