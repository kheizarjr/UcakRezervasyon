using Microsoft.AspNetCore.Mvc;
using UcakRezervasyon.Data;
using UcakRezervasyon.Models;
using UcakRezervasyon.ViewModels;

namespace UcakRezervasyon.Controllers
{
    public class KoltukController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KoltukController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Koltuk seçimi sayfasını göster
        public IActionResult Secim(int ucusId)
        {
            // İlgili uçuşun koltuk durumunu veritabanından getirin
            var doluKoltuklar = _context.rezervasyon
                .Where(r => r.ucusId == ucusId)
                .Select(r => r.KoltukNo)
                .ToList();

            // Koltukların genel sayısını varsayıyoruz, örneğin 6
            var koltukSayisi = 6;
            var koltuklar = new List<KoltukViewModel>();

            for (int i = 1; i <= koltukSayisi; i++)
            {
                koltuklar.Add(new KoltukViewModel
                {
                    KoltukNo = i,
                    DoluMu = doluKoltuklar.Contains(i)
                });
            }

            var model = new KoltukSecimViewModel
            {
                ucusId = ucusId,
                Koltuklar = koltuklar
            };

            return View(model);
        }

        // Koltuk seçimini işle
        [HttpPost]
        public IActionResult Secim(KoltukSecimViewModel model)
        {
            // Koltuğun dolu olup olmadığını kontrol et
            bool koltukDolu = _context.rezervasyon.Any(r => r.ucusId == model.ucusId && r.KoltukNo == model.SecilenKoltukNo);

            if (!koltukDolu && ModelState.IsValid)
            {
                var rezervasyon = new rezervasyon
                {
                    ucusId = model.ucusId,
                    KoltukNo = model.SecilenKoltukNo
                };

                _context.rezervasyon.Add(rezervasyon);
                _context.SaveChanges();

                return RedirectToAction("Onay", new { ucusId = model.ucusId, koltukNo = model.SecilenKoltukNo });
            }

            // ModelState geçerli değilse, koltukları yeniden yükle
            var doluKoltuklar = _context.rezervasyon
                .Where(r => r.ucusId == model.ucusId)
                .Select(r => r.KoltukNo)
                .ToList();

            var koltukSayisi = 6; // ya da gereken koltuk sayısı
            model.Koltuklar = new List<KoltukViewModel>();

            for (int i = 1; i <= koltukSayisi; i++)
            {
                model.Koltuklar.Add(new KoltukViewModel
                {
                    KoltukNo = i,
                    DoluMu = doluKoltuklar.Contains(i)
                });
            }

            return View(model);

        }
        }
    }


