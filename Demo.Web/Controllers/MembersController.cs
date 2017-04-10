using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Model;
using Demo.IBLL;

namespace Demo.Web
{
    public class MembersController : BaseController
    {
        // GET: Members
        public async Task<ActionResult> Index()
        {
            return View(await memberService.GetList(prop => prop.Id > 0).ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await memberService.GetModelAsync(id.Value);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                await memberService.AddAsync(member);
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await memberService.GetModelAsync(id.Value);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                await memberService.UpdateAsync(member);
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await memberService.GetModelAsync(id.Value);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Member member = memberService.GetModel(id);
            await memberService.DeleteAsync(member);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}