namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Carts;
    using Core;
    using Kendo.Mvc.UI;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartsController : Controller<Cart, Guid>
    {
        public CartsController(IMediator mediator, ILogger<CartsController> logger)
            : base(mediator, logger)
        {
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var indexRequest = new CartIndexRequest(ModelState, request);
            return await base.Index(indexRequest).ConfigureAwait(false);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var detailsRequest = new CartDetailsRequest(ids[0], UserId);
            return await base.Details(detailsRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromBody] Cart cart)
        {
            if (!cart.UserId.HasValue && UserId.HasValue) cart.UserId = UserId.Value;
            var editRequest = new CartEditRequest(cart);
            return await base.Edit(editRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] IEnumerable<Cart> carts)
        {
            var editRangeRequest = new CartEditRangeRequest(carts);
            return await base.EditRange(editRangeRequest).ConfigureAwait(false);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Cart cart)
        {
            if (!cart.UserId.HasValue && UserId.HasValue) cart.UserId = UserId.Value;
            var createRequest = new CartCreateRequest(cart);
            return await base.Create(createRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<Cart>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] IEnumerable<Cart> carts)
        {
            var createRangeRequest = new CartCreateRangeRequest(carts);
            return await base.CreateRange(createRangeRequest).ConfigureAwait(false);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromQuery] Guid[] ids)
        {
            if (ids.Length != 1) return BadRequest(ids);
            var deleteRequest = new CartDeleteRequest(ids[0]);
            return await base.Delete(deleteRequest).ConfigureAwait(false);
        }
    }
}
