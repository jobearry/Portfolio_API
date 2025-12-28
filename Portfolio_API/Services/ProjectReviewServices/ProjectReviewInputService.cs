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
                var ws = wb.Worksheets.Add("Project Input Checklist");
                GenerateProjectInputChecklistSheet(ws, formData);

                //save to memory stream
                using var stream = new MemoryStream();
                wb.SaveAs(stream);

                return await Task.FromResult(stream);
            }
        }

        //for sheet 1
        public void GenerateProjectInputChecklistSheet(IXLWorksheet ws, ProjectReviewInput formData)
        {
            //title
            ws.Cell(2, 2).Value = "Project Input Checklist";
            ws.Cell(2, 2).Style.Font.Bold = true;
            ws.Cell(2, 2).Style.Font.FontSize = 20;

            //reference info
            ws.Cell(5, 2).Value = "Project Name:";
            ws.Cell(6, 2).Value = "Project No.:";
            ws.Cell(7, 2).Value = "Date Requested:";

            ws.Cell(5, 3).Value = formData.ProjectName;
            ws.Cell(6, 3).Value = formData.ProjectNo;
            ws.Cell(7, 3).Value = formData.DateRequested.ToString("MMMM dd, yyyy");

            //styling
            ws.Range("B5:B7").Style.Font.Bold = true;
            ws.Range("B5:C7").Style.Font.FontSize = 14;


            var checkList = new List<ProjectReviewChecklist>() 
            {
                new ProjectReviewChecklist
                (
                    item: "Project Order Sheet",
                    link: "'Project Request Sheet'!A1",
                    linkText: "Project Request Sheet",
                    checker: formData.CheckerName,
                    date: formData.DateRequested
                ),

                new ProjectReviewChecklist
                (
                    item: "Input Data",
                    link: "'Input Data Sheet'!A1",
                    linkText: "Input Data Sheet",
                    checker: formData.CheckerName,
                    date: formData.DateRequested
                ),
                new ProjectReviewChecklist
                (
                    item: "Expected Output",
                    link: "",
                    linkText: "Source code, Software",
                    checker: formData.CheckerName,
                    date: formData.DateRequested
                ),
                new ProjectReviewChecklist
                (
                    item: "Delivery Schedule",
                    link: "'Delivery Schedule Sheet'!A1",
                    linkText: "Delivery Schedule Sheet",
                    checker: formData.CheckerName,
                    date: formData.DateRequested
                ),
            };

            int headerRow = 10;
            var headers = GetHeaders();
            for (var i = 0; i < headers.Count(); i++)
            {
                ws.Cell(headerRow, i + 2).Value = headers[i];
            }

            ws.Range(headerRow, 2, headerRow, 5).Style.Font.Bold = true;
            ws.Range(headerRow, 2, headerRow, 5).Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Range(headerRow, 2, headerRow, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            int startRow = 11; // Row 10 is header, data starts at row 11
            for (int i = 0; i < checkList.Count; i++)
            {
                int currentRow = startRow + i;
                var item = checkList[i];

                ws.Cell(currentRow, 2).Value = item.Item;

                // Link column
                var linkCell = ws.Cell(currentRow, 3);
                linkCell.Value = item.LinkText;
                if (!string.IsNullOrEmpty(item.Link))
                {
                    linkCell.SetHyperlink(new XLHyperlink(item.Link));
                    linkCell.Style.Font.FontColor = XLColor.Blue;
                    linkCell.Style.Font.Underline = XLFontUnderlineValues.Single;
                }

                ws.Cell(currentRow, 4).Value = item.Checker;
                ws.Cell(currentRow, 5).Value = item.Date;
            }

            var cellChecker = ws.Range("D11:D14").Merge();
            cellChecker.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            cellChecker.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var cellCheckDate = ws.Range("E11:E14").Merge();
            cellCheckDate.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            cellCheckDate.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var checkListTable = ws.Range(startRow, 2, startRow + checkList.Count - 1, 5);
            checkListTable.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            checkListTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;   
            ws.Columns(2, 6).AdjustToContents();
        }

        public List<string> GetHeaders()
        {
            return new List<string>()
            {
                "Items",
                "Links",
                "Checked By",
                "Date"
            };
        }
    }
}
