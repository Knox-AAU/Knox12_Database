using System.Linq;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WordCount.Data;
using WordCount.JsonModels;
using WordCount.Models;

namespace WordCount.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchemaController: ControllerBase
    {
        
        /// <summary>
        /// Method for posting a JSON schema to the database which can then be used later for validation of input.
        /// </summary>
        /// <param name="jsonInput">
        /// A JSON element consisting of the keys "schemaName" and "schemaBody". <br/>
        /// The value of key "schemaName" is the primary key for the given schema. <br/>
        /// The value of key "schemaBody" is the schema itself.
        /// </param>
        [HttpPost]
        [Route("/[controller]")]
        public IActionResult PostJsonSchema([FromBody] JsonElement jsonInput)
        {
            WordCountDbContext dbContext = new();
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            string jsonString = jsonInput.GetRawText();
            JsonSchemaDataModel schemaData = JsonSerializer.Deserialize<JsonSchemaDataModel>(jsonString, options);

            if (schemaData == null)
            {
                // 400 Unprocessable entity 
                return new ObjectResult("Wrong body syntax, does not follow schema") {StatusCode = 400};
            }
            
            JsonSchemaModel model = new()
            {
                SchemaName = schemaData.SchemaName,
                JsonString = schemaData.SchemaBody.GetRawText()
            };

            if (dbContext.JsonSchemas.Find(model.SchemaName) != null)
            {
                // 403 forbidden
                return new ObjectResult("Duplicate value") {StatusCode = 403};
            }
            
            dbContext.JsonSchemas.Add(model);                
            dbContext.SaveChanges();
    
            // status 200 OK
            return new ObjectResult("Ok") {StatusCode = 200};
        }

    }
}