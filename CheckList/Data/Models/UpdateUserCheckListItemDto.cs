namespace CheckList.Dtos
{
    public class UpdateUserCheckListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }
    }
}