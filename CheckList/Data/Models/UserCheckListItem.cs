public class UserCheckListItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsResolved { get; set; }
    public int UserId { get; set; }
    public bool IsSoftDeleted { get; set; }
    public User user { get; set; }
}