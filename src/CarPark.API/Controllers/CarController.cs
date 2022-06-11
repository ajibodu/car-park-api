using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPark.Application.Car;
using CarPark.Application.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("by-id/{carId:guid}")]
        public async Task<IActionResult> GetByCarId(Guid carId)
        {
            return Ok(await _carService.GetCarById(carId));
        }
        
        [HttpGet("by-plate/{plateNo:string}")]
        public async Task<IActionResult> GetByPlateNo(string plateNo)
        {
            return Ok(await _carService.GetCarByPlateNo(plateNo));
        }
        
        [HttpPost("approaching")]
        public async Task<IActionResult> Approaching(ApproachingCarRequest carRequest)
        {
            return Ok(await _carService.ApproachingCar(carRequest));
        }
        
        [HttpPost]
        public async Task<IActionResult> DriveIn(DriveInRequest driveInRequest)
        {
            await _carService.DriveIn(driveInRequest);
            return Ok();
        }
        
        // [HttpPost]
        // public async Task<IActionResult> DriveOut()
        // {
        //     
        // }
        
    }
}
