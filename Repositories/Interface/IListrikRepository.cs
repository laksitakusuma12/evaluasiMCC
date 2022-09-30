using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Household.Models.ViewModels;

namespace Household.Repositories.Interface
{
    interface IListrikRepository
    {
        List<ListrikViewModel> Get();
        ListrikViewModel Get(int id);
        int Post(ListrikViewModel listrikViewModel);
        int Put(int id, ListrikViewModel listrikViewModel);
        int Delete(int id);
    }
}
