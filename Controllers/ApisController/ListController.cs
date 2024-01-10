using ChatGptApi.Models;
using ChatGptApi.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ChatGptApi.Controllers.ApisController
{
    [RoutePrefix("api/list")]
    public class ListController : ApiController
    {
        /// <summary>
        /// Get list
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<List>))]
        [Route("GetList")]
        public IHttpActionResult GetList([FromUri] decimal id)
        {
            IEnumerable<List> lists = null;
            using (ListService service = new ListService())
            {
                lists = service.GetListByPId(id);
            }
            //
            return Ok(lists);
        }
        /// <summary>
        /// create List
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ResponseType(typeof(IEnumerable<List>))]
        [Route("Create")]
        public IHttpActionResult Create([FromBody] List<List> lists)
        {
            using (ListService service = new ListService())
            {
                service.Create(lists);
            }
            //
            return Ok(lists);
        }
        /// <summary>
        /// delete List
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ResponseType(typeof(List))]
        [Route("Delete")]
        public IHttpActionResult Delete([FromBody] List list)
        {
            using (ListService service = new ListService())
            {
                service.Delete(list);
            }
            //
            return Ok(list);
        }
    }
}
