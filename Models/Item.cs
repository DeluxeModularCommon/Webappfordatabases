namespace DeluxeModularProTest.Models
{
    using Newtonsoft.Json;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ProductID")]
        public string ProductID { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "ManufactorID")]
        public string ManufactorID { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "CSICode")]
        public string CSICode { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "ProdCategory")]
        public string ProdCategory { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "ProdType")]
        public string ProdType { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "ProdMaterial")]
        public string ProdMaterial { get; set; }

        [JsonProperty(PropertyName = "PerformanceReq")]
        public string PerformanceReq { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "Color(Hex)")]
        public string Color { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "Texture")]
        public string Texture { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        [JsonProperty(PropertyName = "Shape")]
        public string Shape { get; set; }

        [JsonProperty(PropertyName = "Dimension")]
        public string Dimension { get; set; }

        [JsonProperty(PropertyName = "BIMObject")]
        public string BIMObject { get; set; }

        [JsonProperty(PropertyName = "InstallationType")]
        public string InstallationType { get; set; }

        [JsonProperty(PropertyName = "DataSheet")]
        public string DataSheet { get; set; }

        [JsonProperty(PropertyName = "SafetySheet")]
        public string SafetySheet { get; set; }

        [JsonProperty(PropertyName = "ContactName")]
        public string ContactName { get; set; }

        [JsonProperty(PropertyName = "ContactTitle")]
        public string ContactTitle { get; set; }

        [JsonProperty(PropertyName = "ContactPhone")]
        public string ContactPhone { get; set; }

        [JsonProperty(PropertyName = "ContactEmail")]
        public string ContactEmail { get; set; }

        [JsonProperty(PropertyName = "Inventory")]
        public double Inventory { get; set; }
    }
}
