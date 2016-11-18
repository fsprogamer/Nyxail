namespace UserTest
{
	public class User: IEntity
	{
		public User(int userId, string familyName, string givenName)
		{
			UserID = userId;
			FamilyName = familyName;
			GivenName = givenName;
		}

        public User()
        {
        }
        public string FamilyName { get; set; }

		public string GivenName { get; set; }

		public int UserID { get; set; }
	}
}