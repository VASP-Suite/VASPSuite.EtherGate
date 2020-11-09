using System;

namespace VASPSuite.EtherGate
{
    public class VASPCodeGenerator : IVASPCodeGenerator
    {
        private readonly Random _random;

        
        public VASPCodeGenerator()
        {
            _random = new Random();
        }

        
        public VASPCode GenerateVASPCode()
        {
            var buffer = new byte[4];
            _random.NextBytes(buffer);
            return new VASPCode(buffer);
        }
    }
}