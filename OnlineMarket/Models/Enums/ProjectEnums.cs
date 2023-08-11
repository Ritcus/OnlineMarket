namespace OnlineMarket.Models.Enums
{
    public class ProjectEnums
    {
        public enum UserType
        {
            Personal,
            Business,
            Admin
        }

        public enum DeliveryStatus
        {
            OrderPlaced,
            PaymentRequired,
            PickedUp,
            OnTheWay,
            Delivered
        }
    }
}
