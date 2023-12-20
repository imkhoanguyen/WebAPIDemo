namespace APIDemo.Model.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt{ShirtId = 1, Brand = "My Brand", Color = "Red", Gender = "Men", Price = 30, Size = 10},
            new Shirt{ShirtId = 2, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 45, Size = 42},
            new Shirt{ShirtId = 3, Brand = "My Brand", Color = "White", Gender = "Men", Price = 61, Size = 55},
            new Shirt{ShirtId = 4, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 22, Size = 33}
        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}
