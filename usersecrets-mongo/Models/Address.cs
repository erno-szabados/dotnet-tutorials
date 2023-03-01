using MongoDB.Bson.Serialization.Attributes;

public class Address
{
    public string? Building { get; set; }

    [BsonElement("coord")]
    [BsonRepresentation(MongoDB.Bson.BsonType.Double, AllowTruncation=true)]
    public double[]? Coordinates { get; set; }

    public string? Street { get; set; }

    [BsonElement("zipcode")]
    public string? ZipCode { get; set; }
}