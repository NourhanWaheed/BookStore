using StoreData.Data;
using StoreData.Interfaces;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repositories
{
    public class BookRepository : EntityBaseRepository<Book>, IBook
    {
        public BookRepository(StoreContext context, DapperContext dappercontext) : base(context, dappercontext)
        {
        }
    }
}
