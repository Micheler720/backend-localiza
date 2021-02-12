namespace ViewModel
{
    public record ClientJWT
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cpf { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}