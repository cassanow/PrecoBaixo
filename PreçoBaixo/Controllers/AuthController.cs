using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PreçoBaixo.DTO;
using PreçoBaixo.Models;
using PreçoBaixo.Repository.Interface;

namespace PreçoBaixo.Controllers;

public class AuthController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("GetUsuarios", "Usuario");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var usuario = await _usuarioRepository.ObterPorEmail(dto.Email);

        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("GetUsuarios", "Usuario");
        }

        if (ModelState.IsValid && usuario != null && usuario.Email == dto.Email && usuario.Senha == dto.Senha)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, "Usuario")
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            
            return RedirectToAction("GetUsuarios", "Usuario");
        }
        
        ModelState.AddModelError(string.Empty, "Usuário ou senha incorretos");
        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Auth");
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Registrar()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("GetUsuarios", "Usuario");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Registrar(Usuarios usuario)
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("GetUsuarios", "Usuario");
        }
        
        if (ModelState.IsValid && !await _usuarioRepository.UsuarioExiste(usuario.Id))
        {
            await _usuarioRepository.AddUsuario(usuario);
            return RedirectToAction("Login", "Auth");
        }
        
        return View(usuario);
    }

}