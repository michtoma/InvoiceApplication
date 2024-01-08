namespace InvoiceApplication.Models.Service
{
    public class ModalMessage
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public ModalType Type { get; set; } = ModalType.Info;
        public bool IsVisible { get; set; } = false;
        public int? IdToDelte { get; set; }
    }
}
