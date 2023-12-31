namespace UcakRezervasyon.ViewModels
{
    public class KoltukSecimViewModel
    {
        public int ucusId { get; set; }
        public List<KoltukViewModel> Koltuklar { get; set; }
        public int SecilenKoltukNo { get; set; }
    }
}
