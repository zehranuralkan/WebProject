

using Microsoft.EntityFrameworkCore;

namespace Form.Models
{
    [Keyless]
    public class Cografyalar
    {
        
        public int TabloId { get; set; }
        public string Tanim { get; set; }
        public int UstId { get; set; }
    }
}
