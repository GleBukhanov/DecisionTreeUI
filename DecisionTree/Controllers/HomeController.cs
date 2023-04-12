using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DecisionTree.Models;
using MyApp;

namespace DecisionTree.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Decision tree;
    public Decision MainDecisionTree()
    {
        var deny = new DecisionResult("Deny");
        var firstDay = new DecisionQuery()
        {
            Title = "Has he gone on the first day?",
            Negative = deny,
            Positive = new DecisionResult("Accept")
        };
        var requiredDocumets = new DecisionQuery()
        {
            Title = "Does he have required documents?",
            Negative = deny,
            Positive = firstDay
        };
        var successInterview = new DecisionQuery()
        {
            Title = "Do you have a success interview?",
            Negative = deny,
            Positive = requiredDocumets
        };
        var goToInterview = new DecisionQuery()
        {
            Title = "Is he go to interview?",
            Negative = deny,
            Positive = successInterview
        };
        var goodCV = new DecisionQuery()
        {
            Title = "Does he have a good CV?",
            Negative = deny,
            Positive = goToInterview
        };
            
        var call = new DecisionQuery()
        {
            Title = "Employee answered to the Call?",
            Negative = deny,
            Positive = goodCV
        };
        return call;
    }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        tree = MainDecisionTree();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ReturnResult(QuestionModel model)
    {
        var employee = new Employee()
        {
            model = model
        };
        return View((object)tree.Evaluate(employee));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}