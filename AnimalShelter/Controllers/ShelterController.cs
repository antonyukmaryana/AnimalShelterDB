using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
namespace AnimalShelter.Controllers
{
  public class ShelterController : Controller
  {
    [HttpGet("/shelter")]
    public ActionResult Index()
    {
      List<Shelter> allAnimals = Shelter.GetAll();
      return View(allAnimals);
    }

    [HttpGet("/shelter/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/shelter")]
    public ActionResult Create(string shelterName, string shelterType, string shelterBreed, DateTime shelterDate)
    {
      Shelter newShelter = new Shelter(shelterName, shelterType, shelterBreed, shelterDate);
      newShelter.Save();
      List<Shelter> allAnimals = Shelter.GetAll();
      return View("Index", allAnimals);
    }
  }
}
