﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyContact.Data;
using CompanyContact.Models;

namespace CompanyContact.Controllers
{
    public class ContactPersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactPerson.ToListAsync());
        }

        // GET: ContactPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.ContactPerson
                .SingleOrDefaultAsync(m => m.ContactPersonId == id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            return View(contactPerson);
        }

        // GET: ContactPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactPersonId,FirstName,LasttName,Email,PhoneNumver")] ContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactPerson);
        }

        // GET: ContactPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.ContactPerson.SingleOrDefaultAsync(m => m.ContactPersonId == id);
            if (contactPerson == null)
            {
                return NotFound();
            }
            return View(contactPerson);
        }

        // POST: ContactPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactPersonId,FirstName,LasttName,Email,PhoneNumver")] ContactPerson contactPerson)
        {
            if (id != contactPerson.ContactPersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactPersonExists(contactPerson.ContactPersonId))
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
            return View(contactPerson);
        }

        // GET: ContactPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.ContactPerson
                .SingleOrDefaultAsync(m => m.ContactPersonId == id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            return View(contactPerson);
        }

        // POST: ContactPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactPerson = await _context.ContactPerson.SingleOrDefaultAsync(m => m.ContactPersonId == id);
            _context.ContactPerson.Remove(contactPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactPersonExists(int id)
        {
            return _context.ContactPerson.Any(e => e.ContactPersonId == id);
        }
    }
}
