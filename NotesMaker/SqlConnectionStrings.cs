using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMaker
{
    public static class SqlConnectionStrings
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["NotesServer"].ConnectionString;
        }
    }
}
