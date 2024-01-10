using ChatGptApi.Models;
using ChatGptApi.Services;
using System.Web.Http;
using System.Web.Http.Description;

namespace ChatGptApi.Controllers.ApisController
{
    [RoutePrefix("api/detail")]
    public class DetailController : ApiController
    {
        /// <summary>
        /// Get detail
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ResponseType(typeof(Detail))]
        [Route("Get")]
        public IHttpActionResult Get([FromUri] List list)
        {
            Detail detail = null;
            using (DetailService service = new DetailService())
            {
                detail = service.Get(list);
            }
            //
            return Ok(detail);
        }
        /// <summary>
        /// Create detail
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ResponseType(typeof(Detail))]
        [Route("Create")]
        public IHttpActionResult Create([FromBody] Detail detail)
        {
            using (DetailService service = new DetailService())
            {
                service.Create(detail);
            }
            //
            return Ok(detail);
        }
        /// <summary>
        /// Update detail
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ResponseType(typeof(Detail))]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] Detail detail)
        {
            using (DetailService service = new DetailService())
            {
                service.Update(detail);
            }
            //
            return Ok(detail);
        }
    }
}
