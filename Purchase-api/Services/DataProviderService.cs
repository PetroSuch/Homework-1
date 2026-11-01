namespace PurchaseApi.Services
{
    public class DataProviderService : IDataProviderService
    {
        private static readonly List<string> ProductNames = new List<string>
        { "Hoover", "TV", "Washing machine", "Dishwasher", "Skrewkdriver", "Saw" };

        public string CreateProduct(string name)
        {
            ProductNames.Add(name);
            return name;
        }
        public string UpdateProduct(int index, string name)
        {
            ValidateIndex(index);

            ProductNames[index] = name;

            return name;
        }

        public void DeleteProduct(int index)
        {
            ValidateIndex(index);

            ProductNames.RemoveAt(index);
        }

        public string GetProduct(int index)
        {
            ValidateIndex(index);
            
            return ProductNames[index];
        }

        public List<string> GetProducts()
        {
            return ProductNames;
        }

        private void ValidateIndex(int index)
        {
            if(index < 0 || index >= ProductNames.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    } 
}
