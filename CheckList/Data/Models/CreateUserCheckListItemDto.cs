namespace CheckList.Dtos
{
    public class CreateUserCheckListItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}