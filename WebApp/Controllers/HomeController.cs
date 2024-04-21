using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.ViewModels;
using WebApp.ViewModels.Sections;
using WebApp.ViewModels.Views;


namespace WebApp.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{

    private readonly HttpClient _httpClient = httpClient;

    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Title = "Ultimate Task Management Assistant",
            Showcase = new ShowcaseViewModel
            {
                Id = "Showcase",
                ShowcaseImage = new() { ImageUrl = "images/showcase-image.svg", AltText = "Showcase Imager" },
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get Started for free" },
                BrandsText = "Largest companies use our tool to work efficiently",
                Brands =
                [
                    new() { ImageUrl = "images/brands/brand_1.svg", AltText = "Brand Name 1" },
                    new() { ImageUrl = "images/brands/brand_2.svg", AltText = "Brand Name 2" },
                    new() { ImageUrl = "images/brands/brand_3.svg", AltText = "Brand Name 3" },
                    new() { ImageUrl = "images/brands/brand_4.svg", AltText = "Brand Name 4" },
                ],


            }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Subscribe()
    {
        var viewModel = new SubscribeViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7259/api/subscribe", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You are now subscribed";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict) 
            {
                TempData["StatusMessage"] = "You are alredy subscribed";
            }

        }

        else
        {
            TempData["StatusMessage"] = "Invalid email address";
        }

        return RedirectToAction("Index", "subscribe");
    }
}