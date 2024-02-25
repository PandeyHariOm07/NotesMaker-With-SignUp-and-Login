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
        }
}
