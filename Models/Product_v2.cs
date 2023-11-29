namespace WebApiUsingIdentity.Models
{
    public class Product_v2
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductImageURL { get; set; }
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Discount { get; set; }
        public int MaxQntPerOrder { get; set; }
        public string UnitType { get; set; }
        public int RatingCount { get; set; }
        public double RatingAvg { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public bool OutOfStock { get; set; }
        public string ProductSource { get; set; }
        public string ServicableLocation { get; set; }
        public bool CoDAvailable { get; set; }
        public double ApproxWeight { get; set; }
    }
}
