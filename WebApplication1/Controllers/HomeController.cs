using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = "Anna";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien Dobry" : "Dobry wieczór";

            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname = "Nowak"},
              new Dane { Name = "Jan", Surname = "Nowak" },
                new Dane { Name = "Mateusz", Surname = "Kowalski" },
            };
                return View(osoby);
        }
        public IActionResult UrodzinyForm()
        {
            return View();
        }
        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok}";
            return View(urodziny);
        }
        public IActionResult Kalkulator(kalkulator kalkulator, string operation)
        {
            int wynik = 0;

            if (operation == "+")
            {
                wynik = kalkulator.A + kalkulator.B;
            }
            else if (operation == "-")
            {
                wynik = kalkulator.A - kalkulator.B;
            }
            else if (operation == "*")
            {
                wynik = kalkulator.A * kalkulator.B;
            }
            else if (operation == "/" && kalkulator.A != 0 && kalkulator.B != 0)
            {
                wynik = kalkulator.A / kalkulator.B;
            }

            ViewBag.wynik = $"Wynik: {wynik}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}