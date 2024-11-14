﻿using EcoLife.HouseHoldApi.Models;
using EcoLife.HouseHoldApi.Models.Dto;
using EcoLife.HouseHoldApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoLife.HouseHoldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseHoldController : ControllerBase
    {
        private readonly IHouseHoldRepository _houseHoldRepository;

        public HouseHoldController(IHouseHoldRepository houseHoldRepository)
        {
            _houseHoldRepository = houseHoldRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<HouseHoldEntity>>> GetAll()
        {
            var entities = await _houseHoldRepository.GetHouseHoldEntities();
            return Ok(entities);
        }


        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<HouseHoldEntity>>> GetById(int userid)
        {
            var entities = await _houseHoldRepository.GetHouseHoldEntityById(userid);
            return Ok(entities);
        }


        [HttpPost]
        public async Task<ActionResult<HouseHoldEntity>> PostEntity([FromForm]HouseHoldDto entity)
        {
            if (entity != null)
            {
                var ent = await _houseHoldRepository.PostHouseHoldEntity(entity);
                return Ok(ent);
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<HouseHoldEntity>> PutEntity(int id,[FromForm] HouseHoldDto entity)
        {

            var ent = await _houseHoldRepository.PutHouseHoldEntity(id, entity);
            if (ent != null)
                return Ok(ent);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEntity(int id)
        {

            var ent = await _houseHoldRepository.DeleteHouseHoldEntity(id);
            if (ent == true)
                return Ok(new
                {
                    message = "Record Deleted"
                });
            return BadRequest();
        }

    }
}