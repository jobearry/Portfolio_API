using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Portfolio_API.Models.ProjectReviewModels;

namespace Portfolio_API.Services.ProjectReviewServices
{
    public class ProjectReviewInputService
    {
        public ProjectReviewInputService()
        {

        }

        public async Task<MemoryStream> ExportProjectInput(ProjectReviewInput formData)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Project Review Input");

                ws.Cell(1, 1).Value = formData.ProjectName;
                ws.Cell(1, 2).Value = formData.ProjectNo;
                ws.Cell(1, 3).Value = formData.DateRequested.ToString("yyyy-MM-dd");
                ws.Cell(1, 4).Value = formData.CheckerName;
                ws.Cell(1, 5).Value = formData.DueDate.ToString("yyyy-MM-dd");

                //process attached files

                using var stream = new MemoryStream();
                wb.SaveAs(stream);
                stream.Position = 0;


                return await Task.FromResult(stream);
            }
        }
    }
}
