using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMaker.Interfaces
{
    public interface IUser
    {
        int SignUp(string email, string username, string password);
    }
}
