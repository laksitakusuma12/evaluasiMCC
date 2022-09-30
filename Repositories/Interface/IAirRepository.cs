using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Household.Models.ViewModels;

namespace Household.Repositories.Interface
{
    interface IAirRepository
    {
        List<AirViewModel> Get();
        AirViewModel Get(int id);
        int Post(AirViewModel airViewModel);
        int Put(int id, AirViewModel airViewModel);
        int Delete(int id);
    }
}
