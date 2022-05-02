using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Lib
{
    public enum MenuStates:byte
    {
        BooksAll=1,
        BooksId,
        BooksAdd,
        BooksEdit,
        BooksRemove,

        AuthorAll,
        AuthorById,
        AuthorAdd,
        AuthorEdit,
        Authorremove,
        Save,
        Exit


    }
}
