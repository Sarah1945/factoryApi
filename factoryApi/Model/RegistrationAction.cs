namespace factoryApi.Model
{
    public class RegistrationAction
    {
        public int RegistrationActionId { get; set; }
        public required string RegistrationActionName { get; set; }
        public required bool IsDeleted { get; set; } = false;
    }
}
