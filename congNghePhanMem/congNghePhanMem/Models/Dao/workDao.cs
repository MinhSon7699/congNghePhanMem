using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace congNghePhanMem.Models.Dao
{
    public class workDao
    {
        dbContext db = null;

        public workDao()
        {
            db = new dbContext();
        }

        //insert
        public int Insert(work entity)
        {
            db.works.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        //lay danh sach
        public IEnumerable<work> listAllPaging(int page, int pageSize)
        {
            var obj = db.works.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            return obj;
        }

        //lay ra id
        public work getById(int  id)
        {
            return db.works.SingleOrDefault(x => x.Id == id);
        }

        //
        public work viewDetail(int id)
        {
            return db.works.Find(id);
        }

        //update
        public bool update(work ennity)
        {
            try
            {
                var user = db.works.Find(ennity.Id);
                user.Id = ennity.Id;
                user.dateWork = ennity.dateWork;
                user.dateOut = ennity.dateOut;
                user.nameEmployee = ennity.nameEmployee;
                user.position = ennity.position;
                user.department = ennity.department;
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
                var user = db.works.Find(id);
                db.works.Remove(user);
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