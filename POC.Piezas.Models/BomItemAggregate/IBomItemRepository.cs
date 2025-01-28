namespace POC.Piezas.Models.BomAggregate
{
    public interface IBomItemRepository
    {
        IEnumerable<BomItem> GetItemsFromFile(string filePath);
    }
}
