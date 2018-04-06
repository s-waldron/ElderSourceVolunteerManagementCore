using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using OfficeOpenXml;
using ElderSourceVolunteerManagementCore.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class ReportController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        IVolunteerUpdateUserRespository volunteerUpdateUserRespository;
        ApplicationDbContext context;
        IVolunteer2OpportunityHoursWorkedRepository Volunteer2OpportunityHoursWorkedRepository;
        
        public ReportController(IHostingEnvironment hostingEnvironment,
            IVolunteerUpdateUserRespository volUpUser, ApplicationDbContext ctx,
            IVolunteer2OpportunityHoursWorkedRepository v2ohw)
        {
            _hostingEnvironment = hostingEnvironment;
            volunteerUpdateUserRespository = volUpUser;
            context = ctx;
            Volunteer2OpportunityHoursWorkedRepository = v2ohw;
        }

        public void AuditExport()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"auditreport.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            IEnumerable<VolunteerUpdateUser> volunteerUpdate = context.VolunteerUpdateUser
                .Include("Volunteer");
            int row = 2;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Audit Report");
                worksheet.Cells[1, 1].Value = "User Name";
                worksheet.Cells[1, 2].Value = "Date Updated";
                worksheet.Cells[1, 3].Value = "Volunteer First Name";
                worksheet.Cells[1, 4].Value = "Volunteer Last Name";

                foreach(var volUser in volunteerUpdate)
                {
                    worksheet.Cells[row, 1].Value = volUser.UserName;
                    worksheet.Cells[row, 2].Value = volUser.DateUpdated.ToString();
                    worksheet.Cells[row, 3].Value = volUser.Volunteer.FirstName;
                    worksheet.Cells[row, 4].Value = volUser.Volunteer.LastName;
                    row++;
                }
                //Add values
                //worksheet.Cells["A2"].Value = 1000;
                //worksheet.Cells["B2"].Value = "Jon";
                //worksheet.Cells["C2"].Value = "M";
                //worksheet.Cells["D2"].Value = 5000;

                //worksheet.Cells["A3"].Value = 1001;
                //worksheet.Cells["B3"].Value = "Graham";
                //worksheet.Cells["C3"].Value = "M";
                //worksheet.Cells["D3"].Value = 10000;

                //worksheet.Cells["A4"].Value = 1002;
                //worksheet.Cells["B4"].Value = "Jenny";
                //worksheet.Cells["C4"].Value = "F";
                //worksheet.Cells["D4"].Value = 5000;

                package.Save();
                
            }
            
        }
        
        // GET: /<controller>/
        public IActionResult Index(string Report)
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string auditFileName = @"auditreport.xlsx";
            string v2oFileName = @"volunteer2opportunityreport.xlsx";
            FileInfo auditFile = new FileInfo(Path.Combine(sWebRootFolder, auditFileName));
            FileInfo v2oFile = new FileInfo(Path.Combine(sWebRootFolder, v2oFileName));
            switch (Report)
            {
                case "aud":
                    AuditExport();
                    //downloadFile(_hostingEnvironment.WebRootPath, "report.xlsx");
                    
                    return View(new ReportViewModel
                    {
                        V2OUpdateDate = v2oFile.LastWriteTime,
                        AuditUpdateDate = auditFile.LastWriteTime
                    });
                case "v2o":
                    V2OReport();
                    return View(new ReportViewModel {
                        V2OUpdateDate = v2oFile.LastWriteTime,
                        AuditUpdateDate = auditFile.LastWriteTime
                    });                    
                default:

                    return View(new ReportViewModel
                    {

                        AuditUpdateDate = auditFile.LastWriteTime,
                        V2OUpdateDate = v2oFile.LastWriteTime
                    });
            }
        }

        public void V2OReport()
        {
            IEnumerable<Volunteer2Opportunity> v2oHoursWorked = context.Volunteer2Opportunities
                .Include("Volunteer2OpportunityHoursWorked").Include("Volunteer").Include("Opportunity");
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"volunteer2opportunityreport.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            }
            int row = 2;
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Audit Report");
                worksheet.Cells[1, 1].Value = "Volunteer First Name";
                worksheet.Cells[1, 2].Value = "Volunteer Last Name";
                worksheet.Cells[1, 3].Value = "Opportunity Name";
                worksheet.Cells[1, 4].Value = "Date and Time worked";
                worksheet.Cells[1, 5].Value = "Hours Worked";

                foreach (var v2o in v2oHoursWorked)
                {
                    worksheet.Cells[row, 1].Value = v2o.Volunteer.FirstName;
                    worksheet.Cells[row, 2].Value = v2o.Volunteer.LastName;
                    worksheet.Cells[row, 3].Value = v2o.Opportunity.OpportunityName;
                    worksheet.Cells[row, 4].Value = v2o.Volunteer2OpportunityHoursWorked.DateWorked.ToString();
                    worksheet.Cells[row, 5].Value = v2o.Volunteer2OpportunityHoursWorked.HoursWorked.ToString();
                    row++;
                }
                package.Save();
            }
        }
    }
}