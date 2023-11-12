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

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class DepartamentController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartamentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DepartamentDto>>> Get()
    {
        var result = await _unitOfWork.Departaments.GetAllAsync();
        return _mapper.Map<List<DepartamentDto>>(result);
    }
    
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DepartamentDto>>> GetPagination([FromQuery] Params p)
    {
        var (totalRegistros, registros) = await _unitOfWork.Departaments.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultDto = _mapper.Map<List<DepartamentDto>>(registros);
        return  new Pager<DepartamentDto>(resultDto,totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }
    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departament>> Post([FromBody] DepartamentDto dto)
    {
        var result = _mapper.Map<Departament>(dto);
        this._unitOfWork.Departaments.Add(result);
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


    public async Task<ActionResult<Departament>> put(DepartamentDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Departament>(dto);
        this._unitOfWork.Departaments.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());


        return result;
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Departaments.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.Departaments.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }
    //----------------- Endpoint 10 ------------------------
    //Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)
    [HttpGet("departamentsGrade4")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetDepartamentsGrade4()
    {
        var result = await _unitOfWork.Departaments.GetDepartamentsGrade4();
        return Ok(result);
    }

    //----------------- Endpoint 16 ------------------------
    //Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar. El resultado debe mostrar el nombre del departamento y el nombre de la asignatura que no se haya impartido nunca.
    [HttpGet("subjectDepartament")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentSubjectDto>>> GetSubjectDepartament()
    {
        var result = await _unitOfWork.Departaments.GetSubjectDepartament();
        return Ok(_mapper.Map<IEnumerable<DepartamentSubjectDto>>(result));
    }
    [HttpGet("subjectDepartament2")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetSubjectDepartament2()
    {
        var result = await _unitOfWork.Departaments.GetSubjectDepartament2();
        return Ok(result);
    }

    //----------------- Endpoint 19 ------------------------
    //Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento.
    
    [HttpGet("teachersByDepartment")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTeachersByDepartment()
    {
        var result = await _unitOfWork.Departaments.GetTeachersByDepartment();
        return Ok(result);
    }

    //----------------- Endpoint 20 ------------------------
    //Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado.
    
    [HttpGet("teachersByDepartmentAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTeachersByDepartmentAll()
    {
        var result = await _unitOfWork.Departaments.GetTeachersByDepartmentAll();
        return Ok(result);
    }
    //----------------- Endpoint 28 ------------------------
    //Devuelve un listado con los departamentos que no tienen profesores asociados.
    [HttpGet("departamentsWithoutTeachers")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetDepartamentsWithoutTeachers()
    {
        var result = await _unitOfWork.Departaments.GetDepartamentsWithoutTeachers();
        return Ok(result);
    }

    //--------------------- Endpoint 31 ---------------------------
    //Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.
    [HttpGet("departamentsWithoutSubjects")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetDepartamentsWithoutSubjects()
    {
        var result = await _unitOfWork.Departaments.GetDepartamentsWithoutSubjects();
        return Ok(result);
    }

    
    
}