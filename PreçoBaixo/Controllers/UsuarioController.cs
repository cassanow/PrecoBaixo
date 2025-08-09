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
    
    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _usuarioRepository.Listar();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult AddUsuario()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddUsuario(Usuarios usuario)
    {
        if (!ModelState.IsValid)
        {
            foreach (var erro in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(erro.ErrorMessage);
            }

            return View(usuario);
        }
        
        if (ModelState.IsValid && !await _usuarioRepository.UsuarioExiste(usuario.Id))
        {
            await _usuarioRepository.AddUsuario(usuario);
            return RedirectToAction("Index", "Home");
        }
        
        return View(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> EditUsuario(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);

        if (usuario == null)
        {
            return RedirectToAction("Index", "Home");
        }

        if (!await _usuarioRepository.UsuarioExiste(usuario.Id))
        {
            return RedirectToAction("Index", "Home");
        }
        
        return View(usuario);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUsuario(Usuarios usuario)
    {
        if (ModelState.IsValid)
        {
            await _usuarioRepository.EditUsuario(usuario);
            return RedirectToAction("Index", "Home");
        }
        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);

        if (await _usuarioRepository.UsuarioExiste(usuario.Id))
        {
            await _usuarioRepository.DeleteUsuario(usuario);
            return RedirectToAction("Index", "Home");
        }
        
        return RedirectToAction("Index", "Home");
    }
    
}