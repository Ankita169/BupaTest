using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Model;

namespace BookStore.Service
{
    public interface  IBookService
    {
         Task< List<Owner>>  GetData();             
    }
}
