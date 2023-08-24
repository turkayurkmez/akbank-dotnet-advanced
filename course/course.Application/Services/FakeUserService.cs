using course.Entities;

namespace course.Application.Services
{
    public class FakeUserService : IUserService
    {
        private List<User> users;
        public FakeUserService()
        {
            users = new List<User>()
            {
                 new() { Id = 1, Email="a@b.com", Name="Türkay", Password="123", Role="Admin", UserName="turkay" },
                 new() { Id = 2, Email="a@b.com", Name="Nesrin", Password="123", Role="Editor", UserName="nesrin" },
                 new() { Id = 1, Email="a@b.com", Name="Canan", Password="123", Role="Client", UserName="canan" },
            };
        }
        public User? ValidateUser(string username, string password)
        {
            return users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
