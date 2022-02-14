namespace PomeloCase.Core.Model.Base
{
    public class ErrorDto
    {
        public ErrorDto(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}