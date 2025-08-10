using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreçoBaixo.Models;
using PreçoBaixo.Repository.Interface;

namespace PreçoBaixo.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _usuarioRepository.Listar();
        return View(usuarios);
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> EditUsuario(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);

        if (usuario == null)
        {
            return RedirectToAction("Index", "Auth");
        }

        if (!await _usuarioRepository.UsuarioExiste(usuario.Id))
        {
            return RedirectToAction("Index", "Auth");
        }
        
        return View(usuario);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUsuario(Usuarios usuario)
    {
        if (ModelState.IsValid)
        {
            await _usuarioRepository.EditUsuario(usuario);
            return RedirectToAction("Index", "Auth");
        }
        return View(usuario);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);

        if (await _usuarioRepository.UsuarioExiste(usuario.Id))
        {
            await _usuarioRepository.DeleteUsuario(usuario);
            return RedirectToAction("Index", "Auth");
        }
        
        return RedirectToAction("Index", "Auth");
    }
    
}