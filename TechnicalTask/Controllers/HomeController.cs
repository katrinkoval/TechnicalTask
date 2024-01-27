using ConfigurationFileReader;
using DbService;
using Microsoft.AspNetCore.Mvc;
using TechnicalTask.Models;

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
            ConverterManager readerManager = new ConverterManager(converter);

            List<TreeNode> nodes = readerManager.ConvertFile(FILE_PATH).ToList<TreeNode>();

            _dbService.FillDbTree(nodes);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<TreeNode> tree = _dbService.GetTree();

            var model = new TreeModel
            {
                Nodes = tree
            };

            return View(model);
        }
             
    }
}
