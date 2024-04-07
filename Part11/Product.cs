namespace Part11
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; set; } //prop qe tregon emrin
        public double Price { get; set; } //prop qe tregon cmimin
        public bool IsCountable { get; set; } //prop qe tregon nese produkti ne fjale eshte i numerueshem apo jo
        public double Amount { get; set; } //prop qe tregon sasine/numrin qe do te blejme
        public DateTime OrderDate { get; set; } = DateTime.Now; //prop qe percakton daten kur shte blere/porositur ky produkt

        public bool Equals(Product? other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;

        }
    }
}
