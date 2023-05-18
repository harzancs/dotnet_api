using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public partial class LangController : ControllerBase
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

    [HttpPost]
    public ActionResult<LangModel> AddLang([FromBody] LangModel item)
    {
        return Ok(item);
    }

    [HttpPost("addLang/")]
    public ActionResult<LangModel> AddLangForm([FromForm] LangModel item)
    {
        return Ok(item);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateLang(int id, [FromBody] LangModel item)
    {

        if (id != item.id)
        {
            return BadRequest(); // 400

        }
        if (id != 10)
        {
            return NotFound(); //404
        }
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteById(int id)
    {
        if (id != 10)
        {
            return NotFound();
        }
        return NoContent();
    }
}
