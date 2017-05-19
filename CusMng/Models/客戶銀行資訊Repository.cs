using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace CusMng.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public 客戶銀行資訊 FindById(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public void Update(客戶銀行資訊 UpdData)
        {
            this.UnitOfWork.Context.Entry(UpdData).State = EntityState.Modified;
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            entity.是否已刪除 = true;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}