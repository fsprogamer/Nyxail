namespace UserTest
{
	class Program
	{
		#region Methods

		static void Main(string[] args)
		{
            AppDBContext conn = new AppDBContext();
            UserRepository ur = new UserRepository(conn);
            User user = new User() { FamilyName = "1", GivenName = "1" };
            ur.AddUser(user);
            user = new User() { FamilyName = "2", GivenName = "2" };
            ur.AddUser(user);

            User readUser = ur.GetUser(2);

            User[] allUser = ur.GetOrderedUsers();

        }

		#endregion Methods
	}
}