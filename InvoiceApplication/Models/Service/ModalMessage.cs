namespace InvoiceApplication.Models.Service
{
    public class ModalMessage
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public ModalType Type { get; set; } = ModalType.Info;
        public bool isVisible { get; set; } = false;
        public int? idToDelte { get; set; }
    }
}
