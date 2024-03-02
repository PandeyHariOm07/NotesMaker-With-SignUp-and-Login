using NotesMaker.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMaker
{
       public class UserAuthentication : IUser {
            private SqlConnection _conObj = null;
            private SqlDataAdapter _adapter = null;
            public int SignUp(string email, string username, string password)
            {
                using(_conObj = new SqlConnection(SqlConnectionStrings.GetConnectionString()))
                {
                    using(_adapter = new SqlDataAdapter("select * from users", _conObj))
                    {
                       using(DataTable dt = new DataTable())
                        {
                            _adapter.Fill(dt);
                            SqlCommandBuilder builder = new SqlCommandBuilder(_adapter);
                            _adapter.InsertCommand = builder.GetInsertCommand();
                            DataRow dataRow = dt.NewRow();
                            dataRow[0] = email;
                            dataRow[1] = username;
                            dataRow[2] = password;
                            dt.Rows.Add(dataRow);
                            return _adapter.Update(dt)>0?1:0;
                        }
                    }
                }
            }

            public List<string> LoginUser(string email, string password)
        {
            List<string> result = new List<string>();
           using(_conObj = new SqlConnection(SqlConnectionStrings.GetConnectionString()))
            {
                using(SqlCommand cmdObj = new SqlCommand("select * from users where @id = email_id and @pass = password", _conObj))
                {
                    cmdObj.Parameters.AddWithValue("@id", email);
                    cmdObj.Parameters.AddWithValue("@pass", password);
                    _conObj.Open();
                    SqlDataReader reader = cmdObj.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                    return result;
                }
            }
        }
        }
}
