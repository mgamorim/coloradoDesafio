using ColoradoDesafio.Web.Models;
using ColoradoDesafio.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ColoradoDesafio.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ITipoTelefoneService _tipoTelefoneService;

        public ClientesController(IClienteService clienteService, ITipoTelefoneService tipoTelefoneService)
        {
            _clienteService = clienteService;
            _tipoTelefoneService = tipoTelefoneService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();
                return View(clientes);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar clientes: {ex.Message}";
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar cliente: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.TiposTelefone = await _tipoTelefoneService.GetAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (cliente.Telefones != null)
                    {
                        cliente.Telefones = cliente.Telefones.Where(t => !string.IsNullOrWhiteSpace(t.Numero)).ToList();
                    }

                    await _clienteService.CreateAsync(cliente);
                    TempData["Success"] = "Cliente criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Erro ao criar cliente: {ex.Message}";
                }
            }

            ViewBag.TiposTelefone = await _tipoTelefoneService.GetAllAsync();
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                ViewBag.TiposTelefone = await _tipoTelefoneService.GetAllAsync();
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar cliente: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel cliente)
        {
            if (id != cliente.CodigoCliente)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (cliente.Telefones != null)
                    {
                        cliente.Telefones = cliente.Telefones.Where(t => !string.IsNullOrWhiteSpace(t.Numero)).ToList();
                    }

                    await _clienteService.UpdateAsync(id, cliente);
                    TempData["Success"] = "Cliente atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Erro ao atualizar cliente: {ex.Message}";
                }
            }

            ViewBag.TiposTelefone = await _tipoTelefoneService.GetAllAsync();
            return View(cliente);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao carregar cliente: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _clienteService.DeleteAsync(id);
                if (result)
                {
                    TempData["Success"] = "Cliente excluído com sucesso!";
                }
                else
                {
                    TempData["Error"] = "Erro ao excluir cliente.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao excluir cliente: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
