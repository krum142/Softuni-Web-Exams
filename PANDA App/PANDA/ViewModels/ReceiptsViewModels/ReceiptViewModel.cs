using System;

namespace PANDA.ViewModels
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Name { get; set; }
    }
}
