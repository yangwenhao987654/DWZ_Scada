using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaBase.DAL.DBContext;
using ScadaBase.DAL.Entity;

namespace ScadaBase.DAL.DAL
{
    public interface IProductFormulaDAL
    {

        List<ProductFormulaEntity> SelectAll();

        List<ProductFormulaEntity> SelectByName(string name);


        List<ProductFormulaEntity> SelectByType(string type);


        List<ProductFormulaEntity> SelectByNo(int plcNo);
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

        public List<ProductFormulaEntity> SelectByName(string name)
        {
            List<ProductFormulaEntity> list = new List<ProductFormulaEntity>();
            using (MyDbContext db = new MyDbContext())
            {
                //TODO 这里使用模糊查询 
                list = db.tbProductFormula.Where(r=>r.ProductName.Contains(name)).ToList();
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
                //TODO 这里使用模糊查询 
                list = db.tbProductFormula.Where(r => r.ProductPLCNo==plcNo).ToList();
            }
            return list;
        }
    }
}
