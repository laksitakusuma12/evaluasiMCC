using Household.Context;
using Household.Models;
using Household.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Repositories.Data
{
    public class AirRepository
    {
        MyContext myContext;

        public AirRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Airs.Find(id);
            myContext.Airs.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<AirViewModel> Get()
        {
            var data = myContext.Airs.Select(x => new AirViewModel
            {
                Id = x.Id,
                Nama = x.Nama,
                Biaya = x.Biaya,
                Token = x.Token
            }).ToList();

            return data;
        }

        public AirViewModel Get(int id)
        {
            var data = myContext.Airs.Where(x => x.Id == id).Select(x => new AirViewModel
            {
                Id = x.Id,
                Nama = x.Nama,
                Biaya = x.Biaya,
                Token = x.Token
            }).FirstOrDefault();
            return data;
        }

        public int Post(AirViewModel air)
        {
            myContext.Airs.Add(new Models.Air
            {
                Id = air.Id,
                Nama = air.Nama,
                Biaya = air.Biaya,
                Token = air.Token
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, AirViewModel air)
        {
            var data = myContext.Airs.Find(id);
            data.Nama = air.Nama;
            data.Biaya = air.Biaya;
            data.Token = air.Token;
            myContext.Airs.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
