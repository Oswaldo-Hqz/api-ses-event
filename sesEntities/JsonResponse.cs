
namespace sesEntities
{
    public class JsonResponse
    {
        public bool spam { get; set; }
        public bool virus { get; set; }
        public bool dns { get; set; }
        public string mes { get; set; }
        public bool retrasado { get; set; }
        public string emisor { get; set; }
        public List<string> receptor { get; set; }
    }
}
