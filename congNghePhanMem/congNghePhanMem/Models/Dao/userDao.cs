using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList; 

namespace congNghePhanMem.Models.Dao
{
    public class userDao
    {
        dbContext db = null;

        public userDao()
        {
            db = new dbContext();
        }
        
        //insert
        public int Insert(register entity)
        {
            db.registers.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        //lay danh sach
        public IEnumerable<register> listAllPaging(int page ,int pageSize)
        {
            var obj = db.registers.OrderBy(x => x.userName).ToPagedList(page, pageSize);
            return obj;
        }

        //lay ra id
        public register getById(string userName)
        {
            return db.registers.SingleOrDefault(x => x.userName == userName);
        }

        //
        public register viewDetail(int id)
        {
            return db.registers.Find(id);
        }

        //login he thong
        public int Login(string userName,string passWord)
        {
            var result = db.registers.SingleOrDefault(x => x.userName == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.status == false)
                {
                    return -1;
                }
                else
                {
                    //cai nay la e ma hoa pass word
                    //tu tu de e thu cai nay e n co login dc k
                    //khong dc r =))
                    if(result.passWord == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        //update
        public bool update(register ennity)
        {
            try
            {
                var user = db.registers.Find(ennity.Id);
                user.name = ennity.name;
                user.userName = ennity.userName;
                user.email = ennity.email;
                if(!string.IsNullOrEmpty(ennity.passWord))
                {
                    user.passWord = ennity.passWord;
                }
                user.phone = ennity.phone;
                user.address = ennity.address;
                user.permision = ennity.permision;
                user.status = ennity.status;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        //delete
        public bool Delete(int id)
        {
            try
            {
                var user = db.registers.Find(id);
                db.registers.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;   
            }
        }
    }
}