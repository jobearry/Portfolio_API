namespace Portfolio_API.Models.ProjectReviewModels
{
    public class ProjectReviewInput
    {
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectNo { get; set; } = string.Empty;
        public DateOnly DateRequested { get; set; }
        public string CheckerName { get; set; } = string.Empty;
        public IFormFile? AttachedJobOrder { get; set; }
        public IFormFile? AttachedInputData { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
