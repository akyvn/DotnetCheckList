namespace CheckList.Dtos
{
    public class GetCheckListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }
        public int UserId { get; set; }
    }
}