using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace congNghePhanMem.Models.Dao
{
    public class employeeDao
    {
        dbContext db = null;

        public employeeDao()
        {
            db = new dbContext();
        }

        //insert
        public int Insert(information entity)
        {
            db.information.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        //lay danh sach
        public IEnumerable<information> listAllPaging(int page, int pageSize)
        {
            var obj = db.information.OrderBy(x => x.name).ToPagedList(page, pageSize);
            return obj;
        }

        //lay ra id
        public information getById(string name)
        {
            return db.information.SingleOrDefault(x => x.name == name);
        }

        //
        public information viewDetail(int id)
        {
            return db.information.Find(id);
        }

        //update
        public bool update(information ennity)
        {
            try
            {
                var user = db.information.Find(ennity.Id);
                user.name = ennity.name;
                user.address = ennity.address;
                user.birthDay = ennity.birthDay;
                user.gender = ennity.gender;
                user.salary = ennity.salary;
                user.block = ennity.block;
                user.IdWork = ennity.IdWork;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.information.Find(id);
                db.information.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}