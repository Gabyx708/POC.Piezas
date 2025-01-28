using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using POC.Piezas.Infrastructure.Enums;
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

                var imagesList = workbook.GetAllPictures();

                for (int i = 1; i <= sheet.LastRowNum; i++)
                {

                    IRow row = sheet.GetRow(i);

                    if (row == null) continue;

                    ICell cellA = row.GetCell((int)ExcelColumn.A);

                    if (cellA == null || string.IsNullOrWhiteSpace(cellA.ToString()))
                    {
                        break;
                    }

                    try
                    {
                        //--
                        var pic = (XSSFPictureData)imagesList[i];
                        byte[] data = pic.Data;
                        BinaryWriter writer = new BinaryWriter(File.OpenWrite(String.Format("{0}.jpeg", i)));
                        writer.Write(data);
                        writer.Flush();

                        writer.Close();
                        //---
                    }catch(ArgumentOutOfRangeException)
                    {
                        continue;
                    }

                    string itemId = row.GetCell((int)ExcelColumn.A)?.ToString() ?? string.Empty;
                    string partNumber = row.GetCell((int)ExcelColumn.B)?.ToString() ?? string.Empty;
                    double quantity;

                    try
                    {
                        quantity = row.GetCell((int)ExcelColumn.D)?.NumericCellValue ?? 0;
                    }catch(Exception)
                    {
                        quantity = -100;
                    }



                    string stockNumber = row.GetCell((int)ExcelColumn.E)?.ToString() ?? string.Empty;
                    string material = row.GetCell((int)ExcelColumn.F)?.ToString() ?? string.Empty;
                    string destino = row.GetCell((int)ExcelColumn.G)?.ToString() ?? string.Empty;
                    string tratamiento = row.GetCell((int)ExcelColumn.H)?.ToString() ?? string.Empty;
                    string description = row.GetCell((int)ExcelColumn.B)?.ToString() ?? string.Empty;
                    string vendor = row.GetCell((int)ExcelColumn.O)?.ToString() ?? string.Empty;


                    // Crear un objeto Product y agregarlo a la lista
                    byte[]? thumbnail = i < imagesList.Count ? ((XSSFPictureData)imagesList[i]).Data : null;

                    var bomItem = new BomItem(item: itemId,
                                             partNumber: partNumber,
                                             quantity: (int)quantity,
                                             material: material,
                                             destino: destino,
                                             tratamiento: tratamiento,
                                             description: description,
                                             vendor: vendor);


                   if(thumbnail != null)
                    {
                        bomItem.SetImagen(thumbnail);
                    }


                    Items.Add(bomItem);
                }
            }

            return Items;
        }

        private ISheet GetFirstSheet(IWorkbook workbook)
        {
            return workbook.GetSheetAt(0);
        }


    }
}
