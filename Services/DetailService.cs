using ChatGptApi.Models;
using Npgsql;
using OpeInformation.Services.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace ChatGptApi.Services
{
    public class DetailService : EntityService
    {
        public Detail Get(List list)
        {
            string sql = @"
                            SELECT
	                            id,
	                            title,
	                            content,
	                            link,
	                            description,
	                            key,
	                            cover_image,
	                            done
                            FROM
	                            public.detail
                            WHERE
	                            id = :id;
                        ";
            //
            return FromSqlRaw<Detail>(sql, new NpgsqlParameter("id", list.id)).FirstOrDefault();
        }
        public void Create(Detail detail)
        {
            List<NpgsqlParameter> npgsqlParameters = null;
            //
            string sql = @"
                            INSERT INTO
								public.detail(
	                                id,
									title,
									content,
									link,
									description,
									key,
									cover_image,
									done
								)
							VALUES
								(
	                                :id,
									:title,
									:content,
									:link,
									:description,
									:key,
									:cover_image,
									:done
								);
                        ";
            npgsqlParameters = new List<NpgsqlParameter>();
            npgsqlParameters.Add(new NpgsqlParameter("id", detail.id));
            npgsqlParameters.Add(new NpgsqlParameter("title", detail.title));
            npgsqlParameters.Add(new NpgsqlParameter("content", detail.content));
            npgsqlParameters.Add(new NpgsqlParameter("link", detail.link));
            npgsqlParameters.Add(new NpgsqlParameter("description", detail.description));
            npgsqlParameters.Add(new NpgsqlParameter("key", detail.key));
            npgsqlParameters.Add(new NpgsqlParameter("cover_image", detail.cover_image));
            npgsqlParameters.Add(new NpgsqlParameter("done", detail.done));
            //
            FromSqlRawNonQuery(sql, npgsqlParameters.ToArray());
        }

        public void Update(Detail detail)
        {
            List<NpgsqlParameter> npgsqlParameters = null;
            //
            string sql = @"
                            UPDATE
	                            public.detail
                            SET
	                            title = :title,
	                            content = :content,
	                            link = :link,
	                            description = :description,
	                            key = :key,
	                            cover_image = :cover_image,
	                            done = :done
                            WHERE
	                            id = :id;
                        ";
            npgsqlParameters = new List<NpgsqlParameter>();
            npgsqlParameters.Add(new NpgsqlParameter("id", detail.id));
            npgsqlParameters.Add(new NpgsqlParameter("title", detail.title));
            npgsqlParameters.Add(new NpgsqlParameter("content", detail.content));
            npgsqlParameters.Add(new NpgsqlParameter("link", detail.link));
            npgsqlParameters.Add(new NpgsqlParameter("description", detail.description));
            npgsqlParameters.Add(new NpgsqlParameter("key", detail.key));
            npgsqlParameters.Add(new NpgsqlParameter("cover_image", detail.cover_image));
            npgsqlParameters.Add(new NpgsqlParameter("done", detail.done));
            //
            FromSqlRawNonQuery(sql, npgsqlParameters.ToArray());
        }

        public void UpdateDone(Detail detail)
        {
            List<NpgsqlParameter> npgsqlParameters = null;
            //
            string sql = @"
                            UPDATE
	                            public.detail
                            SET
	                            done = :done
                            WHERE
	                            id = :id;
                            UPDATE
	                            public.list
                            SET
	                            done = :done
                            WHERE
	                            id = :id;
                        ";
            npgsqlParameters = new List<NpgsqlParameter>();
            npgsqlParameters.Add(new NpgsqlParameter("id", detail.id));
            npgsqlParameters.Add(new NpgsqlParameter("done", 1));
            //
            FromSqlRawNonQuery(sql, npgsqlParameters.ToArray());
        }
    }
}