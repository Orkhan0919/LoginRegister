using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly AppDbContext _context;

    public ProductController(ILogger<ProductController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var product = _context.Products2.ToList();
        return View(product);
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return View(_context.Products2.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var newProduct = new Product
        {
            Name = product.Name,
            Desc = product.Desc,
            Price = product.Price
        };
        _context.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _context.Products2.FindAsync(id);

        if (product == null)
        {
            return NotFound(); 
        }

        return View(product);    
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if  (id != product.Id) return BadRequest();
        var existProduct = await _context.Products2.FindAsync(id);
        if (existProduct==null) return NotFound();
        existProduct.Name=product.Name;
        existProduct.Desc = product.Desc;
        existProduct.Price=product.Price;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var product =await  _context.Products2.FindAsync(id);
        if (product == null) return NotFound();
         _context.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products2.FindAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }



}