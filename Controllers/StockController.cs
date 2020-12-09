using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Models;

namespace Stock.Controllers
{
    [Route("api")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private StockContext _context;

        public StockController(StockContext context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("/stock")]
        public async Task<IActionResult> GetStocks()
        {
            try
            {
                var stocks = await _context.Stocks.ToListAsync();
                if (stocks == null)
                {
                    return NotFound();
                }

                return Ok(stocks);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        
        [HttpGet]
        [Route("/stock/{Id}")]
        public async Task<IActionResult> GetStocksById(int? Id)
        {
            try
            {
                var stock = await _context.Stocks.FindAsync(Id);

                if (stock == null)
                {
                    return NotFound();
                }

                return Ok(stock);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]Models.Stock stock)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(stock);
                    await _context.SaveChangesAsync();
                    if (stock.Id > 0)
                    {
                        return Ok(stock.Id);
                    }
                    
                    return NotFound();
                    
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("/delete/{Id}")]
        public async Task<IActionResult> DeletePost(int? Id)
        {

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var stock = await _context.Stocks.FindAsync(Id);
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]Models.Stock stock)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}