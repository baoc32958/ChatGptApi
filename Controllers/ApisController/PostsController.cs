using ChatGptApi.Models;
using ChatGptApi.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ChatGptApi.Controllers.ApisController
{
    [RoutePrefix("api/posts")]
    public class PostsController : ApiController
    {
        /// <summary>
        /// create post cuongtruyen.com
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ResponseType(typeof(Detail))]
        [Route("create")]
        public async Task CreateAsync(Detail detail)
        {
            // Thông tin xác thực REST API
            string apiUsername = "thanhnguyen_@";
            string apiPassword = "by4RvdF%SoOk(G5a3nv6IirH";
            string apiAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiUsername}:{apiPassword}"));

            // Khởi tạo client và thiết lập tiêu đề Authorization
            using (var httpClient = new HttpClient())
            {
                var apiEndpoint = "https://cuongtruyen.com/wp-json/wp/v2/posts";
                httpClient.BaseAddress = new Uri(apiEndpoint);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", apiAuth);

                // Thiết lập thông tin bài viết
                var postTitle = detail.title;
                var postContent = detail.content;
                Random rd = new Random();
                var postAuthor = rd.Next(4, 6).ToString(); // ID của tác giả
                var postStatus = "draft";
                var postDescription = detail.description;
                // Thiết lập thông tin bài viết
                var postData = new
                {
                    title = postTitle,
                    content = postContent,
                    author = postAuthor,
                    status = postStatus,
                    description = postDescription
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
                var postContentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response_ = await httpClient.PostAsync("", postContentJson);

                // Kiểm tra kết quả yêu cầu POST
                if (response_.IsSuccessStatusCode)
                {
                    using (DetailService service = new DetailService())
                    {
                        service.UpdateDone(detail);
                    }
                }
                else
                {
                    throw new Exception("Không tạo được bài viết");
                }
            }
        }
    }
}
