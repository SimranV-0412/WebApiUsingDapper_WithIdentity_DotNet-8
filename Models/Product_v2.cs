namespace WebApiUsingIdentity.Models
{
    public class Product_v2
    {
        //public Int32 Row { get; set; }
        public int OrderCount { get; set; }
        public int ProductId { get; set; }
        //public string UserId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        //public string SubCategoryName { get; set; }
        //public string SubCategoryImageUrl { get; set; }
        public string ImageId { get; set; }
        //public string DefaultImage { get; set; }
        public string Description { get; set; }
        //public string Nutrition { get; set; }
        //public string productNewPrices { get; set; }
        public bool IsFavorite { get; set; }
        //public decimal? BuyingPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? MRP { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? Discount { get; set; }
        //public decimal? TaxPercentage { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public bool? IsActive { get; set; }
        //public bool? IsDelete { get; set; }
        public List<ProductImages_v2> ProductImages { get; set; }
        public List<NewPrice> NewPrices { get; set; }
        public int MaxQntPerOrder { get; set; }
        //public string UnitsAvailable { get; set; }
        public string UnitType { get; set; }
        //public int Weight { get; set; }
        //public int UnitId { get; set; }
        //public bool IsPrimaryImage { get; set; }

        // Need to review later
        public int OrderQuantity { get; set; }
        public int RatingAvg { get; set; }
        public int RatingCount { get; set; }
        // Use for Top rated Product
        public string ProductImageURL { get; set; }
        //public string ImageUrlforList { get; set; }
        //public string ImageUrlforGrid { get; set; }
        //public Vendor VendorDetails { get; set; }
        public bool OutOfStock { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public string ProductSource { get; set; }
        public string ServicableLocation { get; set; }
        //public string HSN { get; set; }
        public bool CoDAvailable { get; set; }
        //public string ProductType { get; set; }
        //public string AboutTheBrand { get; set; }
        //public string SellerFSSAI { get; set; }
        //public string ManufacturerDetails { get; set; }
        //public string PricingDetails { get; set; }
        //public string DispatchDetails { get; set; }
        //public string DispatchCity { get; set; }
        //public string TransitTime { get; set; }
        //public string Packaging { get; set; }
        //public string ProductReturn { get; set; }
        //public string Disclaimer { get; set; }
        //public int GroupId { get; set; }
        public decimal ApproxWeight { get; set; }
        //public List<ProductQuantities> ProductQuantities { get; set; }
    }

    public class NewPrice
    {
        public int ProductID { get; set; }

        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal MRP { get; set; }
        public decimal originalPrice { get; set; }
        public decimal? discountPrice { get; set; }
        public decimal? discount { get; set; }
        public decimal? TaxPercentage { get; set; }
        public string unitType { get; set; }
        public int UnitId { get; set; }
        public decimal cgstAmount { get; set; }
        public decimal sgstAmount { get; set; }
        public decimal igstAmount { get; set; }
        public decimal ApproxWeight { get; set; }
    }

    public class ProductImages_v2
    {
        //public Int32 ProductImageId { get; set; }
        public Int32 ProductId { get; set; }
        public string ProductImageURL { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsDelete { get; set; }
        public int ImageType { get; set; }
    }
    public class Offer
    {
        public int row { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TermsAndConditions { get; set; }
        public string OfferImageURL { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
    public class PromoCodeDetails
    {
        public int Row { get; set; }
        public int Id { get; set; }
        public string PromoCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ImageUrl { get; set; }
        public bool InPercent { get; set; }
        public float Amount { get; set; }
        public float MaxCashBack { get; set; }
        public float MinTransactAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string DisplayOnApp { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IsForNewUser { get; set; }
        public string ProductIds { get; set; }
        public string UserIds { get; set; }
        public int MaxRedeemLimit { get; set; }
        public int RedeemedCount { get; set; }
    }
    public class TopRatedProductsResponse
    {
        public List<Product_v2> topRatedProducts { get; set; }
        public List<Offer> offers { get; set; }
        public List<PromoCodeDetails> promoCodes { get; set; }
    }
}
