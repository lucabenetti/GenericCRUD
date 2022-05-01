namespace GenericApplication.Responses
{
    public class PersonResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
}
