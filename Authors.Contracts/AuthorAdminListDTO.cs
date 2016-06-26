namespace Authors.Contracts
{
    public class AuthorAdminListDTO
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public string LastName { get;set; }

        public string UserName { get;set; }

        public string Email { get;set; }
        public int PostCount { get; set; }
    }
}