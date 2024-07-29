using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class BuggyController(DataContext context) : BaseApiController
{
    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth()
    {
        return "secret text";
    }
    // By testing with {{url}}/api/buggy/auth, it will return 401 Unauthorized

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var thing = context.Users.Find(-1);
        if (thing == null) return NotFound();
        return thing;
    }
    // By testing with {{url}}/api/buggy/not-found, it will return a body includes;
    //{
    //  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
    //  "title": "Not Found",
    //  "status": 404,
    //  "traceId": "00-4e8ed3e8f6c5aa8e36b86d7e78553ed9-3c764d9e19960c2a-00"
    //}

    [HttpGet("server-error")]
    public ActionResult<AppUser> GetServerError()
    {
        var thing = context.Users.Find(-1) ?? throw new Exception("A bad thing has happened");
        return thing;
    }
    // By testing with {{url}}/api/buggy/server-error, exception message will be displayed

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("This was not a good request");
    }
    // By testing with {{url}}/api/buggy/bad-request, it will return a message 'This is not a good request'
}
