namespace Part11
{
    public class ProductMetadata : IEquatable<ProductMetadata>
    {
        public string Name { get; set; } //prop qe tregon emrin
        public double Price { get; set; } //prop qe tregon cmimin
        public bool IsCountable { get; set; } //prop qe tregon nese produkti ne fjale eshte i numerueshem apo jo

        public bool Equals(ProductMetadata? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;

        }
    }
}
