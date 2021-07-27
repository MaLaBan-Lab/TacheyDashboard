using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacheyDashboard.Interface;
using TacheyDashboard.ViewModel.ApiModel;
using TacheyDashboard.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacheyDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly OrderInterface _ordersService;
        public PointController(OrderInterface orderservice)
        {
            _ordersService = orderservice;
        }
        // GET: api/<PointController>
        [HttpGet]
        public ApiResult Get()
        {
            try
            {
                var result = _ordersService.GetPoint();
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }

        // GET api/<PointController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PointController>
        [HttpPost]
        public ApiResult Post([FromBody] Point value)
        {
            try
            {
                var result = _ordersService.CreatePoint(value);
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }

        // PUT api/<PointController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PointController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
