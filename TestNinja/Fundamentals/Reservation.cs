namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        /// <summary>
        /// Has three execution paths
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CanBeCancelled(User user)
        {
            return (user.IsAdmin || MadeBy == user);
        }
    }
}
