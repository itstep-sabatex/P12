﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPagesDemo.Data;
using System.Text.Unicode;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RazorPagesDemo.Services;

namespace RazorPagesDemo.Pages.Nomenclatures
{
    public class IndexModel : PageModel
    {
        internal record NomenclatureR(int id,string name,string price);
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMyLogger _logger;

        public IndexModel(RazorPagesDemo.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager,IMyLogger logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public IList<Nomenclature> Nomenclature { get;set; } = default!;


        public int LinesPerPage { get; set; } = 12;


        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int Pages { get; set; }
        public int Count { get; set; }

        [BindProperty(SupportsGet =true)]
        public string Filter { get; set; }=string.Empty;

        [BindProperty]
        public IFormFile Upload { get; set; }=default!;
        public async Task OnGetAsync()
        {
            var userId = User.GetUserId();

            _logger.Info($"User {userId} get ...");

            var user = await _userManager.GetUserAsync(User);

            var g =new Guid(); // GUID 
            // для баз даних      UUID є унікальним для таблиці (для первинного ключа)

            //Nomenclature = await _context.Nomenclature.Where(f=>f.Name.Contains(Filter ?? string.Empty))
            //                                          .OrderBy(o=>o.Id).Skip((CurrentPage -1)*LinesPerPage).Take(LinesPerPage).ToListAsync();
            //Count = await _context.Nomenclature.Where(f => f.Name.Contains(Filter ?? string.Empty)).CountAsync();
            var query = _context.Nomenclature.AsQueryable();
            if (!string.IsNullOrWhiteSpace(Filter))
            {
                query = query.Where(f => f.Name.Contains(Filter));
            }
            Nomenclature =await query.OrderBy(o => o.Id).Skip((CurrentPage - 1) * LinesPerPage).Take(LinesPerPage).ToListAsync();
            Count = await query.CountAsync();

            Pages = Count/LinesPerPage + ((Count % LinesPerPage) == 0?0:1);


        }

        public async Task OnPostAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await Upload.CopyToAsync(memoryStream);
                var str = Encoding.UTF8.GetString(memoryStream.ToArray());
                var nomenclatures = System.Text.Json.JsonSerializer.Deserialize<NomenclatureR[]>(str);
                foreach (var item in nomenclatures)
                {
                    var nomenclature = new Nomenclature { Id = item.id, Name = item.name ,Price = double.Parse(item.price.Replace('.',','))};

                    await _context.Nomenclature.AddAsync(nomenclature);
                }
               
                await _context.SaveChangesAsync();

            }
            Nomenclature = await _context.Nomenclature.Where(f => f.Name.Contains(Filter ?? string.Empty)).ToListAsync();
        }


        public void Clean()
        {

        }
    }
}
