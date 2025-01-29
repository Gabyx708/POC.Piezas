using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace POC.Piezas.Infrastructure.Xslx
{
    static internal class XslxImages
    {
        public static byte[]? GetImageFromCell(string filePath, string sheetName, string cellAddress)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Configurar licencia para uso no comercial

            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets[sheetName];

            var picture = worksheet.Drawings
                .OfType<ExcelPicture>()
                .FirstOrDefault(p => p.From.Row == worksheet.Cells[cellAddress].Start.Row - 1 &&
                                     p.From.Column == worksheet.Cells[cellAddress].Start.Column - 1);

            if (picture != null)
            {
                return picture.Image.ImageBytes;
            }

            return null;
        }
    }
}
