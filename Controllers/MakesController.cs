using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using vega.Persistence;
using System.Net.Http;
using System;

namespace vega.Controllers
{
  public class MakesController : Controller
  {
    private readonly VegaDbContext context;
    private readonly IMapper mapper;
    
    public MakesController(VegaDbContext context, IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;
    }

    [HttpGet("/api/makes")]
    public async Task<IEnumerable<MakeResource>> GetMakes()
    {
        var makes = await context.Makes.ToListAsync();

        return mapper.Map<List<Make>, List<MakeResource>>(makes);
    }

    //  [HttpPost("/api/makes")]
    // public async Task<IEnumerable<MakeResource>> CreateMakes(MakeResource makeResource)
    // {
    //     if (!ModelState.IsValid)
    //             return BadRequest();

    //     var make = new Make();
    //     Mapper.Map<MakeResource, Make>(makeResource, make);
    //     this.context.Makes.Add(make);
    //     context.SaveChanges();

    //     makeResource.Id = make.Id;
    //     return Created(new Uri(Request.RequestUri+"/"+ make.Id), make);
    // }
  }
}