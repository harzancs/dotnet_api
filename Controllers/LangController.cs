using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LangController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<String>> GetLang()
    {
        var lang = new List<String>();
        lang.Add("C");
        lang.Add("C#");
        lang.Add("JAVA");
        lang.Add("PYTHON");
        lang.Add("HTML");
        lang.Add("PHP");
        lang.Add("Flutter");
        return Ok(lang); //Ok() => status code
    }

    [HttpGet("{name}")] // ..../1
    public ActionResult GetLangByName(String name)
    {
        return Ok(new { langName = name, id = "1" });
    }

    [HttpGet("search/{name}")] // ..../search/1
    public ActionResult GetSearchLangByName(String name)
    {
        return Ok(new { langName = name, id = "1" });
    }

    [HttpGet("query/")] // ..../?name=JAVA&id=1
    public ActionResult QueryLangByName([FromQuery] String name, [FromQuery] String id)
    {
        return Ok(new { langName = name, id = id });
    }

}
