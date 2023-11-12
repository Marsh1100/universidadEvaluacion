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
    //----------------- Endpoint 1 ------------------------
    // Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.
    [HttpGet("allStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonOnlyNameDto>>> GetAllStudents()
    {
        var result = await _unitOfWork.People.GetAllStudents();
        return _mapper.Map<List<PersonOnlyNameDto>>(result);
    }

    //----------------- Endpoint 2 ------------------------
    // Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.
    [HttpGet("studentsWithoutPhone")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonOnlyNameDto>>> GetStudentsWithoutPhone()
    {
        var result = await _unitOfWork.People.GetStudentsWithoutPhone();
        return _mapper.Map<List<PersonOnlyNameDto>>(result);
    }

    //----------------- Endpoint 3 ------------------------
    //Devuelve el listado de los alumnos que nacieron en `1999`.    
    [HttpGet("Students1999")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonOnlyNameDto>>> GetStudents1999()
    {
        var result = await _unitOfWork.People.GetStudents1999();
        return _mapper.Map<List<PersonOnlyNameDto>>(result);
    }

    //----------------- Endpoint 4 ------------------------
    // Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`
    [HttpGet("TeacherWithoutPhoneK")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonOnlyNameDto>>> GetTeacherWithoutPhoneK()
    {
        var result = await _unitOfWork.People.GetTeacherWithoutPhoneK();
        return _mapper.Map<List<PersonOnlyNameDto>>(result);
    }
    //----------------- Endpoint 6 ------------------------
    //Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)
    [HttpGet("womansGrade")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonAllDto>>> GetWomansGrade()
    {
        var result = await _unitOfWork.People.GetWomansGrade();
        return _mapper.Map<List<PersonAllDto>>(result);
    }

    //----------------- Endpoint 14 ------------------------
    // Devuelve un listado con los profesores que no imparten ninguna asignatura.
    [HttpGet("teachersWithoutSubject")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTeachersWithoutSubject()
    {
        var result = await _unitOfWork.People.GetTeachersWithoutSubject();
        return Ok(result);
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