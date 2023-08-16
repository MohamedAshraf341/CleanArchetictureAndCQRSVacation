using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacation.Application.Features.Vacation.Commands.CreateVacation;
using Vacation.Application.Features.Vacation.Commands.DeleteVacation;
using Vacation.Application.Features.Vacation.Commands.UpdateVacation;
using Vacation.Application.Features.Vacation.Queries.GetVacationDetail;
using Vacation.Application.Features.Vacation.Queries.GetVacationList;

namespace Vacation.UI.Controllers
{
    public class VacationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _toastNotification;
        public VacationController(IMediator mediator, INotyfService toastNotification)
        {
            _mediator = mediator;
            _toastNotification = toastNotification;

        }
        public async Task<IActionResult> Index()
        {
            var vacations = await _mediator.Send(new GetVacationListQuery());
            return View(vacations);
        }
        public async Task<IActionResult> GetByID(Guid id)
        {
            var vacation = await _mediator.Send(new GetVacationDetailQuery() { Id=id});
            return View(vacation);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVacationCommand model)
        {
            if(!ModelState.IsValid)
            {
                _toastNotification.Error("model Invalid!");
                return View();
            }
            var id = await _mediator.Send(model);
            _toastNotification.Success("Save Vacation!");
            return View();
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var vacation = await _mediator.Send(new GetVacationDetailQuery() { Id = id });
            if (vacation == null)
                return NotFound();
            return View(vacation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateVacationCommand model)
        {
            await _mediator.Send(model);
            _toastNotification.Success("Update Vacation!");
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteVacation = await _mediator.Send(new DeleteVacationCommand() { Id = id });
            await _mediator.Send(deleteVacation);
            return Ok();
        }

    }
}
