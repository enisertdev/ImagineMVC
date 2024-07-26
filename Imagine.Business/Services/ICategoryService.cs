using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagine.DataAccess.Entities;

namespace Imagine.Business.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> getAllCategories();
    }
}
