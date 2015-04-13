using System.IO;
using System.Text;
using System.Web.Mvc;

namespace MVC5SampleApp.Controllers
{
    public class FileController : Controller
    {
        public class Ascii
        {
            public const byte one = 48;
            public const byte two = 49;
            public const byte three = 50;
            public const byte Comma = 44;
        }

        private byte[] fileContent = new[] { Ascii.one, Ascii.Comma, Ascii.two, Ascii.Comma, Ascii.three };

        private string mimeType = @"text\csv";

        // Use to FileContentResult when you have a byte array
        public FileContentResult Content()
        {
            var fileContentResult = new FileContentResult(fileContent, mimeType);
            fileContentResult.FileDownloadName = "FileContentExample.csv";
            return fileContentResult;
        }

        // Use the FilePathResult when you have a file on disk to send back
        public FilePathResult Path()
        {
            var filePath = Server.MapPath("~/SampleFile.csv");
            var filePathResult = new FilePathResult(filePath, mimeType);
            filePathResult.FileDownloadName = "SampleFile.csv";
            return filePathResult;
        }

        // Use the FileStreamResult when you have a stream that you want to send back
        public FileStreamResult Stream()
        {
            var stream = new MemoryStream(fileContent);
            var fileStreamResult = new FileStreamResult(stream, mimeType);
            fileStreamResult.FileDownloadName = "FileStreamExample.csv";
            return fileStreamResult;
        }
    }
} 