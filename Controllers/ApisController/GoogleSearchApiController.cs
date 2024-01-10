using ChatGptApi.Models;
using ChatGptApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ChatGptApi.Controllers.ApisController
{
    [RoutePrefix("api/GoogleSearchApi")]
    public class GoogleSearchApiController : ApiController
    {
        /// <summary>
        /// Get image
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ResponseType(typeof(List<string>))]
        [Route("Get")]
        public async Task<IHttpActionResult> GetAsync([FromUri] string query, string num)
        {
            string googleImages = await GoogleSearchApi.GetGoogleImagesAsync(query, num);
            //
            return Ok(googleImages);
        }
    }
}