using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogTool;
using ScadaBase.DAL.DBContext;
using ScadaBase.DAL.Entity;

namespace ScadaBase.DAL.DAL
{
    public interface IProductFormulaDAL
    {

        List<ProductFormulaEntity> SelectAll();

        List<ProductFormulaEntity> SelectByName(string name);

        List<ProductFormulaEntity> SelectAllByProdCode(string code);

        ProductFormulaEntity SelectSingleByProdCode(string code);


        List<ProductFormulaEntity> SelectByType(string type);


        List<ProductFormulaEntity> SelectByNo(int plcNo);

        ProductFormulaEntity SelectById(int id);

        bool RemoveById(int id);

        bool Update(ProductFormulaEntity entity);

        bool Insert(ProductFormulaEntity entity);
    }

    public class ProductFormulaDAL :IProductFormulaDAL
    {
        public List<ProductFormulaEntity> SelectAll()
        {
            List<ProductFormulaEntity> list = new List<ProductFormulaEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbProductFormula.ToList();
            }
            return list;
        }

        public List<ProductFormulaEntity> SelectAllByProdCode(string code)
        {
            List<ProductFormulaEntity> list = new List<ProductFormulaEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                //TODO 这里使用模糊查询 
                list = db.tbProductFormula.Where(r=>r.ProductCode.Contains(code)).ToList();
            }
            return list;
        }

        public ProductFormulaEntity SelectSingleByProdCode(string code)
        {
            ProductFormulaEntity entity;
            using (MyDbContext db = new MyDbContext())
            {
                //TODO 这里使用模糊查询 
                entity = db.tbProductFormula.FirstOrDefault(r => r.ProductCode==(code));
            }
            return entity;
        }

        public List<ProductFormulaEntity> SelectByName(string name)
        {
            List<ProductFormulaEntity> list = new List<ProductFormulaEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                //TODO 这里使用模糊查询 
                list = db.tbProductFormula.Where(r => r.ProductName.Contains(name)).ToList();
            }
            return list;
        }


        public List<ProductFormulaEntity> SelectByType(string type)
        {
            List<ProductFormulaEntity> list = new List<ProductFormulaEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                //TODO 这里使用模糊查询 
                list = db.tbProductFormula.Where(r => r.ProductType.Contains(type)).ToList();
            }
            return list;
        }

        public List<ProductFormulaEntity> SelectByNo(int plcNo)
        {
            List<ProductFormulaEntity> list = new List<ProductFormulaEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                list = db.tbProductFormula.Where(r => r.ProductPLCNo==plcNo).ToList();
            }
            return list;
        }

        public ProductFormulaEntity SelectById(int id)
        {
          
            try
            {
                ProductFormulaEntity entity;
                using (MyDbContext db = new MyDbContext())
                {
                    entity = db.tbProductFormula.FirstOrDefault(r => r.ID == id);
                    return entity;
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"根据ID查询配方错误,ID:[{id}]:{e.Message}");
                LogMgr.Instance.Error($"异常堆栈: {e.StackTrace}");
                return null;
            }
            
        }

        public bool RemoveById(int id)
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    ProductFormulaEntity entity = db.tbProductFormula.FirstOrDefault(r => r.ID == id);
                    if (entity==null)
                    {
                        return false;
                    }
                    db.tbProductFormula.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"根据ID查询配方错误,ID:[{id}]:{e.Message}");
                LogMgr.Instance.Error($"异常堆栈: {e.StackTrace}");
                return false;
            }
        }

        public bool Update(ProductFormulaEntity entity)
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.tbProductFormula.Update(entity);
                    int i = db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                LogMgr.Instance.Error($"更新配方错误:{e.Message}");
                LogMgr.Instance.Error($"异常堆栈: {e.StackTrace}");
                return false;
            }
        }

        public bool Insert(ProductFormulaEntity entity)
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.tbProductFormula.Add(entity);
                    int i = db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                LogMgr.Instance.Error($"插入配方错误:{e.Message}");
                LogMgr.Instance.Error($"异常堆栈: {e.StackTrace}");
            }

            return false;

        }
    }
}
