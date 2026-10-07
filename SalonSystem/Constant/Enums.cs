namespace SalonSystem.Constant
{
    public class Enums
    {
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Cancelled = 3,
            Pending = 4,
            Completed = 5
        }

        public enum UserType
        {
            Customer = 1,
            Employee = 2
        }

        public enum PaymentType
        {
            Cash = 1,
            Card = 2,
            Bank = 3,
            EasyPaisa = 4,
            JazzCash = 5
        }

        public enum OrderType
        {
            WalkIn = 1,
            Appointment = 2
        }

        public enum Source
        {
            Facebook = 1,
            Instagram = 2,
            WordOfMouth = 3
        }

        public enum Calculate
        {
            Add = 1,
            Subtract = 2
        }
    }
}
