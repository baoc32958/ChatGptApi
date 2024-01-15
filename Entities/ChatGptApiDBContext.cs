using System.Data.Entity;

namespace ChatGptApi.Entities
{
    public partial class ChatGptApiDBContext : DbContext
    {
        public ChatGptApiDBContext()
            : base("name=DbPgSql")
        {
        }
    }
}
