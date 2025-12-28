namespace Portfolio_API.Models.ProjectReviewModels
{
    public class ProjectReviewChecklist
    {
        public string Item { get; set; } = string.Empty;
        public string Checker { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;
        public string LinkText { get; set; } = string.Empty;

        private DateOnly _date;
        public string Date 
        { 
            get => _date.ToString("dd.MMM.yyyy").ToUpper();
            set
            {
                if (DateOnly.TryParse(value, out var parsedDate))
                {
                    _date = parsedDate;
                }
            } 
        }
        
        public ProjectReviewChecklist
        (
            string item, string link, 
            string linkText, string checker, DateOnly date
        )
        {
            Item = item;
            Link = link;
            LinkText = linkText;
            Checker = checker;
            _date = date;
        }

    }
}
