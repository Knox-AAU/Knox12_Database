using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WordCount.Data;
using WordCount.DataAccess;

namespace WordCount.Controllers
{
    public sealed class WordRatioController : Controller
    {
        [HttpGet]
        [Route("/[controller]/all")]
        public IEnumerable<WordRatios> GetAllWordRatios()
        {
            return new WordCountDbContext().WordRatios.ToList();
        }
        
        [HttpGet]
        [Route("/[controller]/")]
        public IActionResult GetMatches(string[] terms, string[] sources)
        {
            if (terms.Length == 0)
            {
                return BadRequest("No terms given.");
            }
            
            List<WordRatios> set = new WordCountDbContext().WordRatios.ToList();
            IEnumerable<WordRatios> result = set.Where(w => terms.Contains(w.WordName));

            if (sources.Length != 0)
            {
                result = result.Where(r => sources.Contains(r.SourceName));
            }

            result = result.OrderBy(a => a.ArticleTitle);

            return Ok(result);
        }
    }
}