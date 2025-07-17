namespace BusinessObject
{
    public enum CustomerStatus : byte
    {
        Inactive = 0,
        Active = 1
    }

    public enum RoomStatus : byte
    {
        Unavailable = 0,
        Available = 1
    }

    public enum BookingStatus : byte
    {
        Cancelled = 0,
        Confirmed = 1,
        Pending = 2
    }
}
