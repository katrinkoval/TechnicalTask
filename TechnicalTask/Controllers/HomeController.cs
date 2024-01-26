using ConfigurationFileReader;
using DbService;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTask.Controllers
{
    public class HomeController : Controller
    {
        private const string FILE_PATH = "Data\\data.json";
        private readonly ITreeDbService _dbService;

        public HomeController(ITreeDbService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult UploadConfiguration()
        {
            JsonConverter converter = new JsonConverter();
            ReaderManager readerManager = new ReaderManager(converter);

            List<TreeNode> nodes = readerManager.ReadFile(FILE_PATH).ToList<TreeNode>();

            _dbService.FillDbTree(nodes);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
             
    }
}
