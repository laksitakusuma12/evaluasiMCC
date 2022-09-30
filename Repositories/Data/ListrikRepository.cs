using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Household.Context;
using Household.Models;
using Household.Models.ViewModels;
using Household.Repositories.Interface;
using Org.BouncyCastle.Crypto.Generators;

namespace Household.Repositories.Data
{
    public class ListrikRepository : IListrikRepository
    {
        MyContext myContext;

        public ListrikRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Listriks.Find(id);
            myContext.Listriks.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<ListrikViewModel> Get()
        {
            var data = myContext.Listriks.Select(x => new ListrikViewModel
            {
                Id = x.Id,
                Nama = x.Nama,
                Biaya = x.Biaya,
                Token = x.Token
            }).ToList();

            return data;
        }

        public ListrikViewModel Get(int id)
        {
            var data = myContext.Listriks.Where(x => x.Id == id).Select(x => new ListrikViewModel
            {
                Id = x.Id,
                Nama = x.Nama,
                Biaya = x.Biaya,
                Token = x.Token
            }).FirstOrDefault();
            return data;
        }

        public int Post(ListrikViewModel listrik)
        {
            myContext.Listriks.Add(new Models.Listrik
            {
                Id = listrik.Id,
                Nama = listrik.Nama,
                Biaya = listrik.Biaya,
                Token = listrik.Token
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, ListrikViewModel listrik)
        {
            var data = myContext.Listriks.Find(id);
            data.Nama = listrik.Nama;
            data.Biaya = listrik.Biaya;
            data.Token = listrik.Token;
            myContext.Listriks.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

    }
}
