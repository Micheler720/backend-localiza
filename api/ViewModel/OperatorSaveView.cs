namespace ViewModel
{
    public record OperatorSaveView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Registration { get; set; }
        public string Password { get; set; }
    }
}