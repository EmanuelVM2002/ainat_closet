﻿using ainat_closet.Data;
using ainat_closet.Data.Entities;
using ainat_closet.Enums;
using ainat_closet.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vereyon.Web;

namespace ainat_closet.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;
        private readonly IOrdersHelper _ordersHelper;

        public OrdersController(DataContext context, IFlashMessage flashMessage, IOrdersHelper ordersHelper)
        {
            _context = context;
            _flashMessage = flashMessage;
            _ordersHelper = ordersHelper;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Dispatch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            if (sale.OrderStatus != OrderStatus.Nuevo)
            {
                _flashMessage.Danger("Solo se pueden Confirmar pedidos que estén en estado 'nuevo'.");
            }
            else
            {
                sale.OrderStatus = OrderStatus.Confirmado;
                _context.Sales.Update(sale);
                await _context.SaveChangesAsync();
                _flashMessage.Confirmation("El estado del pedido ha sido cambiado a 'Confirmado'.");
            }

            return RedirectToAction(nameof(Details), new { Id = sale.Id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            if (sale.OrderStatus == OrderStatus.Cancelado)
            {
                _flashMessage.Danger("No se puede cancelar un pedido que esté en estado 'cancelado'.");
            }
            else
            {
                await _ordersHelper.CancelOrderAsync(sale.Id);
                _flashMessage.Confirmation("El estado del pedido ha sido cambiado a 'cancelado'.");
            }

            return RedirectToAction(nameof(Details), new { Id = sale.Id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Send(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            if (sale.OrderStatus != OrderStatus.Confirmado)
            {
                _flashMessage.Danger("Solo se pueden enviar pedidos que estén en estado 'Confirmado'.");
            }
            else
            {
                sale.OrderStatus = OrderStatus.Enviado;
                _context.Sales.Update(sale);
                await _context.SaveChangesAsync();
                _flashMessage.Confirmation("El estado del pedido ha sido cambiado a 'enviado'.");
            }

            return RedirectToAction(nameof(Details), new { Id = sale.Id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            if (sale.OrderStatus != OrderStatus.Enviado)
            {
                _flashMessage.Danger("Solo se puede brindar estado de Entregado a pedido Enviados");
            }
            else
            {
                sale.OrderStatus = OrderStatus.Entregado;
                _context.Sales.Update(sale);
                await _context.SaveChangesAsync();
                _flashMessage.Confirmation("El estado del pedido ha sido cambiado a 'Entregado'.");
            }

            return RedirectToAction(nameof(Details), new { Id = sale.Id });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale sale = await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .ThenInclude(p => p.ProductImages)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyOrders()
        {
            return View(await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .Where(s => s.User.UserName == User.Identity.Name)
                .ToListAsync());
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale sale = await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .ThenInclude(p => p.ProductImages)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }


    }

}
