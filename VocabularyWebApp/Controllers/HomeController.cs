using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VocabularyWebApp.Models;
using VocabularyWebApp.Repositories;

namespace VocabularyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWordRepository repo;

        public HomeController(ILogger<HomeController> logger, IWordRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var vocabulary = repo.GetAllWords();
            return View(vocabulary);
        }

        public IActionResult Add()
        {
            return View(new WordModel());
        }

        [HttpPost]
        public IActionResult Add(WordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            repo.AddWord(model);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int WordId)
        {
            var model = repo.GetOneWord(WordId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(WordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            repo.UpdateWord(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(WordModel model)
        {
            repo.DeleteWord(model.WordId);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
