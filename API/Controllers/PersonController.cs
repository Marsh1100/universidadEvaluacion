using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PersonController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var result = await _unitOfWork.People.GetAllAsync();
        return _mapper.Map<List<PersonDto>>(result);
    }
    
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonDto>>> GetPagination([FromQuery] Params p)
    {
        var (totalRegistros, registros) = await _unitOfWork.People.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultDto = _mapper.Map<List<PersonDto>>(registros);
        return  new Pager<PersonDto>(resultDto,totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }



    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post([FromBody] PersonDto dto)
    {
        var result = _mapper.Map<Person>(dto);
        this._unitOfWork.People.Add(result);
        await _unitOfWork.SaveAsync();

        if(result == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<Person>> put(PersonDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Person>(dto);
        this._unitOfWork.People.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());


        return result;
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.People.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.People.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }
    //----------------- Endpoint 17 ------------------------
    //Devuelve el número total de **alumnas** que hay.
    [HttpGet("womanStudents")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetWomanStudents()
    {
        var result = await _unitOfWork.People.GetWomanStudents();
        return Ok(result);
    }
    //----------------- Endpoint 18 ------------------------
    // Calcula cuántos alumnos nacieron en `1999`.
    [HttpGet("studentsBirthday1999")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetSbirthday1999()
    {
        var result = await _unitOfWork.People.GetSbirthday1999();
        return Ok(result);
    }
    //----------------- Endpoint 26 ------------------------
    //Devuelve todos los datos del alumno más joven.
    [HttpGet("youngestStudent")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonAllDto>>> GetYoungestStudent()
    {
        var result = await _unitOfWork.People.GetYoungestStudent();
        return _mapper.Map<List<PersonAllDto>>(result);
    }

    //----------------- Endpoint 27 ------------------------
    //Devuelve un listado con los profesores que no están asociados a un departamento
    [HttpGet("teachersWithoutDepartment")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTeachersWithoutDepartment()
    {
        var result = await _unitOfWork.People.GetTeachersWithoutDepartment();
        return Ok(result);
    }

    //---------------------- Endpoint 29 ---------------------------
    //Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.
    [HttpGet("teachersWithOutSubject")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTeachersWithOutSubject()
    {
        var result = await _unitOfWork.People.GetTeachersWithOutSubject();
        return Ok(result);
    }
}