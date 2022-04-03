using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midi2MagicStomp
{
    public class dadosMS
    {
        public List<Patch> Patches { get; set; } = default!;
    }

    public class Patch
    {
        public byte[] PatchName { get; set; } = new byte[47];
        public byte[] PatchData { get; set; } = new byte[142];
    }
}
