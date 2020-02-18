using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ERP.Infrastructure.Common
{

    /// <summary>
    /// 文件导入
    /// </summary>
    public class FileImport : IDisposable
    {
        string dir = string.Empty;
        string filePath = string.Empty;
        private HttpContext context;
        public FileImport(HttpContext currentContext)
        {
            context = currentContext;
            if (context == null)
                context = HttpContext.Current;
            dir = context.Server.MapPath("UploadFiles");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            filePath = dir + "/AccountsExcel.xls";
        }

        public void DeleteFile()
        {
            File.Delete(filePath);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="context"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SaveFile(ref string err)
        {
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength <= 0)
            {
                err = "请选择要上传的文件！";
                return false;
            }

            string extension = Path.GetExtension(file.FileName);
            //1：限制文件格式
            if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
            {
                err = "请选择正确的Excel文件！";
                return false;
            }
            //2：限制文件大小
            if (file.ContentLength > 2097152) //1024*1024*2=2M,控制大小
            {
                err = "上传文件大小不能超过2M！";
                return false;
            }
            //3：保存文件
            if (File.Exists(filePath))
                File.Delete(filePath);
            //将上传来的文件数据保存在对应的物理路径上  
            file.SaveAs(filePath);
            return true;
        }

        /// <summary>
        /// 读取Excel导入的科目数据
        /// </summary>
        /// <param name="exCellCount"></param>
        /// <param name="err"></param>
        /// <returns>List<FormatBusinessData></returns>
        public IList<string[]> GetExcelData(ref string err)
        {
            err = string.Empty;
            //存文件
            if (!SaveFile(ref err))
                return null;

            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = null;
            try { new HSSFWorkbook(file); }
            catch
            {
                file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                workbook = new XSSFWorkbook(file);
            }
            file.Close();
            file.Dispose();

            ISheet sheet = workbook.GetSheetAt(0);
            if (sheet.LastRowNum < 1)
            {
                err = "没有数据";
                return null;
            }
            int cellCount = sheet.GetRow(1).Cells.Count;
            //组织数据
            List<string[]> dataList = new List<string[]>();
            string[] str = null;
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = (IRow)sheet.GetRow(i);
                if (row == null)
                    continue;
                str = new string[cellCount];
                str[0] = "";
                for (var j = 1; j < cellCount; j++)
                {
                    if (row.GetCell(j) == null)
                        continue;
                    str[j] = row.GetCell(j).ToString();
                }
                dataList.Add(str);
            }
            return dataList;
        }

        /// <summary>
        /// 读取Excel导入的科目数据 
        /// 合并列的文件
        /// </summary>
        /// <param name="exCellCount"></param>
        /// <param name="err"></param>
        /// <returns>List<FormatBusinessData></returns>
        public IList<string[]> GetExcelDataWithMerge(ref string err)
        {
            err = string.Empty;
            //存文件
            if (!SaveFile(ref err))
                return null;

            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            IWorkbook workbook = null;
            try { new HSSFWorkbook(file); }
            catch
            {
                file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                workbook = new XSSFWorkbook(file);
            }
            file.Close();
            file.Dispose();

            ISheet sheet = workbook.GetSheetAt(0);
            if (sheet.LastRowNum < 1)
            {
                err = "没有数据";
                return null;
            }
            int cellCount = sheet.GetRow(1).Cells.Count;
            //组织数据
            List<string[]> dataList = new List<string[]>();
            string[] str = null;
            List<dynamic> mergedList = GetMergedValues(sheet);
            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                IRow row = (IRow)sheet.GetRow(i);
                if (row == null)
                    continue;
                if (row.Cells.Count != cellCount)
                    continue;
                str = new string[cellCount];
                str[0] = "";
                for (var j = 1; j < cellCount; j++)
                {
                    if (row.GetCell(j) == null || row.Cells.ElementAt(j) == null)
                        continue;
                    string value = GetMergedCellValue(sheet, row, j, mergedList);
                    str[j] = value;
                }
                dataList.Add(str);
            }
            return dataList;
        }



        /// <summary>
        /// 定位行列的值
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="cellIndex"></param>
        /// <param name="mergedList"></param>
        /// <returns></returns>
        private string GetMergedCellValue(ISheet sheet, IRow row, int cellIndex, List<dynamic> mergedList)
        {
            //如果该列未
            if (!row.Cells.ElementAt(cellIndex).IsMergedCell)
            {
                if (row.GetCell(cellIndex) == null)
                    return null;
                return row.GetCell(cellIndex).ToString();
            }

            int rowIndex = row.RowNum;
            return mergedList.FirstOrDefault(i => cellIndex >= i.FirstColumn && cellIndex <= i.LastColumn
             && rowIndex >= i.FirstRow && rowIndex <= i.LastRow).Value;
        }

        /// <summary>
        /// 组织合并行的动态集合
        /// 列范围、行范围及对应的值
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private List<dynamic> GetMergedValues(ISheet sheet)
        {
            List<dynamic> list = new List<dynamic>();
            for (int ii = 0; ii < sheet.NumMergedRegions; ii++)
            {
                var cellrange = sheet.GetMergedRegion(ii);
                IRow row = sheet.GetRow(cellrange.FirstRow);
                var cell = row.GetCell(cellrange.FirstColumn);
                list.Add(new
                {
                    FirstColumn = cellrange.FirstColumn,
                    LastColumn = cellrange.LastColumn,
                    FirstRow = cellrange.FirstRow,
                    LastRow = cellrange.LastRow,
                    Value = cell == null ? "" : cell.ToString()
                });
            }
            return list;
        }

        public void Dispose() { }
    }
}
