using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };

                    _dataCol.Add(dtTable);
                }
            }
        }

        private static DataTable ExcelToDataTable(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            excelReader.IsFirstRowAsColumnNames = true;

            DataSet result = excelReader.AsDataSet();

            DataTableCollection table = result.Tables;

            DataTable resultTable = table["Sheet1"];

            return resultTable;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public class Datacollection
        {
            public int rowNumber { get; set;}
            public string colName { get; set; }
            public string colValue { get; set; }

        }
    }
}
