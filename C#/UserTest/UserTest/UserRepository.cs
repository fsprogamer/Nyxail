
namespace UserTest
{
	public class UserRepository
	{
        readonly Repository _db = null;
        public UserRepository(AppDBContext conn)
        {
            _db = new Repository(conn);
        }

        public void AddUser(User user)
		{
            _db.AddItem<User>(user);
            //throw new NotImplementedException();
        }

		public User[] GetOrderedUsers()
		{
            return _db.GetItems<User>();
            //throw new NotImplementedException();
        }

		public User GetUser(int userId)
		{
            return _db.GetItem<User>(userId);
            //throw new NotImplementedException();
        }
        
	}
}