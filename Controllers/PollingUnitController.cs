using BincomElectionProject.DTOs;
using BincomElectionProject.Models.Entities;
using BincomElectionProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BincomElectionProject.Controllers
{
    public class PollingUnitController : Controller
    {
        private readonly IElectionService _electionService;

        public PollingUnitController(IElectionService electionService)
        {
            _electionService = electionService;
        }

        [HttpGet]
        public IActionResult GetResultsByPollingUnit()
        {
            return View(); // Pass no model initially
        }

        [HttpGet("pollingunit/{id}")]
        public async Task<IActionResult> GetResultsByPollingUnit(int pollingUnitId)
        {
            // Fetch the polling unit results for the provided PollingUnitId
            var results = await _electionService.GetPollingUnitResultsAsync(pollingUnitId);
            return View(results);
        }



        //[HttpGet("lga/{id}")]
        //public async Task<IActionResult> GetTotalResultsByLgaId(int id)
        //{
        //    var result = await _electionService.GetTotalResultsByLgaIdAsync(id);
        //    return View(result); // Use a view to display the total results
        //}



        [HttpGet("lga")]
        public IActionResult EnterLgaId()
        {
            return View(); // Displays a form for entering the LGA ID
        }

        [HttpPost("lga")]
        public IActionResult EnterLgaId(int id)
        {
            // Redirects to the GetTotalResultsByLgaId action with the entered ID
            return RedirectToAction(nameof(GetTotalResultsByLgaId), new { id });
        }

        [HttpGet("lga/{id}")]
        public async Task<IActionResult> GetTotalResultsByLgaId(int id)
        {
            var result = await _electionService.GetTotalResultsByLgaIdAsync(id);
            if (result == null)
            {
                return NotFound("No results found for the specified LGA ID.");
            }
            return View(result); // Use a view to display the total results
        }



        [HttpGet("pollingunit/add")]
        public IActionResult AddPollingUnitResult()
        {
            return View(); // Render the form view for adding polling unit results
        }

        [HttpPost("pollingunit/add")]
        public async Task<IActionResult> AddPollingUnitResult(AddResultDto addResultDto)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, return the view with the current model for corrections
                return View(addResultDto);
            }

            try
            {
                // Call the service to add the result
                await _electionService.AddPollingUnitResultAsync(addResultDto);

                // Redirect to a confirmation or success page
                TempData["SuccessMessage"] = "Polling unit result added successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Log the error (optional) and return the view with an error message
                ModelState.AddModelError(string.Empty, "An error occurred while adding the result. Please try again.");
                return View(addResultDto);
            }
        }


    }
}
