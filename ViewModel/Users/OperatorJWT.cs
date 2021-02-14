namespace ViewModel.Users
{
    public record OperatorJWT
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Registration { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}