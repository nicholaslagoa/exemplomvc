using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExemploMVC.Models;

namespace ExemploMVC.Controllers
{//controller criado com scaffolding já com views, onde coloquei a classe Categoria e o Context criado e marquei todo o resto e deixei a barra em branco
    public class CategoriasController : Controller
    {
        private readonly Context _context;//cria a variável do tipo Context pra trabalhar

        public CategoriasController(Context context)//adiciona um construtor e atribui ele pra var criada para
        {//injetar a dependência, já que foi dito lá na linha 28 que o serviço do context seria utilizado em toda a aplicação via injeção
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()//action Index GET gerada viascaff
        {//quando chamar essa Action, o que vai fazer? vai chamar uma View com dados a serem mostrados dentro do ()
            return View(await _context.Categorias.ToListAsync());//retorna uma lista assíncrona da tabela Categorias do _context injetado
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)//action Details GET gerada viascaff//esse método recebe um id(ver route no startup.cs)
        {
            if (id == null)
            {
                return NotFound();
            }
            //quando passar uma id, vai no db e vai procurar a primeira categoria com essa id
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);//como id é um identificador único, só existe uma, então retorna essa id na var
            if (categoria == null)
            {
                return NotFound();
            }
            //se passar dos tratamentos, exibe de fato
            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()//action Create GET gerada viascaff
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Categoria categoria)//action Create POST gerada viascaff
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);//adiciona uma categoria, FALTANDO COMMITAR
                await _context.SaveChangesAsync();//salva as alterações e commita de fato no db
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)//action Edit GET gerada viascaff
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Categoria categoria)//action Edit POST gerada viascaff
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))//se não existe, nem faz nada
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)//action Delete GET criada viascaff
        {
            if (id == null)
            {
                return NotFound();
            }
            //quando passar uma id, vai no db e vai procurar a primeira categoria com essa id
            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);//como id é um identificador único, só existe uma, então retorna essa id na var
            if (categoria == null)
            {
                return NotFound();
            }
            //se passou por todas as exceções, retorna pra tela QUE NEM NO EDIT
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)//action Delete POST criada viascaff
        {
            var categoria = await _context.Categorias.FindAsync(id);//revalida se realmente existe a id
            _context.Categorias.Remove(categoria);//realiza a exclusão da categoria, ATENÇÃO PARA COMMITAR
            await _context.SaveChangesAsync();//esse é um método que de fato commita as alterações no db, sem este comando não haverá alteração de fato
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)//método privado criado default para verificar se a Categoria existe
        {//esse método é utilizado no Edit ali encima
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
