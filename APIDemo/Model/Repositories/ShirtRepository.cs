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

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static Shirt? GetShirtByProperties(string? brand, string? color, string? gender, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            x.Size.Value == size.Value);
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;

        }

        public static void DeleteShirt(int id)
        {
            var shirt = shirts.First(x=>x.ShirtId == id);
            if(shirt!= null)
            {
                shirts.Remove(shirt);
            }
        }
    }
}
