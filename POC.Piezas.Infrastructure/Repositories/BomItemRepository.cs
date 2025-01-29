using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using POC.Piezas.Infrastructure.Enums;
using POC.Piezas.Infrastructure.Xslx;
using POC.Piezas.Models.BomAggregate;

namespace POC.Piezas.Infrastructure.Repositories
{
    public class BomItemRepository : IBomItemRepository
    {
        public IEnumerable<BomItem> GetItemsFromFile(string filePath)
        {
            List<BomItem> Items = new List<BomItem>();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fileStream);
                ISheet sheet = GetFirstSheet(workbook);
                string sheetName = sheet.SheetName;

                // Recorrer cada fila en la hoja
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);

                    if (row == null) continue;


                    string itemId = row.GetCell((int)ExcelColumn.A)?.ToString() ?? string.Empty;


                    string cellAddress = GetCellAddress(row,"C");
                    byte[]? thumbnail = XslxImages.GetImageFromCell(filePath,sheetName,cellAddress);
                    string partNumber = row.GetCell((int)ExcelColumn.B)?.ToString() ?? string.Empty;
                    double quantity;


                    try
                    {
                        quantity =row.GetCell((int)ExcelColumn.D)?.NumericCellValue ?? 0;
                    }
                    catch(Exception)
                    {
                        quantity = -100;
                    }

                    string stockNumber = row.GetCell((int)ExcelColumn.E)?.ToString() ?? string.Empty;
                    string material = row.GetCell((int)ExcelColumn.F)?.ToString() ?? string.Empty;
                    string destino = row.GetCell((int)ExcelColumn.G)?.ToString() ?? string.Empty;
                    string tratamiento = row.GetCell((int)ExcelColumn.H)?.ToString() ?? string.Empty;
                    string description = row.GetCell((int)ExcelColumn.B)?.ToString() ?? string.Empty;
                    string vendor = row.GetCell((int)ExcelColumn.O)?.ToString() ?? string.Empty;

                    // Crear el objeto BomItem
                    var bomItem = new BomItem(item: itemId,
                                              partNumber: partNumber,
                                              quantity: (int)quantity,
                                              material: material,
                                              destino: destino,
                                              tratamiento: tratamiento,
                                              description: description,
                                              vendor: vendor);

                    // Asignar la imagen al BomItem si la imagen existe
                    if (thumbnail != null)
                    {
                        bomItem.SetImagen(thumbnail); // Establecer la imagen
                    }

                    // Agregar el BomItem a la lista
                    Items.Add(bomItem);
                }
            }

            return Items;
        }


        private string GetCellAddress(IRow row, string columnIndex)
        {

            int rowIndex = row.RowNum + 1; // Excel usa base 1 para filas


            return $"{columnIndex}{rowIndex}";
        }


        private ISheet GetFirstSheet(IWorkbook workbook)
        {
            return workbook.GetSheetAt(0);
        }


    }
}
