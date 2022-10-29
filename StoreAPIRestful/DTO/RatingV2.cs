namespace StoreAPIRestful.DTO
{
    public class RatingV2
    {
        public Guid InternalId = Guid.NewGuid();
        public float? rate { get; set; }
        public int? count { get; set; }
    }
}
