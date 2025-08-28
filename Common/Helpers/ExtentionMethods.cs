using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Data;

namespace Common.Helpers
{
    public static class ExtentionMethods
    {
        public static string ToCustomString(this DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'") : "";
        }
        public static bool IsEquals(this string? str1, string? str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        public static async Task<DataTable> ReadExcel(this IFormFile? file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return new();
                }

                await using (var fileStream = file.OpenReadStream())
                {
                    using (var stream = new MemoryStream())
                    {
                        await fileStream.CopyToAsync(stream);

                        using (var workbook = new XLWorkbook(stream))
                        {
                            var worksheet = workbook.Worksheet(1);
                            var dataTable = new DataTable();

                            var range = worksheet.RangeUsed();
                            var rowCount = range.RowCount();
                            var columnCount = range.ColumnCount();

                            for (int col = 1; col <= columnCount; col++)
                            {
                                dataTable.Columns.Add(range.Cell(1, col).GetString());
                            }
                            for (int row = 2; row <= rowCount; row++)
                            {
                                var dataRow = dataTable.NewRow();

                                for (int col = 1; col <= columnCount; col++)
                                {
                                    dataRow[col - 1] = range.Cell(row, col).GetString();
                                }

                                dataTable.Rows.Add(dataRow);
                            }

                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return new();
            }
        }

        public static MemoryStream GetExcelStream(this DataTable? table)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "Sheet1");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return stream;
                }
            }
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T>? data)
        {
            DataTable table = new DataTable();
            if (data != null && data.Any())
            {
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
            }
            return table;
        }
    }
}
