using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class SendFileController : Controller
    {
        private string _fileName = "sample.pdf";
        private string _filePath = "~/Content/Files/";

        // GET: SendFile
        public ActionResult Index()
        {
            return View();
        }

        // FilePathResult: представляет простую отправку файла напрямую с сервера
        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath(_filePath + _fileName);
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = _fileName;
            return File(file_path, file_type, file_name);
        }

        // FileContentResult: отправляет клиенту массив байтов, считанный из файла
        public FileResult GetFileFromBytes()
        {
            string file_path = Server.MapPath(_filePath + _fileName);

            byte[] mas = System.IO.File.ReadAllBytes(file_path);

            string file_type = "application/pdf";
            string file_name = _fileName;
            return File(mas, file_type, file_name);
        }

        // FileStreamResult: данный класс создает поток - объект System.IO.Stream, с помощью которого считывает и отправляет файл клиенту
        public FileResult GetFileFromStream()
        {
            string file_path = Server.MapPath(_filePath + _fileName);
            // Объект Stream
            FileStream fs = new FileStream(file_path, FileMode.Open);

            string file_type = "application/pdf";
            string file_name = _fileName;
            return File(fs, file_type, file_name);
        }
    }
}