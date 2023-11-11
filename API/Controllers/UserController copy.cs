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
    public  class ConexionBD{
        private string Server   = "localhost";
        private string Port     = "3306";
        private string Db       = "dbuniversity";
        private string User     = "root";
        private string Pass     = "123456";
        private string conectionString() => $"server={Server};port={Port};database={Db};user={User};password={Pass};";
        public  MySqlConnection ConexionMysql(){
            using MySqlConnection connection = new(conectionString());
            try{
                return connection;
            }catch(Exception err){
                Console.WriteLine(err.Message);
                return connection;
            }
        }
    }

    readonly ConexionBD newConexion = new();

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

        MySqlConnection con = newConexion.ConexionMysql();
        try
        {
            con.Open();
            var ejmpo = await _unitOfWork.People.GetAllAsync();
            string sql = $"SELECT * FROM {ejmpo};";
            using MySqlCommand command = new MySqlCommand(sql, con);
            using MySqlDataReader read = command.ExecuteReader();
            Dictionary<int,Producto>? result =new();
            while(read.Read()){
                string nombre = read.GetString("nombre");
                string telefono =  read.GetString("telefono");
                string correo = read.GetString("correo");
                result.Add(read.GetInt32("id_persona"), new Producto(nombre, telefono, correo));
            }
            read.Close();
            return result;
        }catch(Exception err){
            Console.WriteLine(err.Message);
            return null;
        }
        
        
        using MySqlCommand command = new MySqlCommand(sql, con);

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
        /*string strDate= modelPet.Birthdate.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");;
        DateTime.TryParseExact(strDate, "yyyy-MM-ddTHH:mm:ss.ffffffZ", null, DateTimeStyles.None, out DateTime parseDate1); */
      
    
}