using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace CusMng.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public 客戶聯絡人 FindById(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public void Update(客戶聯絡人 UpdData)
        {
            this.UnitOfWork.Context.Entry(UpdData).State = EntityState.Modified;
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}