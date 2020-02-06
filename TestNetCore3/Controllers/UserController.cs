namespace TestNetCore3.Controllers
{
    //Librerias que utiliza la clase ->
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TestNetCore3.Models.Request;
    using TestNetCore3.Services.Contracts;

    /// <summary>
    /// Clase que modela el controller User, tienes los metodos necesarios para el get y CRUD.
    /// </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Atributos

        private readonly IUserService _IUserService;

        #endregion

        #region Constructor

        public UserController(IUserService userService) => _IUserService = userService;

        #endregion

        #region Get

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _IUserService.GetAll();
                return Ok(list);
            }
            catch (Exception) { return BadRequest(); }
        }

        #endregion

        #region CRUD

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _IUserService.Insert(model);
                    if (id > 0)
                        return Ok(id);
                    else
                        return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Upload(int id, [FromBody] UserRequestEdit model)
        {
            if (id != model.UserId) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    await _IUserService.Upload(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _IUserService.Delete(id);
                return Ok();
            }
            catch (Exception) { return BadRequest(); }
        }

        #endregion

    }//EndClass.
}//EndNamespace.