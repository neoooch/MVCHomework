using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace CusMng.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => !p.是否已刪除);
        }

        public IQueryable<客戶資料> All(bool ShowAll)
        {
            if (ShowAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public IQueryable<客戶資料> FindByAll(bool ShowAll =false,int ShowCnt =0,string kWord = "")
        {
            var all = All(ShowAll);
            var data = all;
            if (!String.IsNullOrEmpty(kWord))
            {
                data = data.Where(c => c.客戶名稱.Contains(kWord));
            }
            data = data.OrderByDescending(p => p.Id);
            if (ShowCnt > 0)
            {
                return data.Take(ShowCnt);
            }
            return data;
        }

        public 客戶資料 FindById(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public void Update(客戶資料 UpdData)
        {
            this.UnitOfWork.Context.Entry(UpdData).State = EntityState.Modified;
        }

        public override void Delete(客戶資料 entity)
        {
            entity.是否已刪除 = true;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}