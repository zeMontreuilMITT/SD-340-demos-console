namespace AdventureWorksAPI.Models
{
    public static class ProductsMethods
    {
        public static IResult GetProduct(AdventureWorksLt2019Context db, int lowerCost = 0, int upperCost = Int32.MaxValue, int maxResults = 100)
        {
            return Results.Ok(db.Products
                .Where(p => p.ListPrice >= lowerCost && p.ListPrice <= upperCost)
                .Take(maxResults)
                .ToList());
        }

    }
}
