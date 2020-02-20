using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Common;
using ERP.Domain.IRepository;
using ERP.Repository;
using ERP.Domain.Entity;

namespace ERP.Application
{
    public class GroupApp
    {
        #region 品牌

        /// <summary>
        /// 品牌列表
        /// </summary>
        /// <returns></returns>
        public IList<Brand> BrandList()
        {
            try
            {
                return new BrandR().FindList(i => 1 == 1, true);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SaveBrand(Brand brand, ref string err)
        {
            IBrandR brandR = new BrandR();
            try
            {
                //新增
                if (brand.Id == 0)
                {
                    return brandR.Insert(brand) > 0;
                }
                //修改
                else
                {
                    return brandR.Update(brand) > 0;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除品牌
        /// </summary>
        /// <param name="id"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteBrand(int id, ref string err)
        {
            try
            {
                new BrandR().Delete(i => i.Id == id);
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }

        }

        #endregion
    }
}
