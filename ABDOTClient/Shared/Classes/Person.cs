namespace ABDOTClient.Shared.Classes
{
    public class Person
    {
        private int id { get; set; }
        private string FirstName { set; get; }
        private string LastName { set; get; }
        private string Email { set; get; }
        private string Password { set; get; }
        private string Street { set; get; }
        private string City { set; get; }
        private string PostCode { set; get; }
        private string Country { set; get; }

        public Person(int id,string FirstName, string LastName, string Email, string Password, string Street, string City,
            string PostCode, string Country)
        {
            this.id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Street = Street;
            this.City = City;
            this.PostCode = PostCode;
            this.Country = Country;
        }
    }
}