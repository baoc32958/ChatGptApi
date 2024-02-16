using ChatGptApi.Models;
using Npgsql;
using OpeInformation.Services.Implementations;
using System.Collections.Generic;

namespace ChatGptApi.Services
{
    public class ListService : EntityService
    {
        public IEnumerable<List> GetListByPId(decimal id)
        {
            string sql = @"
                            SELECT
	                            id,
	                            pid,
	                            title,
	                            content,
	                            done
                            FROM
	                            public.list
                            WHERE
	                            pid = :pid ORDER BY id;
                        ";
            return FromSqlRaw<List>(sql, new NpgsqlParameter("pid", id));
        }
        public void Create(List<List> lists)
        {
            List<NpgsqlParameter> npgsqlParameters = null;
            //
            string sql = @"
                            INSERT INTO
								public.list(
									pid,
									title,
									content,
									done
								)
							VALUES
								(
									:pid,
									:title,
									:content,
									:done
								);
                        ";
            foreach (var list in lists)
            {
                npgsqlParameters = new List<NpgsqlParameter>();
                npgsqlParameters.Add(new NpgsqlParameter("pid", list.pid));
                npgsqlParameters.Add(new NpgsqlParameter("title", list.title));
                npgsqlParameters.Add(new NpgsqlParameter("content", list.content));
                npgsqlParameters.Add(new NpgsqlParameter("done", list.done));
                //
                FromSqlRawNonQuery(sql, npgsqlParameters.ToArray());
            }
        }

        public void Update(List list)
        {
            List<NpgsqlParameter> npgsqlParameters = null;
            //
            string sql = @"
                            UPDATE
	                            public.list
                            SET
	                            title = :title,
	                            content = :content,
	                            done = :done
                            WHERE
	                            id = :id;
                        ";
            npgsqlParameters = new List<NpgsqlParameter>();
            npgsqlParameters.Add(new NpgsqlParameter("id", list.id));
            npgsqlParameters.Add(new NpgsqlParameter("title", list.title));
            npgsqlParameters.Add(new NpgsqlParameter("content", list.content));
            npgsqlParameters.Add(new NpgsqlParameter("done", list.done));
            //
            FromSqlRawNonQuery(sql, npgsqlParameters.ToArray());
        }
        public void Delete(List list)
        {
            string sql = @"
                            DELETE FROM public.list
                        	WHERE id=:id;
                            DELETE FROM public.list
                        	WHERE pid=:id;
                            DELETE FROM public.detail
                        	WHERE id=:id;
                        ";
            //
            FromSqlRawNonQuery(sql, new NpgsqlParameter("id", list.id));
        }
    }
}