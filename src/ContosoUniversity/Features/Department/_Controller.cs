﻿namespace ContosoUniversity.Features.Department
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.DependencyInjection;

    public class _Controller : Controller
    {
        private readonly IMediator _mediator;

        public _Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.SendAsync(new Index.Query());

            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = await _mediator.SendAsync(new Create.Query());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Create.Command model)
        {
            await _mediator.SendAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _mediator.SendAsync(new Delete.Query(id));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Delete.Command model)
        {
            await _mediator.SendAsync(model);

            return RedirectToAction("Index");
        }
    }
}
